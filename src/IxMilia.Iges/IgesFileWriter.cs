// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using IxMilia.Iges.Entities;

namespace IxMilia.Iges
{
    internal class IgesFileWriter
    {
        public void Write(IgesFile file, Stream stream)
        {
            var writer = new StreamWriter(stream);

            // prepare entities
            var startLines = new List<string>();
            var globalLines = new List<string>();

            var writerState = new IgesEntity.WriterState(
                new Dictionary<IgesEntity, int>(),
                new List<string>(),
                new List<string>(),
                file.FieldDelimiter,
                file.RecordDelimiter);

            startLines.Add(new string(' ', IgesFile.MaxDataLength));

            foreach (var entity in file.Entities)
            {
                if (!writerState.EntityMap.ContainsKey(entity))
                {
                    entity.AddDirectoryAndParameterLines(writerState, file);
                }
            }

            PopulateGlobalLines(file, globalLines);

            // write start line
            WriteLines(writer, IgesSectionType.Start, startLines);

            // write global lines
            WriteLines(writer, IgesSectionType.Global, globalLines);

            // write directory lines
            WriteLines(writer, IgesSectionType.Directory, writerState.DirectoryLines);

            // write parameter lines
            WriteLines(writer, IgesSectionType.Parameter, writerState.ParameterLines); // TODO: ensure space in column 65 and directory pointer in next 7

            // write terminator line
            writer.Write(MakeFileLine(IgesSectionType.Terminate,
                string.Format("{0}{1,7}{2}{3,7}{4}{5,7}{6}{7,7}",
                    SectionTypeChar(IgesSectionType.Start),
                    startLines.Count,
                    SectionTypeChar(IgesSectionType.Global),
                    globalLines.Count,
                    SectionTypeChar(IgesSectionType.Directory),
                    writerState.DirectoryLines.Count,
                    SectionTypeChar(IgesSectionType.Parameter),
                    writerState.ParameterLines.Count),
                1));

            writer.Flush();
        }

        private static void PopulateGlobalLines(IgesFile file, List<string> globalLines)
        {
            AddParametersToStringList(
                new object[] {
                    file.FieldDelimiter.ToString(),
                    file.RecordDelimiter.ToString(),
                    file.Identification,
                    file.FullFileName,
                    file.SystemIdentifier,
                    file.SystemVersion,
                    file.IntegerSize,
                    file.SingleSize,
                    file.DecimalDigits,
                    file.DoubleMagnitude,
                    file.DoublePrecision,
                    file.Identifier,
                    file.ModelSpaceScale,
                    (int)file.ModelUnits,
                    file.CustomModelUnits,
                    file.MaxLineWeightGraduations,
                    file.MaxLineWeight,
                    file.TimeStamp,
                    file.MinimumResolution,
                    file.MaxCoordinateValue,
                    file.Author,
                    file.Organization,
                    (int)file.IgesVersion,
                    (int)file.DraftingStandard,
                    file.ModifiedTime,
                    file.ApplicationProtocol
                },
                globalLines,
                file.FieldDelimiter,
                file.RecordDelimiter);
        }

        internal static int AddParametersToStringList(object[] parameters, List<string> stringList, char fieldDelimiter, char recordDelimiter, int maxLength = IgesFile.MaxDataLength, string lineSuffix = null, string comment = null)
        {
            int suffixLength = lineSuffix == null ? 0 : lineSuffix.Length;
            var sb = new StringBuilder();
            int addedLines = 0;
            Action addLine = () =>
            {
                // ensure proper length
                sb.Append(new string(' ', maxLength - sb.Length - suffixLength));

                // add suffix
                sb.Append(lineSuffix);
                stringList.Add(sb.ToString());
                sb.Clear();
                addedLines++;
            };

            /*
            StringBuilder parameters_sb = new StringBuilder(parameters.Length * 2);
            parameters_sb.Append(ParameterToString(parameters[0]));
            for (int i = 1; i < parameters.Length; i++)
            {
                parameters_sb.Append(recordDelimiter);
                parameters_sb.Append(ParameterToString(parameters[i]));
            }
            parameters_sb.Append(fieldDelimiter);
            string parameters_str = parameters_sb.ToString();
            */

            for (int i = 0; i < parameters.Length; i++)
            {
                var delim = (i == parameters.Length - 1) ? recordDelimiter : fieldDelimiter;
                var parameter = parameters[i];
                var paramString = ParameterToString(parameter) + delim;
                if (sb.Length + paramString.Length + suffixLength <= maxLength)
                {
                    // if there's enough space on the current line, do it
                    sb.Append(paramString);
                }
                else if (paramString.Length + suffixLength <= maxLength)
                {
                    // else if it will fit onto a new line, commit the current line and start a new one
                    addLine();
                    sb.Append(paramString);
                }
                else
                {
                    // otherwise, write as much as we can and wrap the rest
                    while (paramString.Length > 0)
                    {
                        var allowed = maxLength - sb.Length - suffixLength;
                        if (paramString.Length <= allowed)
                        {
                            // write all of it and be done
                            sb.Append(paramString);
                            paramString = string.Empty;
                        }
                        else
                        {
                            // write as much as possible
                            sb.Append(paramString.Substring(0, allowed));
                            Debug.Assert(sb.Length == maxLength - suffixLength, "This should have been a full line");

                            // and commit it
                            addLine();
                            paramString = paramString.Substring(allowed);
                        }
                    }
                }
            }

            // add comment
            if (comment != null)
            {
                // escape things
                comment = comment.Replace("\\", "\\\\");
                comment = comment.Replace("\n", "\\n");
                comment = comment.Replace("\r", "\\r");
                comment = comment.Replace("\t", "\\t");
                comment = comment.Replace("\v", "\\v");
                comment = comment.Replace("\f", "\\f");

                // write as much of the comment as possible
                while (comment.Length > 0)
                {
                    var allowed = maxLength - sb.Length - suffixLength;
                    if (comment.Length <= allowed)
                    {
                        // write the whole thing
                        sb.Append(comment);
                        comment = string.Empty;
                    }
                    else
                    {
                        // write as much as possible
                        sb.Append(comment.Substring(0, allowed));
                        addLine();
                        comment = comment.Substring(allowed);
                    }
                }
            }

            // commit any remaining text
            if (sb.Length > 0)
                addLine();

            return addedLines;
        }

        private static string ParameterToString(object parameter)
        {
            if (parameter == null)
                return string.Empty;
            else if (parameter is int)
                return ParameterToString((int)parameter);
            else if (parameter is double)
                return ParameterToString((double)parameter);
            else if (parameter is string)
                return ParameterToString((string)parameter);
            else if (parameter is DateTime)
                return ParameterToString((DateTime)parameter);
            else if (parameter is bool)
                return ParameterToString((bool)parameter);
            else
            {
                Debug.Assert(false, "Unsupported parameter type: " + parameter.GetType().ToString());
                return string.Empty;
            }
        }

        private static string ParameterToString(int parameter)
        {
            return parameter.ToString(CultureInfo.InvariantCulture);
        }

        private static string ParameterToString(double parameter)
        {
            var str = parameter.ToString(CultureInfo.InvariantCulture);
            
            //if (!(str.Contains(".") || str.Contains("e") || str.Contains("E") || str.Contains("d") || str.Contains("D")))
            if (str.IndexOf('.') + str.IndexOf('e') + str.IndexOf('E') + str.IndexOf('d') + str.IndexOf('D') == -5)
                    str += '.'; // add trailing decimal point
            return str;
        }

        private static string ParameterToString(string parameter)
        {
            if (string.IsNullOrEmpty(parameter))
                return string.Empty;
            else
                return parameter.Length.ToString() + "H" + parameter;
        }

        internal static string ParameterToString(DateTime parameter)
        {
            return ParameterToString(parameter.ToString("yyyyMMdd.HHmmss"));
        }

        private static string ParameterToString(bool parameter)
        {
            return parameter ? "1" : string.Empty;
        }

        private static void WriteLines(StreamWriter writer, IgesSectionType sectionType, List<string> lines)
        {
            for (int i = 0; i < lines.Count; i++)
            {
                writer.Write(MakeFileLine(sectionType, lines[i], i + 1));
            }
        }

        private static string MakeFileLine(IgesSectionType sectionType, string line, int lineNumber)
        {
            line = line ?? string.Empty;
            if (line.Length > 72)
                throw new IgesException("Line is too long");

            var fullLine = string.Format("{0,-72}{1}{2,7}\n", line, SectionTypeChar(sectionType), lineNumber);
            return fullLine;
        }

        private static char SectionTypeChar(IgesSectionType type)
        {
            switch (type)
            {
                case IgesSectionType.Start: return 'S';
                case IgesSectionType.Global: return 'G';
                case IgesSectionType.Directory: return 'D';
                case IgesSectionType.Parameter: return 'P';
                case IgesSectionType.Terminate: return 'T';
                default:
                    throw new IgesException("Unexpected section type " + type);
            }
        }
    }
}

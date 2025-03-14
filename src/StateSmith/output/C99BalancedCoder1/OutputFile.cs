﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace StateSmith.output.C99BalancedCoder1
{
    public class OutputFileChangeTracker
    {
        private OutputFile outputFile;
        private int lastStringBufferLength;

        public OutputFileChangeTracker(OutputFile outputFile)
        {
            this.outputFile = outputFile;
            Reset();
        }

        public bool TestChanged()
        {
            return outputFile.GetStringBufferLength() != lastStringBufferLength;
        }

        public void Reset()
        {
            lastStringBufferLength = outputFile.GetStringBufferLength();
        }

        public bool PopChanged()
        {
            bool changed = TestChanged();
            Reset();
            return changed;
        }

        public void OutputNewLineOnChange()
        {
            if (PopChanged())
            {
                outputFile.AppendLine();
            }
        }
    }

    public class OutputFile
    {
        readonly CodeGenContext ctx;
        readonly StringBuilder sb;
        private readonly CodeStyleSettings styler;
        private int indentLevel = 0;
        private bool lineIncomplete = false;

        private bool lineBreakBeforeMoreCode = false;

        public OutputFile(CodeGenContext codeGenContext, StringBuilder fileStringBuilder)
        {
            ctx = codeGenContext;
            sb = fileStringBuilder;
            styler = codeGenContext.style;
        }

        public void RequestNewLineBeforeMoreCode()
        {
            lineBreakBeforeMoreCode = true;
        }

        public OutputFileChangeTracker GetChangeTracker()
        {
            return new OutputFileChangeTracker(this);
        }

        public void StartCodeBlock(bool forceNewLine = false)
        {
            if (styler.BracesOnNewLines || forceNewLine)
            {
                MaybeFinishPartialLine();
                Append("{");
            }
            else
            {
                AppendWithoutIndent(" {");
            }

            FinishLine();
            indentLevel++;
        }

        /// <summary>
        /// Doesn't try to finish line first (depending on style settings).
        /// </summary>
        public void StartCodeBlockHere()
        {
            Append("{");
            FinishLine();
            indentLevel++;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codeAfterBrace"></param>
        /// <param name="forceNewLine">probably the only time this should be false is when rendering in if/else</param>
        /// <exception cref="InvalidOperationException"></exception>
        public void FinishCodeBlock(string codeAfterBrace = "", bool forceNewLine = true)
        {
            indentLevel--;
            if (indentLevel < 0)
            {
                throw new InvalidOperationException("indent went negative");
            }

            lineBreakBeforeMoreCode = false;

            Append("}");
            AppendWithoutIndent(codeAfterBrace); // this part shouldn't be indented

            if (styler.BracesOnNewLines || forceNewLine)
            {
                FinishLine();
            }
        }

        public void AppendLines(string codeLines)
        {
            var lines = StringUtils.SplitIntoLines(codeLines);
            foreach (var line in lines)
            {
                AppendLine(line);
            }
        }

        public void AppendLinesIfNotBlank(string code)
        {
            if (code.Length == 0)
            {
                return;
            }
            AppendLines(code);
        }

        public void AppendLine(string codeLine = "")
        {
            Append(codeLine);
            FinishLine();
        }

        public void AppendDetectNewlines(string code = "")
        {
            var lines = StringUtils.SplitIntoLines(code);
            foreach (var line in lines)
            {
                Append(line);
                if (lines.Length > 1)
                {
                    FinishLine();
                }
            }
        }

        public void AppendWithoutIndent(string code = "")
        {
            if (code.Length == 0)
            {
                return;
            }

            lineIncomplete = true;
            sb.Append(code);
        }

        public void Append(string code = "")
        {
            if (lineBreakBeforeMoreCode)
            {
                lineBreakBeforeMoreCode = false;
                AppendLine();
            }

            styler.Indent(sb, indentLevel);
            AppendWithoutIndent(code);
        }

        public void FinishLine(string code = "")
        {
            AppendWithoutIndent(code);
            AppendWithoutIndent(styler.Newline);
            lineIncomplete = false;
        }

        public void MaybeFinishPartialLine(string code = "")
        {
            AppendWithoutIndent(code);

            if (lineIncomplete)
            {
                AppendWithoutIndent(styler.Newline);
            }
            lineIncomplete = false;
        }

        public override string ToString()
        {
            return sb.ToString();
        }

        public int GetStringBufferLength()
        {
            return sb.Length;
        }
    }
}

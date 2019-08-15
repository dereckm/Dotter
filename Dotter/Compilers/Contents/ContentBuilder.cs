using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dotter.Compilers.Contents
{
    public class ContentBuilder
    {
        private readonly List<Line> _lines = new List<Line>();

        public void Add(string content, int depth)
        {
            _lines.Add(new Line
            {
                Content = content,
                IndentationLevel = depth
            });
        }

        public override string ToString()
        {
            var content = new StringBuilder();

            foreach (var line in _lines)
            {
                content.AppendLine($"{GetIndentation(line.IndentationLevel)}{line.Content}");
            }

            return content.ToString();
        }

        private string GetIndentation(int indentationLevel)
        {
            var indentation = string.Empty;

            for (var i = 0; i < indentationLevel; i++)
            {
                indentation += "    ";
            }

            return indentation;
        }
    }
}
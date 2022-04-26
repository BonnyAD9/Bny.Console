using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Con = System.Console;

namespace Bny.Console;

public partial class Term
{
    /// <summary>
    /// Prints formatted text into console
    /// </summary>
    /// <param name="output">Text and format</param>
    /// <exception cref="ArgumentException">Thrown when there are no arguments for specific format strings</exception>
    public static void Form(params object[] output) => Con.Write(Prepare(output));

    /// <summary>
    /// Prints formatted text into console and appends it with newline
    /// </summary>
    /// <param name="output">Text and format</param>
    /// <exception cref="ArgumentException">Thrown when there are no arguments for specific format strings</exception>
    public static void FormLine(params object[] output) => Con.WriteLine(Prepare(output));

    /// <summary>
    /// Prepares string with the given formatting
    /// </summary>
    /// <param name="output">what will be prepared</param>
    /// <returns>the prepared string</returns>
    /// <exception cref="ArgumentException">Thrown when there are no arguments for specific format strings</exception>
    public static string Prepare(params object[] output) => PrepareSB(output).ToString();

    /// <summary>
    /// Prepares string with the given formatting
    /// </summary>
    /// <param name="output">what will be prepared</param>
    /// <returns>StringBuilder with the prepared string</returns>
    /// <exception cref="ArgumentException">Thrown when there are no arguments for specific format strings</exception>
    public static StringBuilder PrepareSB(params object[] output)
    {
        StringBuilder sb = new();
        for (int i = 0; i < output.Length; i++)
        {
            if (output[i] is string s)
            {
                switch (s)
                {
                    case move:
                        if (i + 2 >= output.Length)
                            throw new ArgumentException("Invalid number of arguments");
                        sb.Append(string.Format(move, output[++i], output[++i]));
                        break;
                    case up:
                        if (i + 1 >= output.Length)
                            throw new ArgumentException("Invalid number of arguments");
                        sb.Append(string.Format(up, output[++i]));
                        break;
                    case down:
                        if (i + 1 >= output.Length)
                            throw new ArgumentException("Invalid number of arguments");
                        sb.Append(string.Format(down, output[++i]));
                        break;
                    case right:
                        if (i + 1 >= output.Length)
                            throw new ArgumentException("Invalid number of arguments");
                        sb.Append(string.Format(right, output[++i]));
                        break;
                    case left:
                        if (i + 1 >= output.Length)
                            throw new ArgumentException("Invalid number of arguments");
                        sb.Append(string.Format(left, output[++i]));
                        break;
                    case downStart:
                        if (i + 1 >= output.Length)
                            throw new ArgumentException("Invalid number of arguments");
                        sb.Append(string.Format(downStart, output[++i]));
                        break;
                    case upStart:
                        if (i + 1 >= output.Length)
                            throw new ArgumentException("Invalid number of arguments");
                        sb.Append(string.Format(upStart, output[++i]));
                        break;
                    case column:
                        if (i + 1 >= output.Length)
                            throw new ArgumentException("Invalid number of arguments");
                        sb.Append(string.Format(column, output[++i]));
                        break;
                    case fgColor:
                        if (i + 1 >= output.Length)
                            throw new ArgumentException("Invalid number of arguments");
                        sb.Append(string.Format(fgColor, output[++i]));
                        break;
                    case bgColor:
                        if (i + 1 >= output.Length)
                            throw new ArgumentException("Invalid number of arguments");
                        sb.Append(string.Format(bgColor, output[++i]));
                        break;
                    case fg:
                        if (i + 3 >= output.Length)
                            throw new ArgumentException("Invalid number of arguments");
                        sb.Append(string.Format(fg, output[++i], output[++i], output[++i]));
                        break;
                    case bg:
                        if (i + 3 >= output.Length)
                            throw new ArgumentException("Invalid number of arguments");
                        sb.Append(string.Format(bg, output[++i], output[++i], output[++i]));
                        break;
                    default:
                        sb.Append(s);
                        break;
                }
                continue;
            }
            sb.Append(output[i]);
        }
        return sb;
    }
}

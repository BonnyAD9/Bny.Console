using System.Text;
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

    /// <summary>
    /// Moves cursor to the given position
    /// </summary>
    /// <param name="x">left-right coordinate of the cursor</param>
    /// <param name="y">top-bottom coordinate of the cursor</param>
    public static void Move(int x, int y) => Con.Write(move, x, y);

    /// <summary>
    /// Prepares move code
    /// </summary>
    /// <param name="x">left-right coordinate of the cursor</param>
    /// <param name="y">top-bottom coordinate of the cursor</param>
    /// <returns>Code that will move the cursor to the coordinates</returns>
    public static string PrepareMove(int x, int y) => string.Format(move, x, y);

    /// <summary>
    /// Prints the given block of text at the given coordinates
    /// </summary>
    /// <param name="output">Text to be written</param>
    /// <param name="x">left-right coordinate of the cursor</param>
    /// <param name="y">top-bottom coordinate of the cursor</param>
    public static void FormAt(ReadOnlySpan<string> output, int x, int y) => Con.Write(PrepareAt(output, x, y));

    /// <summary>
    /// Prepares the given block of text at the given coordinates
    /// </summary>
    /// <param name="output">Text to be written</param>
    /// <param name="x">left-right coordinate of the cursor</param>
    /// <param name="y">top-bottom coordinate of the cursor</param>
    /// <returns>string with the prepared text</returns>
    public static string PrepareAt(ReadOnlySpan<string> output, int x, int y) => PrepareAtSB(output, x, y).ToString();

    /// <summary>
    /// Prepares the given block of text at the given coordinates
    /// </summary>
    /// <param name="output">Text to be written</param>
    /// <param name="x">left-right coordinate of the cursor</param>
    /// <param name="y">top-bottom coordinate of the cursor</param>
    /// <returns>StringBuilder with the prepared text</returns>
    public static StringBuilder PrepareAtSB(ReadOnlySpan<string> output, int x, int y)
    {
        StringBuilder sb = new();
        for (int i = 0; i < output.Length; i++)
        {
            sb.Append(PrepareMove(x, i + y));
            sb.Append(output[i]);
        }
        return sb;
    }

    /// <summary>
    /// Prints the given block of text at the given coordinates with style for each line
    /// </summary>
    /// <param name="output">Text to be written</param>
    /// <param name="x">left-right coordinate of the cursor</param>
    /// <param name="y">top-bottom coordinate of the cursor</param>
    /// <param name="style">returns style for the given line</param>
    public static void FormAt(ReadOnlySpan<string> output, int x, int y, Func<int, string> style) => Con.Write(PrepareAt(output, x, y, style).ToString());

    /// <summary>
    /// Prepares the given block of text at the given coordinates with style for each line
    /// </summary>
    /// <param name="output">Text to be written</param>
    /// <param name="x">left-right coordinate of the cursor</param>
    /// <param name="y">top-bottom coordinate of the cursor</param>
    /// <param name="style">returns style for the given line</param>
    /// <returns>string with the prepared text</returns>
    public static string PrepareAt(ReadOnlySpan<string> output, int x, int y, Func<int, string> style) => PrepareAtSB(output, x, y, style).ToString();

    /// <summary>
    /// Prepares the given block of text at the given coordinates with style for each line
    /// </summary>
    /// <param name="output">Text to be written</param>
    /// <param name="x">left-right coordinate of the cursor</param>
    /// <param name="y">top-bottom coordinate of the cursor</param>
    /// <param name="style">returns style for the given line</param>
    /// <returns>StringBuilder with the prepared text</returns>
    public static StringBuilder PrepareAtSB(ReadOnlySpan<string> output, int x, int y, Func<int, string> style)
    {
        StringBuilder sb = new();
        for (int i = 0; i < output.Length; i++)
        {
            sb.Append(PrepareMove(x, i + y));
            sb.Append(style(i));
            sb.Append(output[i]);
        }
        return sb;
    }

    public static void ResetAll() => Form(showCursor, reset);
}

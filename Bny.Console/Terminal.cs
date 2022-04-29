using System.Text;
using Con = System.Console;

namespace Bny.Console;

public partial class Term
{
    public const int maxSize = 999999;

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

    /// <summary>
    /// Resets font style and cursor visibility
    /// </summary>
    public static void ResetAll() => Form(showCursor, reset);

    /// <summary>
    /// Returns the cursor position
    /// </summary>
    /// <returns>position of the cursot (x, y)</returns>
    /// <exception cref="InvalidOperationException">thrown when the terminal doesn't support this</exception>
    public static (int x, int y) GetPosition()
    {
        Con.Write(posReq);

        if (!Con.KeyAvailable)
            throw new InvalidOperationException();

        var str = ReadRaw(true).AsSpan();
        int i = str.IndexOf('\x1b');
        
        if (i == -1)
            throw new InvalidOperationException();

        str = str[i..];
        i = str.IndexOf('R');

        if (i == -1)
            throw new InvalidOperationException();

        str = str[2..i];
        i = str.IndexOf(';');

        if (i == -1)
            throw new InvalidOperationException();

        return (int.Parse(str[(i + 1)..]), int.Parse(str[..i]));
    }

    /// <summary>
    /// Returns the window size, this uses the save command
    /// </summary>
    /// <returns>size of the window (x, y)</returns>
    /// <exception cref="InvalidOperationException">thrown when the terminal doesn't support this</exception>
    public static (int x, int y) GetWindowSize()
    {
        Form(save, move, maxSize, maxSize);
        var ret = GetPosition();
        Form(restore);
        return ret;
    }

    /// <summary>
    /// Skeleton cycle for reading input from console
    /// </summary>
    /// <param name="reader">function for reading the input,
    /// first parameter is key press index,
    /// second parameter is the pressed key,
    /// returns true if next character should be read, otherwise false</param>
    /// <param name="intercept">true = no console output</param>
    /// <returns>number of characters read</returns>
    internal static int ReadSkeleton(Func<int, ConsoleKeyInfo, bool> reader, bool intercept)
    {
        int i = 0;
        try
        {
            for (; reader(i, Con.ReadKey(intercept)); i++) ;
            return i;
        }
        catch (InvalidOperationException)
        {
            return i;
        }
    }

    /// <summary>
    /// Reads all unread input from the console in its raw form
    /// </summary>
    /// <param name="intercept">if true, no characters will be printed</param>
    /// <returns>Readed string</returns>
    public static string ReadRaw(bool intercept)
    {
        StringBuilder sb = new();
        ReadSkeleton((_, cki) =>
        {
            sb.Append(cki.KeyChar);
            return Con.KeyAvailable;
        }, intercept);
        return sb.ToString();
    }

    /// <summary>
    /// Maps characters of postion of the given string builder into new string
    /// </summary>
    /// <param name="str">StringBuilder to map</param>
    /// <param name="map">Map function</param>
    /// <param name="start">Start of the portion</param>
    /// <param name="end">End of the portion</param>
    /// <returns>New string with the mapped portion</returns>
    internal static string CharMap(StringBuilder str, Func<char, char> map, int start, int end)
    {
        StringBuilder sb = new(end - start);
        for (int i = start; i < end; i++)
            sb.Append(map(str[i]));
        return sb.ToString();
    }

    /// <summary>
    /// Reads input from the console, this uses the save command
    /// </summary>
    /// <param name="predicate">Controls the reading,
    /// First parameter is the index of the readed key,
    /// Second parameter is the currently readed key,
    /// Third parameter is what was readed so far</param>
    /// <param name="map">Maps printed characters</param>
    /// <param name="intercept">if true, nothing will be printed</param>
    /// <param name="readLast">indicates whether the last key chould be added to the result string</param>
    /// <param name="edit">this string will be printed and the user can edit it</param>
    /// <param name="pos">position of the cursor in the edit string</param>
    /// <returns>string readed from the console</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when pos is not in the range 0 - edit.Length</exception>
    /// <exception cref="InvalidOperationException">thrown when the terminal doesn't support getting the current cursor position</exception>
    public static string Read(
        Func<int, ConsoleKeyInfo, StringBuilder, (bool, bool)> predicate,
        Func<char, char>? map = null,
        bool intercept = false,
        bool readLast = false,
        string edit = "",
        int pos = 0)
    {
        StringBuilder sb = new(edit);
        if (pos < 0 || pos > edit.Length)
            throw new ArgumentOutOfRangeException(nameof(pos));
        Form(edit, left, edit.Length - pos);
        map ??= c => c;

        bool Intercepted(int i, ConsoleKeyInfo key)
        {
            (bool cont, bool skip) = predicate(i, key, sb);
            if (skip)
                return cont;
            if (!cont && !readLast)
                return false;

            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    if (pos <= 0)
                        break;
                    pos--;
                    break;
                case ConsoleKey.RightArrow:
                    if (pos >= sb.Length)
                        break;
                    pos++;
                    break;
                case ConsoleKey.Backspace:
                    if (pos <= 0)
                        break;
                    sb.Remove(--pos, 1);
                    break;
                case ConsoleKey.Delete:
                    if (pos >= sb.Length)
                        break;
                    sb.Remove(pos, 1);
                    break;
                case ConsoleKey.Home:
                    pos = 0;
                    break;
                case ConsoleKey.End:
                    pos = sb.Length;
                    break;
                default:
                    if (key.KeyChar == '\0')
                        break;
                    sb.Insert(pos++, key.KeyChar);
                    break;
            }

            return cont;
        }

        bool UnIntercepted(int i, ConsoleKeyInfo key)
        {
            (bool cont, bool skip) = predicate(i, key, sb);
            if (skip)
                return cont;
            if (!cont && !readLast)
                return false;
            int x, y;

            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    if (pos <= 0)
                        break;
                    pos--;

                    (x, _) = GetPosition();
                    if (x == 1)
                    {
                        Form(upStart, 0, right, maxSize);
                        break;
                    }
                    Con.Write(left1);
                    break;
                case ConsoleKey.RightArrow:
                    if (pos >= sb.Length)
                        break;
                    pos++;

                    (x, _) = GetPosition();
                    (y, _) = GetWindowSize();
                    if (x == y)
                    {
                        Form(downStart, 0);
                        break;
                    }
                    Con.Write(right1);
                    break;
                case ConsoleKey.Backspace:
                    if (pos <= 0)
                        break;
                    sb.Remove(--pos, 1);

                    (x, _) = GetPosition();
                    if (x == 1)
                        Form(upStart, 0, right, maxSize);
                    else
                        Con.Write(left1);

                    Form(save, CharMap(sb, map, pos, sb.Length), ' ', restore);
                    break;
                case ConsoleKey.Delete:
                    if (pos >= sb.Length)
                        break;
                    sb.Remove(pos, 1);
                    Form(save, CharMap(sb, map, pos, sb.Length), ' ', restore);
                    break;
                case ConsoleKey.Home:
                    Form(left, pos);
                    pos = 0;
                    break;
                case ConsoleKey.End:
                    Form(right, sb.Length - pos);
                    pos = sb.Length;
                    break;
                case ConsoleKey.Enter:
                    break;
                default:
                    if (key.KeyChar == '\0')
                        break;
                    sb.Insert(pos++, key.KeyChar);
                    Con.Write(map(key.KeyChar));
                    if (pos < sb.Length)
                        Form(save, CharMap(sb, map, pos, sb.Length), restore);
                    break;
            }

            return cont;
        }

        ReadSkeleton(intercept ? Intercepted : UnIntercepted, true);
        Con.Write(CharMap(sb, map, pos, sb.Length));
        return sb.ToString();
    }

    /// <summary>
    /// Read text from console
    /// </summary>
    /// <param name="stop">Key that will end the input</param>
    /// <param name="map">Maps the printed characters</param>
    /// <param name="intercept">if true, no characters will be printed</param>
    /// <param name="readLast">Determines whether the last keypress should be readed</param>
    /// <param name="edit">Default text that can be edited</param>
    /// <param name="min">Minimum characters to read</param>
    /// <param name="max">Maximum characters to read</param>
    /// <param name="allowEdit">Determines whether the already typed text can be edited</param>
    /// <param name="pos">Position of cursor in the edit string</param>
    /// <returns>Readed string</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when pos is not in the range 0 - edit.Length</exception>
    /// <exception cref="InvalidOperationException">thrown when the terminal doesn't support getting the current cursor position</exception>
    public static string Read(
        ConsoleKey stop = ConsoleKey.Enter,
        Func<char, char>? map = null,
        bool intercept = false,
        bool readLast = false,
        string edit = "",
        int min = 0,
        int max = int.MaxValue,
        bool allowEdit = true,
        int pos = 0) => Read(
            (_, key, sb) => (key.Key != stop || sb.Length < min, (sb.Length >= max && !IsReadIgnored(key)) || (!allowEdit && IsReadIgnored(key))),
            map: map, intercept: intercept, readLast: readLast, edit: edit, pos: pos);


    /// <summary>
    /// Read text from console
    /// </summary>
    /// <param name="stop">char that will end the input</param>
    /// <param name="map">Maps the printed characters</param>
    /// <param name="intercept">if true, no characters will be printed</param>
    /// <param name="readLast">Determines whether the last keypress should be readed</param>
    /// <param name="edit">Default text that can be edited</param>
    /// <param name="min">Minimum characters to read</param>
    /// <param name="max">Maximum characters to read</param>
    /// <param name="allowEdit">Determines whether the already typed text can be edited</param>
    /// <param name="pos">Position of cursor in the edit string</param>
    /// <returns>Readed string</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when pos is not in the range 0 - edit.Length</exception>
    /// <exception cref="InvalidOperationException">thrown when the terminal doesn't support getting the current cursor position</exception>
    public static string Read(
        char stop,
        Func<char, char>? map = null,
        bool intercept = false,
        bool readLast = false,
        string edit = "",
        int min = 0,
        int max = int.MaxValue,
        bool allowEdit = true,
        int pos = 0) => Read(
            (_, key, sb) => (key.KeyChar != stop || sb.Length < min, (sb.Length >= max && !IsReadIgnored(key)) || (!allowEdit && IsReadIgnored(key))),
            map: map, intercept: intercept, readLast: readLast, edit: edit, pos: pos);

    /// <summary>
    /// Reads the given number of characters from the console
    /// </summary>
    /// <param name="count">Number of characters to read</param>
    /// <param name="map">Maps the printed characters</param>
    /// <param name="intercept">if true, no characters will be printed</param>
    /// <param name="edit">Default text that can be edited</param>
    /// <param name="allowEdit">Determines whether the already typed text can be edited</param>
    /// <param name="pos">Position of the cursor in the edit string</param>
    /// <returns>Readed string</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when pos is not in the range 0 - edit.Length</exception>
    /// <exception cref="InvalidOperationException">thrown when the terminal doesn't support getting the current cursor position</exception>
    public static string Read(
        int count,
        Func<char, char>? map = null,
        bool intercept = false,
        string edit = "",
        bool allowEdit = true,
        int pos = 0)
    {
        if (count == 0)
        {
            Con.Write(edit);
            return "";
        }

        return Read(
            (_, cki, sb) => (sb.Length + 1 < count || IsReadIgnored(cki), !allowEdit && IsReadIgnored(cki)),
            map: map, intercept: intercept, readLast: true, edit: edit, pos: pos);
    }

    /// <summary>
    /// Returns true if the given key wold be ignored by Read or if it would have special use (e. g. backspace)
    /// </summary>
    /// <param name="cki">Key to check</param>
    /// <returns>true if the key wold be ignored, otherwise false</returns>
    public static bool IsReadIgnored(ConsoleKeyInfo cki) => cki.Key is ConsoleKey.Delete or ConsoleKey.Enter or ConsoleKey.Backspace || cki.KeyChar == '\0';

    /// <summary>
    /// Writes the string on the next line
    /// </summary>
    /// <param name="str">string to write</param>
    public static void LineWrite(string str)
    {
        Con.WriteLine();
        Con.Write(str);
    }
}

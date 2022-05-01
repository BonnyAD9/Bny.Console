using System.Drawing;
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
                    case row:
                        if (i + 1 >= output.Length)
                            throw new ArgumentException("Invalid number of arguments");
                        sb.Append(string.Format(row, output[++i]));
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
                    case title:
                        if (i + 1 >= output.Length)
                            throw new ArgumentException("Invalid number of arguments");
                        sb.Append(string.Format(title, output[++i]));
                        break;
                    case scrollDown:
                        if (i + 1 >= output.Length)
                            throw new ArgumentException("Invalid number of arguments");
                        sb.Append(string.Format(scrollDown, output[++i]));
                        break;
                    case scrollUp:
                        if (i + 1 >= output.Length)
                            throw new ArgumentException("Invalid number of arguments");
                        sb.Append(string.Format(scrollUp, output[++i]));
                        break;
                    case insert:
                        if (i + 1 >= output.Length)
                            throw new ArgumentException("Invalid number of arguments");
                        if (output[++i] is string str)
                            sb.Append(string.Format(insert, str.Length)).Append(str);
                        else
                            sb.Append(string.Format(insert, output[i]));
                        break;
                    case remove:
                        if (i + 1 >= output.Length)
                            throw new ArgumentException("Invalid number of arguments");
                        sb.Append(string.Format(remove, output[++i]));
                        break;
                    case eraseX:
                        if (i + 1 >= output.Length)
                            throw new ArgumentException("Invalid number of arguments");
                        sb.Append(string.Format(eraseX, output[++i]));
                        break;
                    case insertLine:
                        if (i + 1 >= output.Length)
                            throw new ArgumentException("Invalid number of arguments");
                        sb.Append(string.Format(insertLine, output[++i]));
                        break;
                    case deleteLine:
                        if (i + 1 >= output.Length)
                            throw new ArgumentException("Invalid number of arguments");
                        sb.Append(string.Format(deleteLine, output[++i]));
                        break;
                    case setColor:
                        if (i + 4 >= output.Length)
                            throw new ArgumentException("Invalid number of arguments");
                        sb.Append(string.Format(setColor, output[++i], output[++i], output[++i], output[++i]));
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
        if (edit.Length - pos != 0)
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
    /// Returns the number of characters that would be printed
    /// </summary>
    /// <param name="s">string to inspect</param>
    /// <returns>number of characters shat would be printed</returns>
    public static int PrintLength(ReadOnlySpan<char> s)
    {
        int c = 0;
        for (int i = 0; i < s.Length; i++)
        {
            switch (s[i])
            {
                case '\a' or  '\b' or '\f' or '\n' or delete:
                    break;
                case escape:
                    if (i + i >= s.Length)
                        break;
                    i++;
                    switch (s[i])
                    {
                        case ']' or 'X' or '^' or '_':
                            for (; i < s.Length && !(s[i] == '\\' && s[i - 1] == escape); i++) ;
                            break;
                        case '[':
                            for (; i < s.Length && (byte)s[i] is < 0x40 or > 0x7E; i++) ;
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    c++;
                    break;
            }
        }
        return c;
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

    /// <summary>
    /// Plays the bell
    /// </summary>
    public static void Bell() => Con.Write(bell);

    /// <summary>
    /// Moves the cursor to the start of the line
    /// </summary>
    public static void Start() => Con.Write(carriageReturn);

    /// <summary>
    /// Moves the cursor to the end of the line
    /// </summary>
    public static void End() => Con.Write(end);

    /// <summary>
    /// Deletes the character under cursor
    /// </summary>
    public static void Delete() => Con.Write(delete);

    /// <summary>
    /// Sets the cursor position to [0, 0]
    /// </summary>
    public static void Home() => Con.Write(home);

    /// <summary>
    /// Moves the cursor x lines up
    /// </summary>
    /// <param name="x">How many lines to move up</param>
    public static void Up(int x) => Con.Write(up, x);

    /// <summary>
    /// Moves the cursor one line up
    /// </summary>
    public static void Up() => Con.Write(up1);

    /// <summary>
    /// Moves the cursor x lines down
    /// </summary>
    /// <param name="x"></param>
    public static void Down(int x) => Con.Write(down, x);

    /// <summary>
    /// Moves the cursor one line down
    /// </summary>
    public static void Down() => Con.Write(down1);

    /// <summary>
    /// Moves the cursor x characters left
    /// </summary>
    /// <param name="x">Number of characters to move</param>
    public static void Left(int x) => Con.Write(left, x);

    /// <summary>
    /// Moves the cursor 1 character left
    /// </summary>
    public static void Left() => Con.Write(left1);

    /// <summary>
    /// Moves the cursor x characters right
    /// </summary>
    /// <param name="x">Number of characters to move</param>
    public static void Right(int x) => Con.Write(right, x);

    /// <summary>
    /// Moves the cursor 1 character right
    /// </summary>
    public static void Right() => Con.Write(right1);

    /// <summary>
    /// Moves cursor to the beggining of next line x lines down (0 is next line)
    /// </summary>
    /// <param name="x">how many lines down to move</param>
    public static void NextLine(int x) => Con.Write(downStart, x);

    /// <summary>
    /// Moves cursor to the beggining of the next line
    /// </summary>
    public static void NextLine() => Con.Write(nextLine);

    /// <summary>
    /// Moves cursor to the beggining of the previous line x lines up
    /// </summary>
    /// <param name="x">how many lines up to move</param>
    public static void PrevLine(int x) => Con.Write(upStart, x);

    /// <summary>
    /// Moves cursor to the beggining of the previous line
    /// </summary>
    public static void PrevLine() => Con.Write(prevLine);

    /// <summary>
    /// Moves cursor to the end of the next line x lines down
    /// </summary>
    /// <param name="x">how many lines to move</param>
    public static void NextEnd(int x) => Con.Write(downEnd, x);

    /// <summary>
    /// Moves cursor to the end of the next line
    /// </summary>
    public static void NextEnd() => Con.Write(nextEnd);

    /// <summary>
    /// Moves cursor to the end of the previous line x lines up
    /// </summary>
    /// <param name="x">how many lines to move</param>
    public static void PrevEnd(int x) => Con.Write(upEnd, x);

    /// <summary>
    /// Moves cursor to the end of the previous line
    /// </summary>
    public static void PrevEnd() => Con.Write(prevEnd);

    /// <summary>
    /// Moves cursor to the specified column
    /// </summary>
    /// <param name="x">column to move to</param>
    public static void Column(int x) => Con.Write(column, x);

    /// <summary>
    /// Moves cursor to the specified row
    /// </summary>
    /// <param name="x">tow to move to</param>
    public static void Row(int x) => Con.Write(row, x);

    /// <summary>
    /// Saves the cursor position
    /// </summary>
    public static void Save() => Con.Write(save);

    /// <summary>
    /// Restores the cursor position
    /// </summary>
    public static void Restore() => Con.Write(restore);

    /// <summary>
    /// Erase from cursor to the end of the screen
    /// </summary>
    public static void EraseFromCursor() => Con.Write(eraseFromCursor);

    /// <summary>
    /// Erase from the start of the screen to the cursor
    /// </summary>
    public static void EraseToCursor() => Con.Write(eraseToCursor);

    /// <summary>
    /// Erase the entire screen
    /// </summary>
    public static void Erase() => Con.Write(erase);

    /// <summary>
    /// Erase line from cursor to the end of the line
    /// </summary>
    public static void EraseLineFromCursor() => Con.Write(eraseLineFromCursor);

    /// <summary>
    /// Erase line from the start to the cursor
    /// </summary>
    public static void EraseLineToCursor() => Con.Write(eraseLineToCursor);

    /// <summary>
    /// Erase the entire line
    /// </summary>
    public static void EraseLine() => Con.Write(eraseLine);

    /// <summary>
    /// Resets the color of the text
    /// </summary>
    public static void ResetColor() => Con.Write(defaultBg + defaultFg);

    /// <summary>
    /// Sets the foreground to the color specified by the color code
    /// </summary>
    /// <param name="colorCode">code of the color</param>
    public static void FgColor(byte colorCode) => Form(fgColor, colorCode);

    /// <summary>
    /// Sets the foreground color
    /// </summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    public static void FgColor(byte r, byte g, byte b) => Form(fg, r, g, b);

    /// <summary>
    /// Sets the foreground color
    /// </summary>
    /// <param name="color">the foreground color</param>
    public static void FgColor(Color color) => Form(fg, color.R, color.G, color.B);

    /// <summary>
    /// Sets the background to the color specified by the color code
    /// </summary>
    /// <param name="colorCode">code of the color</param>
    public static void BgColor(byte colorCode) => Form(bgColor, colorCode);

    /// <summary>
    /// Sets the background color
    /// </summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    public static void BgColor(byte r, byte g, byte b) => Form(bg, r, g, b);

    /// <summary>
    /// Sets the background color
    /// </summary>
    /// <param name="color">the foreground color</param>
    public static void BgColor(Color color) => Form(bg, color.R, color.G, color.B);

    /// <summary>
    /// Hides the cursor
    /// </summary>
    public static void HideCursor() => Con.Write(hideCursor);

    /// <summary>
    /// Shows the cursor
    /// </summary>
    public static void ShowCursor() => Con.Write(showCursor);

    /// <summary>
    /// Sets the window title
    /// </summary>
    /// <param name="str">the new title</param>
    public static void Title(string str) => Con.Write(title, str);

    /// <summary>
    /// Scrolls up by x lines
    /// </summary>
    /// <param name="x">how much to scroll up</param>
    public static void ScrollUp(int x) => Con.Write(scrollUp, x);

    /// <summary>
    /// Scrolls down by x lines
    /// </summary>
    /// <param name="x">how much to scroll down</param>
    public static void ScrollDown(int x) => Con.Write(scrollDown, x);

    /// <summary>
    /// Inserts x characters
    /// </summary>
    /// <param name="x">number of characters to insert</param>
    public static void Insert(int x) => Con.Write(insert, x);

    /// <summary>
    /// Inserts string
    /// </summary>
    /// <param name="str">string to insert</param>
    public static void Insert(string str) => Form(insert, str);

    /// <summary>
    /// Removes x characters
    /// </summary>
    /// <param name="x">number of characters to remove</param>
    public static void Remove(int x) => Con.Write(remove, x);

    /// <summary>
    /// Erases x characters to the right
    /// </summary>
    /// <param name="x">number of characters to erase</param>
    public static void Erase(int x) => Con.Write(eraseX, x);

    /// <summary>
    /// Inserts x lines
    /// </summary>
    /// <param name="x">number of lines to insert</param>
    public static void InsertLine(int x) => Con.Write(insertLine, x);

    /// <summary>
    /// Deletes x lines
    /// </summary>
    /// <param name="x">number of lines to delete</param>
    public static void DeleteLine(int x) => Con.Write(deleteLine, x);
}

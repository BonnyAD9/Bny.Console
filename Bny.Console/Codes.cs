namespace Bny.Console;

public partial class Term
{
    /// <summary>
    /// Terminal bell
    /// </summary>
    public const char bell = '\a';
    /// <summary>
    /// Backspace
    /// </summary>
    public const char backspace = '\b';
    /// <summary>
    /// Horizontal TAB
    /// </summary>
    public const char horizontalTab = '\t';
    /// <summary>
    /// Linefeed (newline)
    /// </summary>
    public const char newline = '\n';
    /// <summary>
    /// Vertical TAB
    /// </summary>
    public const char verticalTab = '\v';
    /// <summary>
    /// Formfeed (also: New page NP)
    /// </summary>
    public const char formfeed = '\f';
    /// <summary>
    /// Carriage return
    /// </summary>
    public const char carriageReturn = '\r';
    /// <summary>
    /// Escape character
    /// </summary>
    public const char escape = '\x1b';
    /// <summary>
    /// Delete character
    /// </summary>
    public const char delete = '\x7f';

    /// <summary>
    /// Moves cursor to position [0, 0]
    /// </summary>
    public const string home = "\x1b[H";
    /// <summary>
    /// Moves cursor to position [{0}, {1}]
    /// </summary>
    public const string move = "\x1b[{0};{1}H";
    /// <summary>
    /// Moves cursor {0} lines up
    /// </summary>
    public const string up = "\x1b[{0}A";
    /// <summary>
    /// Moves cursor {0} lines down
    /// </summary>
    public const string down = "\x1b[{0}B";
    /// <summary>
    /// Moves cursor {0} columns right
    /// </summary>
    public const string right = "\x1b[{0}C";
    /// <summary>
    /// Moves cursor {0} columns left
    /// </summary>
    public const string left = "\x1b[{0}D";
    /// <summary>
    /// Moves cursor to beginning of next line {0} lines down
    /// </summary>
    public const string downStart = "\x1b[{0}E";
    /// <summary>
    /// Moves cursor to beginning of previous line {0} lines up
    /// </summary>
    public const string upStart = "\x1b[{0}F";
    /// <summary>
    /// Moves cursor to column {0}
    /// </summary>
    public const string column = "\x1b[{0}G";
    /// <summary>
    /// Requests cursor position (reported as "\x1b[{0};{1}R")
    /// </summary>
    public const string posReq = "\x1b[6n";
    /// <summary>
    /// Moves cursor one line up, scrolling if needed
    /// </summary>
    public const string up1 = "\x1bM";
    /// <summary>
    /// Saves cursor position (DEC)
    /// </summary>
    public const string save = "\u001b7";
    /// <summary>
    /// Restores cursor position (DEC)
    /// </summary>
    public const string restore = "\u001b8";
    /// <summary>
    /// Saves cursor position (SCO)
    /// </summary>
    public const string saveSCO = "\x1b[s";
    /// <summary>
    /// Restores cursor position (SCO)
    /// </summary>
    public const string restoreSCO = "\x1b[u";
    /// <summary>
    /// Erase from cursor to the end of the screen
    /// </summary>
    public const string eraseFromCursor = "\x1b[J";
    /// <summary>
    /// Erase from cursor to begginning of the screen
    /// </summary>
    public const string eraseToCursor = "\x1b[1J";
    /// <summary>
    /// Erase entire screen
    /// </summary>
    public const string erase = "\x1b[2J";
    /// <summary>
    /// Erase saved lines
    /// </summary>
    public const string eraseLines = "\x1b[3J";
    /// <summary>
    /// Erase from cursor to end of line
    /// </summary>
    public const string eraseLineFromCursor = "\x1b[K";
    /// <summary>
    /// Erase start of line to the cursor
    /// </summary>
    public const string eraseLineToCursor = "\x1b[1K";
    /// <summary>
    /// Erase the entire line
    /// </summary>
    public const string eraseLine = "\x1b[2K";

    /// <summary>
    /// Bold/bright mode
    /// </summary>
    public const string bold = "\x1b[1m";
    /// <summary>
    /// Dim/faint mode
    /// </summary>
    public const string faint = "\x1b[2m";
    /// <summary>
    /// Italic mode
    /// </summary>
    public const string italic = "\x1b[3m";
    /// <summary>
    /// Underline mode
    /// </summary>
    public const string underline = "\x1b[4m";
    /// <summary>
    /// Blinking mode
    /// </summary>
    public const string blinking = "\x1b[5m";
    /// <summary>
    /// Inverse/reverse mode
    /// </summary>
    public const string inverse = "\x1b[7m";
    /// <summary>
    /// Hidden/invisible mode
    /// </summary>
    public const string hidden = "\x1b[8m";
    /// <summary>
    /// Striketrough mode
    /// </summary>
    public const string strikethrough = "\x1b[8m";
    /// <summary>
    /// Double underline
    /// </summary>
    public const string underline2 = "\x1b[21m";
    /// <summary>
    /// Overline
    /// </summary>
    public const string overline = "\x1b[53m";

    /// <summary>
    /// Resets all modes and color
    /// </summary>
    public const string reset = "\x1b[0m";
    /// <summary>
    /// Resets bold and dim mode
    /// </summary>
    public const string resetBoldDim = "\x1b[22m";
    /// <summary>
    /// Resets italic mode
    /// </summary>
    public const string resetItalic = "\x1b[23m";
    /// <summary>
    /// Resets underline and double underline mode
    /// </summary>
    public const string resetUnderline = "\x1b[24m";
    /// <summary>
    /// Resets blinking mode
    /// </summary>
    public const string resetBlinking = "\x1b[25m";
    /// <summary>
    /// Resets inverse/reverse mode
    /// </summary>
    public const string resetInverse = "\x1b[27m";
    /// <summary>
    /// Resets hidden/invisible mode
    /// </summary>
    public const string resetHidden = "\x1b[28m";
    /// <summary>
    /// Resets striketrough mode
    /// </summary>
    public const string resetStriketrough = "\x1b[29m";
    /// <summary>
    /// Resets overline mode
    /// </summary>
    public const string resetOverline = "\x1b[29m";

    /// <summary>
    /// Sets the foreground color to the default color
    /// </summary>
    public const string defaultFg = "\x1b[39m";
    /// <summary>
    /// Sets the background color to the default color
    /// </summary>
    public const string defaultBg = "\x1b[49m";

    /// <summary>
    /// Sets foreground color to black
    /// </summary>
    public const string black = "\x1b[30m";
    /// <summary>
    /// Sets foreground color to red
    /// </summary>
    public const string red = "\x1b[31m";
    /// <summary>
    /// Sets foreground color to green
    /// </summary>
    public const string green = "\x1b[32m";
    /// <summary>
    /// Sets foreground color to yellow
    /// </summary>
    public const string yellow = "\x1b[33m";
    /// <summary>
    /// Sets foreground color to blue
    /// </summary>
    public const string blue = "\x1b[34m";
    /// <summary>
    /// Sets foreground color to magenta
    /// </summary>
    public const string magenta = "\x1b[35m";
    /// <summary>
    /// Sets foreground color to cyan
    /// </summary>
    public const string cyan = "\x1b[36m";
    /// <summary>
    /// Sets foreground color to white
    /// </summary>
    public const string white = "\x1b[37m";

    /// <summary>
    /// Sets foreground color to bright black
    /// </summary>
    public const string brightBlack = "\x1b[90m";
    /// <summary>
    /// Sets foreground color to bright black
    /// </summary>
    public const string brightRed = "\x1b[91m";
    /// <summary>
    /// Sets foreground color to bright green
    /// </summary>
    public const string brightGreen = "\x1b[92m";
    /// <summary>
    /// Sets foreground color to bright yellow
    /// </summary>
    public const string brightYellow = "\x1b[93m";
    /// <summary>
    /// Sets foreground color to bright blue
    /// </summary>
    public const string brightBlue = "\x1b[94m";
    /// <summary>
    /// Sets foreground color to bright magenta
    /// </summary>
    public const string brightMagenta = "\x1b[95m";
    /// <summary>
    /// Sets foreground color to bright cyan
    /// </summary>
    public const string brightCyan = "\x1b[96m";
    /// <summary>
    /// Sets foreground color to bright white
    /// </summary>
    public const string brightWhite = "\x1b[97m";

    /// <summary>
    /// Sets background color to black
    /// </summary>
    public const string blackBg = "\x1b[40m";
    /// <summary>
    /// Sets background color to red
    /// </summary>
    public const string redBg = "\x1b[41m";
    /// <summary>
    /// Sets background color to green
    /// </summary>
    public const string greenBg = "\x1b[42m";
    /// <summary>
    /// Sets background color to yellow
    /// </summary>
    public const string yellowBg = "\x1b[43m";
    /// <summary>
    /// Sets background color to blue
    /// </summary>
    public const string blueBg = "\x1b[44m";
    /// <summary>
    /// Sets background color to magenta
    /// </summary>
    public const string magentaBg = "\x1b[45m";
    /// <summary>
    /// Sets background color to cyan
    /// </summary>
    public const string cyanBg = "\x1b[46m";
    /// <summary>
    /// Sets background color to white
    /// </summary>
    public const string whiteBg = "\x1b[47m";

    /// <summary>
    /// Sets background color to bright bright black
    /// </summary>
    public const string brightBlackBg = "\x1b[100m";
    /// <summary>
    /// Sets background color to bright bright black
    /// </summary>
    public const string brightRedBg = "\x1b[101m";
    /// <summary>
    /// Sets background color to bright bright green
    /// </summary>
    public const string brightGreenBg = "\x1b[102m";
    /// <summary>
    /// Sets background color to bright bright yellow
    /// </summary>
    public const string brightYellowBg = "\x1b[103m";
    /// <summary>
    /// Sets background color to bright bright blue
    /// </summary>
    public const string brightBlueBg = "\x1b[104m";
    /// <summary>
    /// Sets background color to bright bright magenta
    /// </summary>
    public const string brightMagentaBg = "\x1b[105m";
    /// <summary>
    /// Sets background color to bright bright cyan
    /// </summary>
    public const string brightCyanBg = "\x1b[106m";
    /// <summary>
    /// Sets background color to bright bright white
    /// </summary>
    public const string brightWhiteBg = "\x1b[107m";

    /// <summary>
    /// Sets the foreground color bysed on id {0} in range 0 - 255
    /// </summary>
    public const string fgColor = "\x1b[38;5;{0}m";
    /// <summary>
    /// Sets the background color bysed on id {0} in range 0 - 255
    /// </summary>
    public const string bgColor = "\x1b[48;5;{0}m";

    /// <summary>
    /// Sets the foreground color with standard RGB [{0}, {1}, {2}]
    /// </summary>
    public const string fg = "\x1b[38;2;{0};{1};{2}m";
    /// <summary>
    /// Sets the background color with standard RGB [{0}, {1}, {2}]
    /// </summary>
    public const string bg = "\x1b[48;2;{0};{1};{2}m";

    /// <summary>
    /// Hides the cursor
    /// </summary>
    public const string hideCursor = "\x1b[?25l";
    /// <summary>
    /// Shows the cursor
    /// </summary>
    public const string showCursor = "\x1b[?25h";
    /// <summary>
    /// Restores saved screen (doesn't work in Windows Terminal)
    /// </summary>
    public const string restoreScreen = "\x1b[?47l";
    /// <summary>
    /// Saves screen (doesn't work in Windows Terminal)
    /// </summary>
    public const string saveScreen = "\x1b[?47h";
    /// <summary>
    /// Enables alternative buffer (doesn't work in Windows Terminal)
    /// </summary>
    public const string altBufferOn = "\x1b[?47h";
    /// <summary>
    /// Disables alternative buffer (doesn't work in Windows Terminal)
    /// </summary>
    public const string altBufferOff = "\x1b[?47l";
}

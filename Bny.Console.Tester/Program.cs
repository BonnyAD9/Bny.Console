using Bny.Console;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

string[] str = new string[] {
    @"  ______   ______     ______     ______  ",
    @" /\__  _\ /\  ___\   /\  ___\   /\__  _\ ",
    @" \/_/\ \/ \ \  __\   \ \___  \  \/_/\ \/ ",
    @"    \ \_\  \ \_____\  \/\_____\    \ \_\ ",
    @"     \/_/   \/_____/   \/_____/     \/_/ ",
};

Term.FormAt(str.AsSpan(), 40, 12, i => Term.Prepare(Term.fg, 230 - i * 7, 55, 150 + i * 15));
Term.Form(Term.hideCursor);
Console.ReadLine();
Term.ResetAll();
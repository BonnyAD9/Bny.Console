# Bny.Console
Improves working with console using ANSI escape codes

## Examples

### Printing
This example shows printing colorful ascii art text into console.

#### Code
```[C#]
// import
using Bny.Console;

// prepare text to print
string[] str = new string[] {
    @"  ______   ______     ______     ______  ",
    @" /\__  _\ /\  ___\   /\  ___\   /\__  _\ ",
    @" \/_/\ \/ \ \  __\   \ \___  \  \/_/\ \/ ",
    @"    \ \_\  \ \_____\  \/\_____\    \ \_\ ",
    @"     \/_/   \/_____/   \/_____/     \/_/ ",
};

// print the text at coordinates [40, 12]
// the color for each line is created using the index of the line with the Term.Prepare static method
Term.FormAt(str.AsSpan(), 40, 12, i => Term.Prepare(Term.fg, 230 - i * 7, 55, 150 + i * 15));
// hide the cursor
Term.Form(Term.hideCursor);
// wait for enter
Console.ReadLine();
// reset font style and cursor visibility
Term.ResetAll();
```

#### Output
![image](https://user-images.githubusercontent.com/46282097/165509389-6fe02667-4557-473e-958c-d78c8cb75ced.png)
Output is shown in windows terminal before the enter was pressed

### Reading
This example shows how to read secret text from console limited by length

#### Code
```[C#]
using Bny.Console;

// Read from console
// map maps the printed characters,
// if you don't want to print any characters, you can use 'intercept: true'
// min and max speicies the minimal and maximal length of readed input
// pressing enter before the given limit won't do anything
// characters after the 64 are ignored and not printed, but you can still edit what you entered
string s = Term.Read(map: _ => '*', min: 8, max: 64);
// this will write newline before the given string
// Term.Read doesn't jump to the next line
Term.LineWrite(s);
```

#### Output
```
****************************************************************
if this was shorter than 8 characters, pressing enter wouldn't w
```

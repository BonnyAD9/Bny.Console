using Bny.Console;

for (int i = 0; i < 255; i += 8)
{
    for (int j = 0; j < 255; j += 4)
        Term.Form(Term.bgRGB, i, 0, j, ' ');
    Term.FormLine(Term.reset);
}
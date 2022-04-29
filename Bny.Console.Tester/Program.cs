using Bny.Console;

string s = Term.Read(map: _ => '*', min: 8, max: 64);
Term.LineWrite(s);
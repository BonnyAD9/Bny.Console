using Bny.Console;

Term.Title("ahoj");
Term.Form("alkajsdhfalkjdhf");
Thread.Sleep(1000);
Term.Read(max: 0, intercept: true);
Term.Form("\u001bc");
Term.Read(max: 0);

/*string s = Term.Read(map: _ => '*', min: 8, max: 64);
Term.LineWrite(s);*/
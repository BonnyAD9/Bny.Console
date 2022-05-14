using Bny.Console;

Term.Read("0123456789", 5, invert: true, prompt: "Enter number a: " + Term.brightYellow, next: Term.defaultFg + '\n');
Term.Read("0123456789", 1, prompt: "Enter nonnumber b: " + Term.brightYellow, next: Term.defaultFg + '\n');
Term.Read(max: 0);
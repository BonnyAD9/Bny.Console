namespace Bny.Console;

public partial class Term
{
    public virtual TextWriter Out { get; set; }
    public virtual TextReader In { get; set; }

    public Term(TextWriter @out, TextReader @in)
    {
        Out = @out;
        In = @in;
    }
}

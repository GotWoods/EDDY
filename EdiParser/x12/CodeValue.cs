//TODO: use this for code lookups
//it would allow to use the Provided Code if it was a standard code that is an enum
//if it was something out of spec, you could still get the value from the CustomValue field?

public class CodeValue<T>
{
    public T ProvidedCode { get; set; }
    public string CustomValue { get; set; }
}
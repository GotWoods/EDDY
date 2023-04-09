using EdiParser.Validation;

namespace EdiParser.x12.Models;

public class Unkown_Segment : EdiX12Segment
{
    public string RawData { get; set; }
    public override ValidationResult Validate()
    {
        return new ValidationResult();
    }
}
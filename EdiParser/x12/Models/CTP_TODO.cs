using EdiParser.Attributes;
using EdiParser.Validation;

namespace EdiParser.x12.Models;

//TODO: Auto generate is not working on this one
[Segment("CTP")]
public class CTP_TODO : EdiX12Segment
{
    public override ValidationResult Validate()
    {
        throw new System.NotImplementedException();
    }
}
using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

//TODO: Auto generate is not working on this one
[Segment("CTP")]
public class CTP_TODO : EdiX12Segment
{
    public override ValidationResult Validate()
    {
        throw new System.NotImplementedException();
    }
}
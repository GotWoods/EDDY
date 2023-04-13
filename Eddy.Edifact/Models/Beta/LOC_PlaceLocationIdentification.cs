using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.Elements;

namespace Eddy.Edifact.Models.Beta;

public class LOC_PlaceLocationIdentification 
{
    [Position(1)]
    public string LocationFunctionCodeQualifier { get; set; }

    [Position(2)]
    public C517_LocationIdentification LocationIdentification { get; set; }

    [Position(3)]
    public C519_RelatedLocationOneIdentification RelatedLocationOneIdentification { get; set; }

    [Position(4)]
    public C553_RelatedLocationTwoIdentification RelatedLocationTwoIdentification { get; set; }

    [Position(5)]
    public string RelationCode { get; set; }

    public void Validate()
    {
        var validator = new BasicValidator<LOC_PlaceLocationIdentification> (this);
        validator.Length(x => x.LocationFunctionCodeQualifier, 1, 3);
        validator.Length(x => x.RelationCode, 1, 3);
    }
}
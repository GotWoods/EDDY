using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4040;

[Segment("LOD")]
public class LOD_LocationDescription : EdiX12Segment
{
	[Position(01)]
	public string GeneralTerritoryCode { get; set; }

	[Position(02)]
	public string ConditionIndicator { get; set; }

	[Position(03)]
	public string FreeFormMessage { get; set; }

	[Position(04)]
	public string ThoroughfareTypeQualifier { get; set; }

	[Position(05)]
	public string ThoroughfareTypeCode { get; set; }

	[Position(06)]
	public string FreeFormMessage2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LOD_LocationDescription>(this);
		validator.OnlyOneOf(x=>x.GeneralTerritoryCode, x=>x.FreeFormMessage);
		validator.ARequiresB(x=>x.ConditionIndicator, x=>x.GeneralTerritoryCode);
		validator.ARequiresB(x=>x.ThoroughfareTypeQualifier, x=>x.ThoroughfareTypeCode);
		validator.OnlyOneOf(x=>x.ThoroughfareTypeCode, x=>x.FreeFormMessage2);
		validator.Length(x => x.GeneralTerritoryCode, 1, 2);
		validator.Length(x => x.ConditionIndicator, 2, 3);
		validator.Length(x => x.FreeFormMessage, 1, 30);
		validator.Length(x => x.ThoroughfareTypeQualifier, 1);
		validator.Length(x => x.ThoroughfareTypeCode, 1);
		validator.Length(x => x.FreeFormMessage2, 1, 30);
		return validator.Results;
	}
}

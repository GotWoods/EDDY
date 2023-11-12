using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("PDR")]
public class PDR_PropertyDescriptionReal : EdiX12Segment
{
	[Position(01)]
	public string TypeOfRealEstateAssetCode { get; set; }

	[Position(02)]
	public string CodeListQualifierCode { get; set; }

	[Position(03)]
	public string IndustryCode { get; set; }

	[Position(04)]
	public string OccupancyCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PDR_PropertyDescriptionReal>(this);
		validator.Required(x=>x.TypeOfRealEstateAssetCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.CodeListQualifierCode, x=>x.IndustryCode);
		validator.Length(x => x.TypeOfRealEstateAssetCode, 2);
		validator.Length(x => x.CodeListQualifierCode, 1, 3);
		validator.Length(x => x.IndustryCode, 1, 30);
		validator.Length(x => x.OccupancyCode, 2);
		return validator.Results;
	}
}

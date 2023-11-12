using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7060.Composites;

namespace Eddy.x12.Models.v7060;

[Segment("REG")]
public class REG_RegulatoryApplication : EdiX12Segment
{
	[Position(01)]
	public string RegulatoryType { get; set; }

	[Position(02)]
	public string CountryCode { get; set; }

	[Position(03)]
	public C069_CompositeStateOrProvinceCode CompositeStateOrProvinceCode { get; set; }

	[Position(04)]
	public string YesNoConditionOrResponseCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<REG_RegulatoryApplication>(this);
		validator.Required(x=>x.RegulatoryType);
		validator.AtLeastOneIsRequired(x=>x.CountryCode, x=>x.CompositeStateOrProvinceCode);
		validator.Length(x => x.RegulatoryType, 2);
		validator.Length(x => x.CountryCode, 2, 3);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		return validator.Results;
	}
}

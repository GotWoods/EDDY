using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("TOA")]
public class TOA_TypeOfActivity : EdiX12Segment
{
	[Position(01)]
	public string TypeOfActivityCode { get; set; }

	[Position(02)]
	public string LicenseTypeCode { get; set; }

	[Position(03)]
	public string StatusCode { get; set; }

	[Position(04)]
	public string TypeOfRatingCode { get; set; }

	[Position(05)]
	public string TypeOfRatingCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TOA_TypeOfActivity>(this);
		validator.Required(x=>x.TypeOfActivityCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.LicenseTypeCode, x=>x.StatusCode);
		validator.Length(x => x.TypeOfActivityCode, 2);
		validator.Length(x => x.LicenseTypeCode, 2);
		validator.Length(x => x.StatusCode, 2);
		validator.Length(x => x.TypeOfRatingCode, 2);
		validator.Length(x => x.TypeOfRatingCode2, 2);
		return validator.Results;
	}
}

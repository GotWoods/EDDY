using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("DEF")]
public class DEF_DefermentInformation : EdiX12Segment
{
	[Position(01)]
	public string DefermentTypeCode { get; set; }

	[Position(02)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(03)]
	public string DateTimePeriod { get; set; }

	[Position(04)]
	public string InterestPaymentCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DEF_DefermentInformation>(this);
		validator.Required(x=>x.DefermentTypeCode);
		validator.Required(x=>x.DateTimePeriodFormatQualifier);
		validator.Required(x=>x.DateTimePeriod);
		validator.Length(x => x.DefermentTypeCode, 1, 2);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.InterestPaymentCode, 1, 2);
		return validator.Results;
	}
}

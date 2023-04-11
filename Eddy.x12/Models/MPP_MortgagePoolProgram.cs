using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("MPP")]
public class MPP_MortgagePoolProgram : EdiX12Segment
{
	[Position(01)]
	public string CodeCategory { get; set; }

	[Position(02)]
	public string ProgramTypeCode { get; set; }

	[Position(03)]
	public string DateTimeQualifier { get; set; }

	[Position(04)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(05)]
	public string DateTimePeriod { get; set; }

	[Position(06)]
	public decimal? MonetaryAmount { get; set; }

	[Position(07)]
	public string AccrualRateMethodCode { get; set; }

	[Position(08)]
	public string CertificationTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MPP_MortgagePoolProgram>(this);
		validator.Required(x=>x.CodeCategory);
		validator.Required(x=>x.ProgramTypeCode);
		validator.Length(x => x.CodeCategory, 2);
		validator.Length(x => x.ProgramTypeCode, 2);
		validator.Length(x => x.DateTimeQualifier, 3);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.AccrualRateMethodCode, 1);
		validator.Length(x => x.CertificationTypeCode, 1);
		return validator.Results;
	}
}

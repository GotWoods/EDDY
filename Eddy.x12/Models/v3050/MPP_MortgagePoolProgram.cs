using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

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
		return validator.Results;
	}
}

using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("MIS")]
public class MIS_MortgageeInformationStatus : EdiX12Segment
{
	[Position(01)]
	public string MortgageeInformationStatusCode { get; set; }

	[Position(02)]
	public string DateTimeQualifier { get; set; }

	[Position(03)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(04)]
	public string DateTimePeriod { get; set; }

	[Position(05)]
	public string JurisdictionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MIS_MortgageeInformationStatus>(this);
		validator.Required(x=>x.MortgageeInformationStatusCode);
		validator.Length(x => x.MortgageeInformationStatusCode, 2);
		validator.Length(x => x.DateTimeQualifier, 3);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.JurisdictionCode, 3);
		return validator.Results;
	}
}

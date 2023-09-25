using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("SMC")]
public class SMC_CustomerInformation : EdiX12Segment
{
	[Position(01)]
	public string ReciprocalSwitchCode { get; set; }

	[Position(02)]
	public string MarksAndNumbersQualifier { get; set; }

	[Position(03)]
	public string AddressInformation { get; set; }

	[Position(04)]
	public string SwitchingZoneIdentifier { get; set; }

	[Position(05)]
	public string ServiceRestrictionInformation { get; set; }

	[Position(06)]
	public string Date { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SMC_CustomerInformation>(this);
		validator.Required(x=>x.ReciprocalSwitchCode);
		validator.Required(x=>x.MarksAndNumbersQualifier);
		validator.Length(x => x.ReciprocalSwitchCode, 1);
		validator.Length(x => x.MarksAndNumbersQualifier, 1, 2);
		validator.Length(x => x.AddressInformation, 1, 35);
		validator.Length(x => x.SwitchingZoneIdentifier, 1, 3);
		validator.Length(x => x.ServiceRestrictionInformation, 1, 25);
		validator.Length(x => x.Date, 6);
		return validator.Results;
	}
}

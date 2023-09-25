using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("MSS")]
public class MSS_MaterialSafetyDataSheetSectionInformation : EdiX12Segment
{
	[Position(01)]
	public string ReportSectionNameCode { get; set; }

	[Position(02)]
	public string Description { get; set; }

	[Position(03)]
	public string StateOrProvinceCode { get; set; }

	[Position(04)]
	public string CountryCode { get; set; }

	[Position(05)]
	public string ChangeTypeCode { get; set; }

	[Position(06)]
	public string ReportSectionNumber { get; set; }

	[Position(07)]
	public string SafetyCharacteristicHazardCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MSS_MaterialSafetyDataSheetSectionInformation>(this);
		validator.OnlyOneOf(x=>x.ReportSectionNameCode, x=>x.ReportSectionNumber);
		validator.Length(x => x.ReportSectionNameCode, 2);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.CountryCode, 2, 3);
		validator.Length(x => x.ChangeTypeCode, 1);
		validator.Length(x => x.ReportSectionNumber, 1, 15);
		validator.Length(x => x.SafetyCharacteristicHazardCode, 3);
		return validator.Results;
	}
}

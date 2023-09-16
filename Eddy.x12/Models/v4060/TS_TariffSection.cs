using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4060;

[Segment("TS")]
public class TS_TariffSection : EdiX12Segment
{
	[Position(01)]
	public string TariffSectionIdentifier { get; set; }

	[Position(02)]
	public string TariffItemNumber { get; set; }

	[Position(03)]
	public string TariffItemSuffix { get; set; }

	[Position(04)]
	public string TariffSectionIDCode { get; set; }

	[Position(05)]
	public string RateValueQualifier { get; set; }

	[Position(06)]
	public string EquipmentDescriptionCode { get; set; }

	[Position(07)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TS_TariffSection>(this);
		validator.Length(x => x.TariffSectionIdentifier, 1, 4);
		validator.Length(x => x.TariffItemNumber, 1, 16);
		validator.Length(x => x.TariffItemSuffix, 1, 4);
		validator.Length(x => x.TariffSectionIDCode, 2);
		validator.Length(x => x.RateValueQualifier, 2);
		validator.Length(x => x.EquipmentDescriptionCode, 2);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}

using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4050;

[Segment("SWD")]
public class SWD_SwitchingDetails : EdiX12Segment
{
	[Position(01)]
	public string InvoiceNumber { get; set; }

	[Position(02)]
	public decimal? Weight { get; set; }

	[Position(03)]
	public string TariffApplicationCode { get; set; }

	[Position(04)]
	public string ApplicationErrorConditionCode { get; set; }

	[Position(05)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(06)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	[Position(07)]
	public string IndustryCode { get; set; }

	[Position(08)]
	public int? Number { get; set; }

	[Position(09)]
	public int? Number2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SWD_SwitchingDetails>(this);
		validator.Length(x => x.InvoiceNumber, 1, 22);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.TariffApplicationCode, 1);
		validator.Length(x => x.ApplicationErrorConditionCode, 1, 3);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.IndustryCode, 1, 30);
		validator.Length(x => x.Number, 1, 9);
		validator.Length(x => x.Number2, 1, 9);
		return validator.Results;
	}
}

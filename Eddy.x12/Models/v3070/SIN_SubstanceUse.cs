using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("SIN")]
public class SIN_SubstanceUse : EdiX12Segment
{
	[Position(01)]
	public string InformationStatusCode { get; set; }

	[Position(02)]
	public string ControlledSubstanceTypeCode { get; set; }

	[Position(03)]
	public string FreeFormMessageText { get; set; }

	[Position(04)]
	public string FrequencyCode { get; set; }

	[Position(05)]
	public decimal? Quantity { get; set; }

	[Position(06)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SIN_SubstanceUse>(this);
		validator.Required(x=>x.InformationStatusCode);
		validator.AtLeastOneIsRequired(x=>x.ControlledSubstanceTypeCode, x=>x.FreeFormMessageText);
		validator.Length(x => x.InformationStatusCode, 1);
		validator.Length(x => x.ControlledSubstanceTypeCode, 2);
		validator.Length(x => x.FreeFormMessageText, 1, 264);
		validator.Length(x => x.FrequencyCode, 1);
		validator.Length(x => x.Quantity, 1, 15);
		return validator.Results;
	}
}

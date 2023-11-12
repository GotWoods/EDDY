using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8010.Composites;

namespace Eddy.x12.Models.v8010;

[Segment("SPT")]
public class SPT_SpiritAndLiqueurInformation : EdiX12Segment
{
	[Position(01)]
	public string SpiritTypeCode { get; set; }

	[Position(02)]
	public string SpiritStyle { get; set; }

	[Position(03)]
	public string Color { get; set; }

	[Position(04)]
	public string LiqueurFlavor { get; set; }

	[Position(05)]
	public C075_CompositeAddedFlavor CompositeAddedFlavor { get; set; }

	[Position(06)]
	public string DistilledFromSpiritType { get; set; }

	[Position(07)]
	public string WhiskeyProductionType { get; set; }

	[Position(08)]
	public string YesNoConditionOrResponseCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SPT_SpiritAndLiqueurInformation>(this);
		validator.Required(x=>x.SpiritTypeCode);
		validator.Length(x => x.SpiritTypeCode, 2, 3);
		validator.Length(x => x.SpiritStyle, 2, 3);
		validator.Length(x => x.Color, 2, 3);
		validator.Length(x => x.LiqueurFlavor, 2);
		validator.Length(x => x.DistilledFromSpiritType, 2);
		validator.Length(x => x.WhiskeyProductionType, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		return validator.Results;
	}
}

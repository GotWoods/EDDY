using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("BW")]
public class BW_BeginningSegmentForWeightMessageSet : EdiX12Segment
{
	[Position(01)]
	public string OriginEDICarrierCode { get; set; }

	[Position(02)]
	public string ShipmentIdentificationNumber { get; set; }

	[Position(03)]
	public string WeightUnitCode { get; set; }

	[Position(04)]
	public string ShipmentWeightCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BW_BeginningSegmentForWeightMessageSet>(this);
		validator.Required(x=>x.OriginEDICarrierCode);
		validator.Required(x=>x.WeightUnitCode);
		validator.Required(x=>x.ShipmentWeightCode);
		validator.Length(x => x.OriginEDICarrierCode, 2, 4);
		validator.Length(x => x.ShipmentIdentificationNumber, 1, 30);
		validator.Length(x => x.WeightUnitCode, 1);
		validator.Length(x => x.ShipmentWeightCode, 1);
		return validator.Results;
	}
}

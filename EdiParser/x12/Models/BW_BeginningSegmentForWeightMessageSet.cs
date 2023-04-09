using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("BW")]
public class BW_BeginningSegmentForWeightMessageSet : EdiX12Segment
{
	[Position(01)]
	public string OriginEDICarrierCode { get; set; }

	[Position(02)]
	public string ShipmentIdentificationNumber { get; set; }

	[Position(03)]
	public string WeightUnitCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BW_BeginningSegmentForWeightMessageSet>(this);
		validator.Required(x=>x.OriginEDICarrierCode);
		validator.Required(x=>x.WeightUnitCode);
		validator.Length(x => x.OriginEDICarrierCode, 2, 4);
		validator.Length(x => x.ShipmentIdentificationNumber, 1, 30);
		validator.Length(x => x.WeightUnitCode, 1);
		return validator.Results;
	}
}

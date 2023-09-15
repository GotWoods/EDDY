using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("BSN")]
public class BSN_BeginningSegmentForShipNotice : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(02)]
	public string ShipmentIdentification { get; set; }

	[Position(03)]
	public string Date { get; set; }

	[Position(04)]
	public string Time { get; set; }

	[Position(05)]
	public string HierarchicalStructureCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BSN_BeginningSegmentForShipNotice>(this);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Required(x=>x.ShipmentIdentification);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.Time);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.ShipmentIdentification, 2, 30);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Time, 4, 6);
		validator.Length(x => x.HierarchicalStructureCode, 4);
		return validator.Results;
	}
}

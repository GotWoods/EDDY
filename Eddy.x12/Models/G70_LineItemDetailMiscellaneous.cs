using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("G70")]
public class G70_LineItemDetailMiscellaneous : EdiX12Segment
{
	[Position(01)]
	public int? Pack { get; set; }

	[Position(02)]
	public decimal? Size { get; set; }

	[Position(03)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(04)]
	public string PurchaseOrderInstructionCode { get; set; }

	[Position(05)]
	public string PriceReasonCode { get; set; }

	[Position(06)]
	public string TermsExceptionCode { get; set; }

	[Position(07)]
	public string TaxExemptCode { get; set; }

	[Position(08)]
	public string Color { get; set; }

	[Position(09)]
	public int? PalletBlockAndTiers { get; set; }

	[Position(10)]
	public int? InnerPack { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G70_LineItemDetailMiscellaneous>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Size, x=>x.UnitOrBasisForMeasurementCode);
		validator.Length(x => x.Pack, 1, 6);
		validator.Length(x => x.Size, 1, 8);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.PurchaseOrderInstructionCode, 2);
		validator.Length(x => x.PriceReasonCode, 1);
		validator.Length(x => x.TermsExceptionCode, 2);
		validator.Length(x => x.TaxExemptCode, 1);
		validator.Length(x => x.Color, 1, 10);
		validator.Length(x => x.PalletBlockAndTiers, 6);
		validator.Length(x => x.InnerPack, 1, 6);
		return validator.Results;
	}
}

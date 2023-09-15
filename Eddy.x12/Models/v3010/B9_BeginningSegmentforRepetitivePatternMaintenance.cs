using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("B9")]
public class B9_BeginningSegmentForRepetitivePatternMaintenance : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetIdentifierCode { get; set; }

	[Position(02)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(03)]
	public string StandardPointLocationCode { get; set; }

	[Position(04)]
	public int? RepetitivePatternNumber { get; set; }

	[Position(05)]
	public string ReferencedPatternIdentifier { get; set; }

	[Position(06)]
	public string PatternFunctionCode { get; set; }

	[Position(07)]
	public string EffectiveDate { get; set; }

	[Position(08)]
	public string ShipmentMethodOfPayment { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<B9_BeginningSegmentForRepetitivePatternMaintenance>(this);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Required(x=>x.StandardPointLocationCode);
		validator.Required(x=>x.PatternFunctionCode);
		validator.Required(x=>x.EffectiveDate);
		validator.Length(x => x.TransactionSetIdentifierCode, 3);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.StandardPointLocationCode, 6, 9);
		validator.Length(x => x.RepetitivePatternNumber, 5);
		validator.Length(x => x.ReferencedPatternIdentifier, 1, 13);
		validator.Length(x => x.PatternFunctionCode, 1);
		validator.Length(x => x.EffectiveDate, 6);
		validator.Length(x => x.ShipmentMethodOfPayment, 2);
		return validator.Results;
	}
}

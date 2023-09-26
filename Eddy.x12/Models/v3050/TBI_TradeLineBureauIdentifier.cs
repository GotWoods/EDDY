using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("TBI")]
public class TBI_TradeLineBureauIdentifier : EdiX12Segment
{
	[Position(01)]
	public string IdentificationCode { get; set; }

	[Position(02)]
	public string ReferenceNumber { get; set; }

	[Position(03)]
	public string ReferenceNumber2 { get; set; }

	[Position(04)]
	public string ReferenceNumber3 { get; set; }

	[Position(05)]
	public string ReferenceNumber4 { get; set; }

	[Position(06)]
	public string ReferenceNumber5 { get; set; }

	[Position(07)]
	public string ReferenceNumber6 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TBI_TradeLineBureauIdentifier>(this);
		validator.Length(x => x.IdentificationCode, 2, 20);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.ReferenceNumber2, 1, 30);
		validator.Length(x => x.ReferenceNumber3, 1, 30);
		validator.Length(x => x.ReferenceNumber4, 1, 30);
		validator.Length(x => x.ReferenceNumber5, 1, 30);
		validator.Length(x => x.ReferenceNumber6, 1, 30);
		return validator.Results;
	}
}

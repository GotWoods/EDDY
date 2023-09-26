using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5030;

[Segment("TBI")]
public class TBI_TradeLineBureauIdentifier : EdiX12Segment
{
	[Position(01)]
	public string IdentificationCode { get; set; }

	[Position(02)]
	public string ReferenceIdentification { get; set; }

	[Position(03)]
	public string ReferenceIdentification2 { get; set; }

	[Position(04)]
	public string ReferenceIdentification3 { get; set; }

	[Position(05)]
	public string ReferenceIdentification4 { get; set; }

	[Position(06)]
	public string ReferenceIdentification5 { get; set; }

	[Position(07)]
	public string ReferenceIdentification6 { get; set; }

	[Position(08)]
	public string ReferenceIdentification7 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TBI_TradeLineBureauIdentifier>(this);
		validator.Length(x => x.IdentificationCode, 2, 80);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.ReferenceIdentification2, 1, 80);
		validator.Length(x => x.ReferenceIdentification3, 1, 80);
		validator.Length(x => x.ReferenceIdentification4, 1, 80);
		validator.Length(x => x.ReferenceIdentification5, 1, 80);
		validator.Length(x => x.ReferenceIdentification6, 1, 80);
		validator.Length(x => x.ReferenceIdentification7, 1, 80);
		return validator.Results;
	}
}

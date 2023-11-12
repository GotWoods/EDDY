using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("MOA")]
public class MOA_MedicareOutpatientAdjudication : EdiX12Segment
{
	[Position(01)]
	public decimal? Percent { get; set; }

	[Position(02)]
	public decimal? MonetaryAmount { get; set; }

	[Position(03)]
	public string ReferenceNumber { get; set; }

	[Position(04)]
	public string ReferenceNumber2 { get; set; }

	[Position(05)]
	public string ReferenceNumber3 { get; set; }

	[Position(06)]
	public string ReferenceNumber4 { get; set; }

	[Position(07)]
	public string ReferenceNumber5 { get; set; }

	[Position(08)]
	public decimal? MonetaryAmount2 { get; set; }

	[Position(09)]
	public decimal? MonetaryAmount3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MOA_MedicareOutpatientAdjudication>(this);
		validator.Length(x => x.Percent, 1, 10);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.ReferenceNumber2, 1, 30);
		validator.Length(x => x.ReferenceNumber3, 1, 30);
		validator.Length(x => x.ReferenceNumber4, 1, 30);
		validator.Length(x => x.ReferenceNumber5, 1, 30);
		validator.Length(x => x.MonetaryAmount2, 1, 15);
		validator.Length(x => x.MonetaryAmount3, 1, 15);
		return validator.Results;
	}
}

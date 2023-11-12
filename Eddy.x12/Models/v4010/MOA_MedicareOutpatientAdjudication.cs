using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("MOA")]
public class MOA_MedicareOutpatientAdjudication : EdiX12Segment
{
	[Position(01)]
	public decimal? Percent { get; set; }

	[Position(02)]
	public decimal? MonetaryAmount { get; set; }

	[Position(03)]
	public string ReferenceIdentification { get; set; }

	[Position(04)]
	public string ReferenceIdentification2 { get; set; }

	[Position(05)]
	public string ReferenceIdentification3 { get; set; }

	[Position(06)]
	public string ReferenceIdentification4 { get; set; }

	[Position(07)]
	public string ReferenceIdentification5 { get; set; }

	[Position(08)]
	public decimal? MonetaryAmount2 { get; set; }

	[Position(09)]
	public decimal? MonetaryAmount3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MOA_MedicareOutpatientAdjudication>(this);
		validator.Length(x => x.Percent, 1, 10);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		validator.Length(x => x.ReferenceIdentification2, 1, 30);
		validator.Length(x => x.ReferenceIdentification3, 1, 30);
		validator.Length(x => x.ReferenceIdentification4, 1, 30);
		validator.Length(x => x.ReferenceIdentification5, 1, 30);
		validator.Length(x => x.MonetaryAmount2, 1, 18);
		validator.Length(x => x.MonetaryAmount3, 1, 18);
		return validator.Results;
	}
}

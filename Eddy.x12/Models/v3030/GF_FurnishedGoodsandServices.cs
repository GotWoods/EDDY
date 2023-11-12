using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("GF")]
public class GF_FurnishedGoodsAndServices : EdiX12Segment
{
	[Position(01)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(02)]
	public string ReferenceNumber { get; set; }

	[Position(03)]
	public string ContractNumber { get; set; }

	[Position(04)]
	public decimal? MonetaryAmount { get; set; }

	[Position(05)]
	public string ReferenceNumberQualifier2 { get; set; }

	[Position(06)]
	public string ReferenceNumber2 { get; set; }

	[Position(07)]
	public string ReleaseNumber { get; set; }

	[Position(08)]
	public string ReferenceNumberQualifier3 { get; set; }

	[Position(09)]
	public string ReferenceNumber3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<GF_FurnishedGoodsAndServices>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceNumberQualifier, x=>x.ReferenceNumber);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceNumberQualifier2, x=>x.ReferenceNumber2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceNumberQualifier3, x=>x.ReferenceNumber3);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.ContractNumber, 1, 30);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.ReferenceNumberQualifier2, 2);
		validator.Length(x => x.ReferenceNumber2, 1, 30);
		validator.Length(x => x.ReleaseNumber, 1, 30);
		validator.Length(x => x.ReferenceNumberQualifier3, 2);
		validator.Length(x => x.ReferenceNumber3, 1, 30);
		return validator.Results;
	}
}

using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("GF")]
public class GF_FurnishedGoodsAndServices : EdiX12Segment
{
	[Position(01)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(02)]
	public string ReferenceIdentification { get; set; }

	[Position(03)]
	public string ContractNumber { get; set; }

	[Position(04)]
	public decimal? MonetaryAmount { get; set; }

	[Position(05)]
	public string ReferenceIdentificationQualifier2 { get; set; }

	[Position(06)]
	public string ReferenceIdentification2 { get; set; }

	[Position(07)]
	public string ReleaseNumber { get; set; }

	[Position(08)]
	public string ReferenceIdentificationQualifier3 { get; set; }

	[Position(09)]
	public string ReferenceIdentification3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<GF_FurnishedGoodsAndServices>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentificationQualifier, x=>x.ReferenceIdentification);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentificationQualifier2, x=>x.ReferenceIdentification2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentificationQualifier3, x=>x.ReferenceIdentification3);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.ContractNumber, 1, 30);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.ReferenceIdentificationQualifier2, 2, 3);
		validator.Length(x => x.ReferenceIdentification2, 1, 80);
		validator.Length(x => x.ReleaseNumber, 1, 30);
		validator.Length(x => x.ReferenceIdentificationQualifier3, 2, 3);
		validator.Length(x => x.ReferenceIdentification3, 1, 80);
		return validator.Results;
	}
}

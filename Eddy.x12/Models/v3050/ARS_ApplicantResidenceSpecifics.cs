using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("ARS")]
public class ARS_ApplicantResidenceSpecifics : EdiX12Segment
{
	[Position(01)]
	public string TypeOfResidenceCode { get; set; }

	[Position(02)]
	public string PropertyOwnershipRightsCode { get; set; }

	[Position(03)]
	public string RateValueQualifier { get; set; }

	[Position(04)]
	public decimal? MonetaryAmount { get; set; }

	[Position(05)]
	public string ReferenceNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ARS_ApplicantResidenceSpecifics>(this);
		validator.Required(x=>x.TypeOfResidenceCode);
		validator.Required(x=>x.PropertyOwnershipRightsCode);
		validator.Length(x => x.TypeOfResidenceCode, 1);
		validator.Length(x => x.PropertyOwnershipRightsCode, 1);
		validator.Length(x => x.RateValueQualifier, 2);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		return validator.Results;
	}
}

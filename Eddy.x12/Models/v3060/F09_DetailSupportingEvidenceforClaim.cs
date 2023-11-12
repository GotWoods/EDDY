using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("F09")]
public class F09_DetailSupportingEvidenceForClaim : EdiX12Segment
{
	[Position(01)]
	public decimal? Quantity { get; set; }

	[Position(02)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(03)]
	public string NatureOfClaimCode { get; set; }

	[Position(04)]
	public string Amount { get; set; }

	[Position(05)]
	public string Amount2 { get; set; }

	[Position(06)]
	public string Description { get; set; }

	[Position(07)]
	public string LadingDescription { get; set; }

	[Position(08)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(09)]
	public string ReferenceIdentification { get; set; }

	[Position(10)]
	public string ReferenceIdentificationQualifier2 { get; set; }

	[Position(11)]
	public string ReferenceIdentification2 { get; set; }

	[Position(12)]
	public int? LadingLineItemNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<F09_DetailSupportingEvidenceForClaim>(this);
		validator.Required(x=>x.Quantity);
		validator.Required(x=>x.UnitOrBasisForMeasurementCode);
		validator.Required(x=>x.NatureOfClaimCode);
		validator.Required(x=>x.Amount);
		validator.Required(x=>x.Amount2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentificationQualifier, x=>x.ReferenceIdentification);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentificationQualifier2, x=>x.ReferenceIdentification2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.NatureOfClaimCode, 2);
		validator.Length(x => x.Amount, 1, 15);
		validator.Length(x => x.Amount2, 1, 15);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.LadingDescription, 1, 50);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		validator.Length(x => x.ReferenceIdentificationQualifier2, 2, 3);
		validator.Length(x => x.ReferenceIdentification2, 1, 30);
		validator.Length(x => x.LadingLineItemNumber, 1, 3);
		return validator.Results;
	}
}

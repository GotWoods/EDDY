using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("F03")]
public class F03_DetailSupportingEvidenceForClaim : EdiX12Segment
{
	[Position(01)]
	public decimal? Quantity { get; set; }

	[Position(02)]
	public string UnitOfMeasurementCode { get; set; }

	[Position(03)]
	public string LadingDescription { get; set; }

	[Position(04)]
	public string NatureOfClaimCode { get; set; }

	[Position(05)]
	public string Amount { get; set; }

	[Position(06)]
	public string Amount2 { get; set; }

	[Position(07)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(08)]
	public string ReferenceNumber { get; set; }

	[Position(09)]
	public string ReferenceNumberQualifier2 { get; set; }

	[Position(10)]
	public string ReferenceNumber2 { get; set; }

	[Position(11)]
	public string NatureOfClaimCode2 { get; set; }

	[Position(12)]
	public string FreeFormDescription { get; set; }

	[Position(13)]
	public string LadingDescription2 { get; set; }

	[Position(14)]
	public string PackagingCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<F03_DetailSupportingEvidenceForClaim>(this);
		validator.Required(x=>x.Quantity);
		validator.Required(x=>x.UnitOfMeasurementCode);
		validator.Required(x=>x.LadingDescription);
		validator.Required(x=>x.NatureOfClaimCode);
		validator.Required(x=>x.Amount);
		validator.Required(x=>x.Amount2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceNumberQualifier, x=>x.ReferenceNumber);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceNumberQualifier2, x=>x.ReferenceNumber2);
		validator.Required(x=>x.NatureOfClaimCode2);
		validator.Required(x=>x.LadingDescription2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.UnitOfMeasurementCode, 2);
		validator.Length(x => x.LadingDescription, 1, 50);
		validator.Length(x => x.NatureOfClaimCode, 2);
		validator.Length(x => x.Amount, 1, 9);
		validator.Length(x => x.Amount2, 1, 9);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.ReferenceNumberQualifier2, 2);
		validator.Length(x => x.ReferenceNumber2, 1, 30);
		validator.Length(x => x.NatureOfClaimCode2, 2);
		validator.Length(x => x.FreeFormDescription, 1, 45);
		validator.Length(x => x.LadingDescription2, 1, 50);
		validator.Length(x => x.PackagingCode, 5);
		return validator.Results;
	}
}

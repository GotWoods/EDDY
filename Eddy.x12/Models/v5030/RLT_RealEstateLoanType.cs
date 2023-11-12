using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5030.Composites;

namespace Eddy.x12.Models.v5030;

[Segment("RLT")]
public class RLT_RealEstateLoanType : EdiX12Segment
{
	[Position(01)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(02)]
	public string ReferenceIdentification { get; set; }

	[Position(03)]
	public string ReferenceIdentificationQualifier2 { get; set; }

	[Position(04)]
	public string ReferenceIdentification2 { get; set; }

	[Position(05)]
	public string RealEstateLoanTypeCode { get; set; }

	[Position(06)]
	public string LoanPaymentTypeCode { get; set; }

	[Position(07)]
	public string QuantityQualifier { get; set; }

	[Position(08)]
	public decimal? Quantity { get; set; }

	[Position(09)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure { get; set; }

	[Position(10)]
	public string ReferenceIdentificationQualifier3 { get; set; }

	[Position(11)]
	public string ReferenceIdentification3 { get; set; }

	[Position(12)]
	public string ProgramTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RLT_RealEstateLoanType>(this);
		validator.Required(x=>x.ReferenceIdentificationQualifier);
		validator.Required(x=>x.ReferenceIdentification);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentificationQualifier2, x=>x.ReferenceIdentification2);
		validator.ARequiresB(x=>x.ReferenceIdentification3, x=>x.ReferenceIdentificationQualifier3);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.ReferenceIdentificationQualifier2, 2, 3);
		validator.Length(x => x.ReferenceIdentification2, 1, 80);
		validator.Length(x => x.RealEstateLoanTypeCode, 1);
		validator.Length(x => x.LoanPaymentTypeCode, 2);
		validator.Length(x => x.QuantityQualifier, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.ReferenceIdentificationQualifier3, 2, 3);
		validator.Length(x => x.ReferenceIdentification3, 1, 80);
		validator.Length(x => x.ProgramTypeCode, 2);
		return validator.Results;
	}
}

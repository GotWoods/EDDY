using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("RLT")]
public class RLT_RealEstateLoanType : EdiX12Segment
{
	[Position(01)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(02)]
	public string ReferenceNumber { get; set; }

	[Position(03)]
	public string ReferenceNumberQualifier2 { get; set; }

	[Position(04)]
	public string ReferenceNumber2 { get; set; }

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
	public string ReferenceNumberQualifier3 { get; set; }

	[Position(11)]
	public string ReferenceNumber3 { get; set; }

	[Position(12)]
	public string ProgramTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RLT_RealEstateLoanType>(this);
		validator.Required(x=>x.ReferenceNumberQualifier);
		validator.Required(x=>x.ReferenceNumber);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceNumberQualifier2, x=>x.ReferenceNumber2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceNumberQualifier3, x=>x.ReferenceNumber3);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.ReferenceNumberQualifier2, 2);
		validator.Length(x => x.ReferenceNumber2, 1, 30);
		validator.Length(x => x.RealEstateLoanTypeCode, 1);
		validator.Length(x => x.LoanPaymentTypeCode, 2);
		validator.Length(x => x.QuantityQualifier, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.ReferenceNumberQualifier3, 2);
		validator.Length(x => x.ReferenceNumber3, 1, 30);
		validator.Length(x => x.ProgramTypeCode, 2);
		return validator.Results;
	}
}

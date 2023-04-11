using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("INC")]
public class INC_InstallmentInformation : EdiX12Segment
{
	[Position(01)]
	public string TermsTypeCode { get; set; }

	[Position(02)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure { get; set; }

	[Position(03)]
	public decimal? Quantity { get; set; }

	[Position(04)]
	public decimal? Quantity2 { get; set; }

	[Position(05)]
	public decimal? MonetaryAmount { get; set; }

	[Position(06)]
	public string AmountQualifierCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<INC_InstallmentInformation>(this);
		validator.Required(x=>x.TermsTypeCode);
		validator.Required(x=>x.CompositeUnitOfMeasure);
		validator.Required(x=>x.Quantity);
		validator.IfOneIsFilled_AllAreRequired(x=>x.MonetaryAmount, x=>x.AmountQualifierCode);
		validator.Length(x => x.TermsTypeCode, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.Quantity2, 1, 15);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.AmountQualifierCode, 1, 3);
		return validator.Results;
	}
}

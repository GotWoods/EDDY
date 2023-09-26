using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4030;

[Segment("TDT")]
public class TDT_TaxDelinquencyStatus : EdiX12Segment
{
	[Position(01)]
	public string RealEstateTaxDelinquencyTypeCode { get; set; }

	[Position(02)]
	public string ReferenceIdentification { get; set; }

	[Position(03)]
	public string StatusCode { get; set; }

	[Position(04)]
	public string ActionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TDT_TaxDelinquencyStatus>(this);
		validator.Required(x=>x.RealEstateTaxDelinquencyTypeCode);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Length(x => x.RealEstateTaxDelinquencyTypeCode, 1, 2);
		validator.Length(x => x.ReferenceIdentification, 1, 50);
		validator.Length(x => x.StatusCode, 2);
		validator.Length(x => x.ActionCode, 1, 2);
		return validator.Results;
	}
}

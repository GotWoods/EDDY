using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("DN")]
public class DN_DealerEffectivity : EdiX12Segment
{
	[Position(01)]
	public string DateQualifier { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string DemandArea { get; set; }

	[Position(04)]
	public string FinancialStatus { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DN_DealerEffectivity>(this);
		validator.Required(x=>x.DateQualifier);
		validator.Required(x=>x.Date);
		validator.Length(x => x.DateQualifier, 2);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.DemandArea, 3);
		validator.Length(x => x.FinancialStatus, 3);
		return validator.Results;
	}
}

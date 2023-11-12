using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("W22")]
public class W22_TransactionDateAndTime : EdiX12Segment
{
	[Position(01)]
	public string BeginningDate { get; set; }

	[Position(02)]
	public string ThruDate { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<W22_TransactionDateAndTime>(this);
		validator.Required(x=>x.BeginningDate);
		validator.Required(x=>x.ThruDate);
		validator.Length(x => x.BeginningDate, 6);
		validator.Length(x => x.ThruDate, 6);
		return validator.Results;
	}
}

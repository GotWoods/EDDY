using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("S303")]
public class S303_TransactionReference : EdifactComponent
{
	[Position(1)]
	public string TransactionControlReference { get; set; }

	[Position(2)]
	public string InitiatorReferenceIdentification { get; set; }

	[Position(3)]
	public string ControllingAgencyCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<S303_TransactionReference>(this);
		validator.Required(x=>x.TransactionControlReference);
		validator.Length(x => x.TransactionControlReference, 1, 35);
		validator.Length(x => x.InitiatorReferenceIdentification, 1, 35);
		validator.Length(x => x.ControllingAgencyCoded, 1, 3);
		return validator.Results;
	}
}

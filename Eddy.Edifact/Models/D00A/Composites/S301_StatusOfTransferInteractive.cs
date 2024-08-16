using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("S301")]
public class S301_StatusOfTransferInteractive : EdifactComponent
{
	[Position(1)]
	public string SenderSequenceNumber { get; set; }

	[Position(2)]
	public string TransferPositionCoded { get; set; }

	[Position(3)]
	public string DuplicateIndicator { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<S301_StatusOfTransferInteractive>(this);
		validator.Length(x => x.SenderSequenceNumber, 1, 6);
		validator.Length(x => x.TransferPositionCoded, 1);
		validator.Length(x => x.DuplicateIndicator, 1);
		return validator.Results;
	}
}

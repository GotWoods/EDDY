using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("IT")]
public class IT_InterconnectMailbagTrailer : EdiX12Segment
{
	[Position(01)]
	public int? InterconnectMailbagControlNumber { get; set; }

	[Position(02)]
	public int? InterconnectMailbagAcknowledgmentCount { get; set; }

	[Position(03)]
	public int? InterconnectMailbagInterchangeCount { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<IT_InterconnectMailbagTrailer>(this);
		validator.Required(x=>x.InterconnectMailbagControlNumber);
		validator.Required(x=>x.InterconnectMailbagAcknowledgmentCount);
		validator.Required(x=>x.InterconnectMailbagInterchangeCount);
		validator.Length(x => x.InterconnectMailbagControlNumber, 1, 9);
		validator.Length(x => x.InterconnectMailbagAcknowledgmentCount, 1, 4);
		validator.Length(x => x.InterconnectMailbagInterchangeCount, 1, 5);
		return validator.Results;
	}
}

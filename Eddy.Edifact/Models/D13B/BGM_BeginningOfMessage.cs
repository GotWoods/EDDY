using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D13B.Composites;

namespace Eddy.Edifact.Models.D13B;

[Segment("BGM")]
public class BGM_BeginningOfMessage : EdifactSegment
{
	[Position(1)]
	public C002_DocumentMessageName DocumentMessageName { get; set; }

	[Position(2)]
	public C106_DocumentMessageIdentification DocumentMessageIdentification { get; set; }

	[Position(3)]
	public string MessageFunctionCode { get; set; }

	[Position(4)]
	public string ResponseTypeCode { get; set; }

	[Position(5)]
	public string DocumentStatusCode { get; set; }

	[Position(6)]
	public string LanguageNameCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BGM_BeginningOfMessage>(this);
		validator.Length(x => x.MessageFunctionCode, 1, 3);
		validator.Length(x => x.ResponseTypeCode, 1, 3);
		validator.Length(x => x.DocumentStatusCode, 1, 3);
		validator.Length(x => x.LanguageNameCode, 1, 3);
		return validator.Results;
	}
}

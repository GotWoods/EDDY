using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("E972")]
public class E972_MessageProcessingDetails : EdifactComponent
{
	[Position(1)]
	public string BusinessFunctionCode { get; set; }

	[Position(2)]
	public string MessageFunctionCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string MessageFunctionCode2 { get; set; }

	[Position(5)]
	public string MessageFunctionCode3 { get; set; }

	[Position(6)]
	public string MessageFunctionCode4 { get; set; }

	[Position(7)]
	public string MessageFunctionCode5 { get; set; }

	[Position(8)]
	public string MessageFunctionCode6 { get; set; }

	[Position(9)]
	public string MessageFunctionCode7 { get; set; }

	[Position(10)]
	public string MessageFunctionCode8 { get; set; }

	[Position(11)]
	public string MessageFunctionCode9 { get; set; }

	[Position(12)]
	public string MessageFunctionCode10 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E972_MessageProcessingDetails>(this);
		validator.Length(x => x.BusinessFunctionCode, 1, 3);
		validator.Length(x => x.MessageFunctionCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.MessageFunctionCode2, 1, 3);
		validator.Length(x => x.MessageFunctionCode3, 1, 3);
		validator.Length(x => x.MessageFunctionCode4, 1, 3);
		validator.Length(x => x.MessageFunctionCode5, 1, 3);
		validator.Length(x => x.MessageFunctionCode6, 1, 3);
		validator.Length(x => x.MessageFunctionCode7, 1, 3);
		validator.Length(x => x.MessageFunctionCode8, 1, 3);
		validator.Length(x => x.MessageFunctionCode9, 1, 3);
		validator.Length(x => x.MessageFunctionCode10, 1, 3);
		return validator.Results;
	}
}

using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D97B.Composites;

[Segment("E972")]
public class E972_MessageProcessingDetails : EdifactComponent
{
	[Position(1)]
	public string BusinessFunctionCoded { get; set; }

	[Position(2)]
	public string MessageFunctionCoded { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string MessageFunctionCoded2 { get; set; }

	[Position(5)]
	public string MessageFunctionCoded3 { get; set; }

	[Position(6)]
	public string MessageFunctionCoded4 { get; set; }

	[Position(7)]
	public string MessageFunctionCoded5 { get; set; }

	[Position(8)]
	public string MessageFunctionCoded6 { get; set; }

	[Position(9)]
	public string MessageFunctionCoded7 { get; set; }

	[Position(10)]
	public string MessageFunctionCoded8 { get; set; }

	[Position(11)]
	public string MessageFunctionCoded9 { get; set; }

	[Position(12)]
	public string MessageFunctionCoded10 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E972_MessageProcessingDetails>(this);
		validator.Length(x => x.BusinessFunctionCoded, 1, 3);
		validator.Length(x => x.MessageFunctionCoded, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.MessageFunctionCoded2, 1, 3);
		validator.Length(x => x.MessageFunctionCoded3, 1, 3);
		validator.Length(x => x.MessageFunctionCoded4, 1, 3);
		validator.Length(x => x.MessageFunctionCoded5, 1, 3);
		validator.Length(x => x.MessageFunctionCoded6, 1, 3);
		validator.Length(x => x.MessageFunctionCoded7, 1, 3);
		validator.Length(x => x.MessageFunctionCoded8, 1, 3);
		validator.Length(x => x.MessageFunctionCoded9, 1, 3);
		validator.Length(x => x.MessageFunctionCoded10, 1, 3);
		return validator.Results;
	}
}

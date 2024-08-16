using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00B.Composites;

[Segment("E021")]
public class E021_Service : EdifactComponent
{
	[Position(1)]
	public string ProductIdentifier { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string ProcedureModificationCode { get; set; }

	[Position(4)]
	public string ProcedureModificationCode2 { get; set; }

	[Position(5)]
	public string ProcedureModificationCode3 { get; set; }

	[Position(6)]
	public string ProcedureModificationCode4 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E021_Service>(this);
		validator.Required(x=>x.ProductIdentifier);
		validator.Length(x => x.ProductIdentifier, 1, 35);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.ProcedureModificationCode, 1, 3);
		validator.Length(x => x.ProcedureModificationCode2, 1, 3);
		validator.Length(x => x.ProcedureModificationCode3, 1, 3);
		validator.Length(x => x.ProcedureModificationCode4, 1, 3);
		return validator.Results;
	}
}

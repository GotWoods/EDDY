using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C332")]
public class C332_SalesChannelIdentification : EdifactComponent
{
	[Position(1)]
	public string SalesChannelIdentifier { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C332_SalesChannelIdentification>(this);
		validator.Required(x=>x.SalesChannelIdentifier);
		validator.Length(x => x.SalesChannelIdentifier, 1, 17);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		return validator.Results;
	}
}

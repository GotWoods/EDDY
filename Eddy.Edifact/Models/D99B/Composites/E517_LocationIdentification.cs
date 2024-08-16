using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("E517")]
public class E517_LocationIdentification : EdifactComponent
{
	[Position(1)]
	public string LocationNameCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string LocationName { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E517_LocationIdentification>(this);
		validator.Length(x => x.LocationNameCode, 1, 25);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.LocationName, 1, 256);
		return validator.Results;
	}
}

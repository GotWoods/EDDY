using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C040")]
public class C040_Carrier : EdifactComponent
{
	[Position(1)]
	public string CarrierIdentification { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string CarrierName { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C040_Carrier>(this);
		validator.Length(x => x.CarrierIdentification, 1, 17);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.CarrierName, 1, 35);
		return validator.Results;
	}
}
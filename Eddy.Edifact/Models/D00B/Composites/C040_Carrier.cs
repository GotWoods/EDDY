using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00B.Composites;

[Segment("C040")]
public class C040_Carrier : EdifactComponent
{
	[Position(1)]
	public string CarrierIdentifier { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string CarrierName { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C040_Carrier>(this);
		validator.Length(x => x.CarrierIdentifier, 1, 17);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.CarrierName, 1, 35);
		return validator.Results;
	}
}

using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040.Composites;

namespace Eddy.x12.Models.v4040;

[Segment("PRV")]
public class PRV_ProviderInformation : EdiX12Segment
{
	[Position(01)]
	public string ProviderCode { get; set; }

	[Position(02)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(03)]
	public string ReferenceIdentification { get; set; }

	[Position(04)]
	public string StateOrProvinceCode { get; set; }

	[Position(05)]
	public C035_ProviderSpecialtyInformation ProviderSpecialtyInformation { get; set; }

	[Position(06)]
	public string ProviderOrganizationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PRV_ProviderInformation>(this);
		validator.Required(x=>x.ProviderCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentificationQualifier, x=>x.ReferenceIdentification);
		validator.Length(x => x.ProviderCode, 1, 3);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 50);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.ProviderOrganizationCode, 3);
		return validator.Results;
	}
}

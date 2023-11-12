using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("PRV")]
public class PRV_ProviderInformation : EdiX12Segment
{
	[Position(01)]
	public string ProviderCode { get; set; }

	[Position(02)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(03)]
	public string ReferenceNumber { get; set; }

	[Position(04)]
	public string StateOrProvinceCode { get; set; }

	[Position(05)]
	public string AgencyQualifierCode { get; set; }

	[Position(06)]
	public string ProviderSpecialtyCode { get; set; }

	[Position(07)]
	public string ProviderOrganizationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PRV_ProviderInformation>(this);
		validator.Required(x=>x.ProviderCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.AgencyQualifierCode, x=>x.ProviderSpecialtyCode);
		validator.Required(x=>x.ReferenceNumberQualifier);
		validator.Required(x=>x.ReferenceNumber);
		validator.Length(x => x.ProviderCode, 1, 3);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.AgencyQualifierCode, 2);
		validator.Length(x => x.ProviderSpecialtyCode, 1, 3);
		validator.Length(x => x.ProviderOrganizationCode, 3);
		return validator.Results;
	}
}

using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v6010;

[Segment("LIC")]
public class LIC_LicenseInformation : EdiX12Segment
{
	[Position(01)]
	public string StateOrProvinceCode { get; set; }

	[Position(02)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(03)]
	public string ProductServiceID { get; set; }

	[Position(04)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(05)]
	public string StatusCode { get; set; }

	[Position(06)]
	public string ReferenceIdentification { get; set; }

	[Position(07)]
	public string StateOrProvinceCode2 { get; set; }

	[Position(08)]
	public string ReferenceIdentification2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LIC_LicenseInformation>(this);
		validator.Required(x=>x.StateOrProvinceCode);
		validator.Required(x=>x.ProductServiceIDQualifier);
		validator.Required(x=>x.ProductServiceID);
		validator.Required(x=>x.YesNoConditionOrResponseCode);
		validator.Required(x=>x.StatusCode);
		validator.ARequiresB(x=>x.ReferenceIdentification2, x=>x.StateOrProvinceCode2);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 80);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.StatusCode, 2);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.StateOrProvinceCode2, 2);
		validator.Length(x => x.ReferenceIdentification2, 1, 80);
		return validator.Results;
	}
}

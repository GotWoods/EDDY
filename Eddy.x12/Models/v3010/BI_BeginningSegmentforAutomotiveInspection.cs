using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("BI")]
public class BI_BeginningSegmentForAutomotiveInspection : EdiX12Segment
{
	[Position(01)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string InspectionLocationTypeCode { get; set; }

	[Position(04)]
	public string RampIdentification { get; set; }

	[Position(05)]
	public string CityName { get; set; }

	[Position(06)]
	public string StateOrProvinceCode { get; set; }

	[Position(07)]
	public string InspectorIdentityCode { get; set; }

	[Position(08)]
	public string DamageCodeQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BI_BeginningSegmentForAutomotiveInspection>(this);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.InspectionLocationTypeCode);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.InspectionLocationTypeCode, 1, 2);
		validator.Length(x => x.RampIdentification, 1, 9);
		validator.Length(x => x.CityName, 2, 19);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.InspectorIdentityCode, 1, 6);
		validator.Length(x => x.DamageCodeQualifier, 1);
		return validator.Results;
	}
}

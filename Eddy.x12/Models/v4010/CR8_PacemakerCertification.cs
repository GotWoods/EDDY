using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("CR8")]
public class CR8_PacemakerCertification : EdiX12Segment
{
	[Position(01)]
	public string ImplantTypeCode { get; set; }

	[Position(02)]
	public string ImplantStatusCode { get; set; }

	[Position(03)]
	public string Date { get; set; }

	[Position(04)]
	public string Date2 { get; set; }

	[Position(05)]
	public string ReferenceIdentification { get; set; }

	[Position(06)]
	public string ReferenceIdentification2 { get; set; }

	[Position(07)]
	public string ReferenceIdentification3 { get; set; }

	[Position(08)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(09)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CR8_PacemakerCertification>(this);
		validator.Required(x=>x.ImplantTypeCode);
		validator.Required(x=>x.ImplantStatusCode);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.Date2);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Required(x=>x.ReferenceIdentification2);
		validator.Required(x=>x.ReferenceIdentification3);
		validator.Required(x=>x.YesNoConditionOrResponseCode);
		validator.Required(x=>x.YesNoConditionOrResponseCode2);
		validator.Length(x => x.ImplantTypeCode, 1);
		validator.Length(x => x.ImplantStatusCode, 1);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Date2, 8);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		validator.Length(x => x.ReferenceIdentification2, 1, 30);
		validator.Length(x => x.ReferenceIdentification3, 1, 30);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		return validator.Results;
	}
}

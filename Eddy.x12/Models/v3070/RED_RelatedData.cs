using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("RED")]
public class RED_RelatedData : EdiX12Segment
{
	[Position(01)]
	public string Description { get; set; }

	[Position(02)]
	public string RelatedDataIdentificationCode { get; set; }

	[Position(03)]
	public string AgencyQualifierCode { get; set; }

	[Position(04)]
	public string SourceSubqualifier { get; set; }

	[Position(05)]
	public string CodeListQualifierCode { get; set; }

	[Position(06)]
	public string IndustryCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RED_RelatedData>(this);
		validator.Required(x=>x.Description);
		validator.AtLeastOneIsRequired(x=>x.RelatedDataIdentificationCode, x=>x.IndustryCode);
		validator.OnlyOneOf(x=>x.RelatedDataIdentificationCode, x=>x.IndustryCode);
		validator.ARequiresB(x=>x.SourceSubqualifier, x=>x.AgencyQualifierCode);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.RelatedDataIdentificationCode, 2, 3);
		validator.Length(x => x.AgencyQualifierCode, 2);
		validator.Length(x => x.SourceSubqualifier, 1, 15);
		validator.Length(x => x.CodeListQualifierCode, 1, 3);
		validator.Length(x => x.IndustryCode, 1, 30);
		return validator.Results;
	}
}

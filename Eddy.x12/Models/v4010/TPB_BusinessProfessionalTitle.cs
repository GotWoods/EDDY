using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("TPB")]
public class TPB_BusinessProfessionalTitle : EdiX12Segment
{
	[Position(01)]
	public string BusinessProfessionalTitleCode { get; set; }

	[Position(02)]
	public string FreeFormMessageText { get; set; }

	[Position(03)]
	public string AgencyQualifierCode { get; set; }

	[Position(04)]
	public string SourceSubqualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TPB_BusinessProfessionalTitle>(this);
		validator.AtLeastOneIsRequired(x=>x.BusinessProfessionalTitleCode, x=>x.FreeFormMessageText);
		validator.ARequiresB(x=>x.AgencyQualifierCode, x=>x.BusinessProfessionalTitleCode);
		validator.ARequiresB(x=>x.SourceSubqualifier, x=>x.AgencyQualifierCode);
		validator.Length(x => x.BusinessProfessionalTitleCode, 1, 3);
		validator.Length(x => x.FreeFormMessageText, 1, 264);
		validator.Length(x => x.AgencyQualifierCode, 2);
		validator.Length(x => x.SourceSubqualifier, 1, 15);
		return validator.Results;
	}
}

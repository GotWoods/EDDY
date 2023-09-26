using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v7060;

[Segment("DET")]
public class DET_DietInformation : EdiX12Segment
{
	[Position(01)]
	public string DietTypeCode { get; set; }

	[Position(02)]
	public string Description { get; set; }

	[Position(03)]
	public string ConditionIndicatorCode { get; set; }

	[Position(04)]
	public string NameLastOrOrganizationName { get; set; }

	[Position(05)]
	public string ReferenceIdentification { get; set; }

	[Position(06)]
	public string Date { get; set; }

	[Position(07)]
	public string Date2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DET_DietInformation>(this);
		validator.AtLeastOneIsRequired(x=>x.DietTypeCode, x=>x.Description);
		validator.IfOneIsFilled_AllAreRequired(x=>x.NameLastOrOrganizationName, x=>x.ReferenceIdentification);
		validator.Length(x => x.DietTypeCode, 2);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.ConditionIndicatorCode, 2, 3);
		validator.Length(x => x.NameLastOrOrganizationName, 1, 80);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Date2, 8);
		return validator.Results;
	}
}

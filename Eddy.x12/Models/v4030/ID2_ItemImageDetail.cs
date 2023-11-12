using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4030;

[Segment("ID2")]
public class ID2_ItemImageDetail : EdiX12Segment
{
	[Position(01)]
	public string CashRegisterItemDescription { get; set; }

	[Position(02)]
	public string CashRegisterItemDescription2 { get; set; }

	[Position(03)]
	public string SpaceManagementReferenceCode { get; set; }

	[Position(04)]
	public string ReferenceIdentification { get; set; }

	[Position(05)]
	public string Name { get; set; }

	[Position(06)]
	public string Name2 { get; set; }

	[Position(07)]
	public string SpaceManagementReferenceCode2 { get; set; }

	[Position(08)]
	public string ReferenceIdentification2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ID2_ItemImageDetail>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.SpaceManagementReferenceCode, x=>x.ReferenceIdentification);
		validator.IfOneIsFilled_AllAreRequired(x=>x.SpaceManagementReferenceCode2, x=>x.ReferenceIdentification2);
		validator.Length(x => x.CashRegisterItemDescription, 1, 20);
		validator.Length(x => x.CashRegisterItemDescription2, 1, 20);
		validator.Length(x => x.SpaceManagementReferenceCode, 2);
		validator.Length(x => x.ReferenceIdentification, 1, 50);
		validator.Length(x => x.Name, 1, 60);
		validator.Length(x => x.Name2, 1, 60);
		validator.Length(x => x.SpaceManagementReferenceCode2, 2);
		validator.Length(x => x.ReferenceIdentification2, 1, 50);
		return validator.Results;
	}
}

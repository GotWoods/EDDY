using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("FX4")]
public class FX4_EquipmentInformation : EdiX12Segment
{
	[Position(01)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(02)]
	public string TypeOfProductServiceCode { get; set; }

	[Position(03)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(04)]
	public string ProductServiceID { get; set; }

	[Position(05)]
	public string ProductServiceIDQualifier2 { get; set; }

	[Position(06)]
	public string ProductServiceID2 { get; set; }

	[Position(07)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FX4_EquipmentInformation>(this);
		validator.Required(x=>x.YesNoConditionOrResponseCode);
		validator.AtLeastOneIsRequired(x=>x.ProductServiceIDQualifier, x=>x.Description);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier, x=>x.ProductServiceID);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier2, x=>x.ProductServiceID2);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.TypeOfProductServiceCode, 2, 4);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 80);
		validator.Length(x => x.ProductServiceIDQualifier2, 2);
		validator.Length(x => x.ProductServiceID2, 1, 80);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}

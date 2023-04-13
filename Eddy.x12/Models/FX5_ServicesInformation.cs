using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("FX5")]
public class FX5_ServicesInformation : EdiX12Segment
{
	[Position(01)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(02)]
	public string MaintenanceTypeCode { get; set; }

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
		var validator = new BasicValidator<FX5_ServicesInformation>(this);
		validator.Required(x=>x.YesNoConditionOrResponseCode);
		validator.Required(x=>x.MaintenanceTypeCode);
		validator.AtLeastOneIsRequired(x=>x.ProductServiceIDQualifier, x=>x.Description);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier, x=>x.ProductServiceID);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier2, x=>x.ProductServiceID2);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.MaintenanceTypeCode, 3);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 80);
		validator.Length(x => x.ProductServiceIDQualifier2, 2);
		validator.Length(x => x.ProductServiceID2, 1, 80);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}

using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("G54")]
public class G54_ModuleDescription : EdiX12Segment
{
	[Position(01)]
	public decimal? Quantity { get; set; }

	[Position(02)]
	public string UnitOfMeasurementCode { get; set; }

	[Position(03)]
	public string UPCCaseCode { get; set; }

	[Position(04)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(05)]
	public string ProductServiceID { get; set; }

	[Position(06)]
	public string FreeFormDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G54_ModuleDescription>(this);
		validator.Required(x=>x.Quantity);
		validator.Required(x=>x.UnitOfMeasurementCode);
		validator.Length(x => x.Quantity, 1, 10);
		validator.Length(x => x.UnitOfMeasurementCode, 2);
		validator.Length(x => x.UPCCaseCode, 12);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 30);
		validator.Length(x => x.FreeFormDescription, 1, 45);
		return validator.Results;
	}
}

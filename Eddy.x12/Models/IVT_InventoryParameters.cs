using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("IVT")]
public class IVT_InventoryParameters : EdiX12Segment
{
	[Position(01)]
	public string QuantityQualifier { get; set; }

	[Position(02)]
	public string DemandEstimationTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<IVT_InventoryParameters>(this);
		validator.Required(x=>x.QuantityQualifier);
		validator.Required(x=>x.DemandEstimationTypeCode);
		validator.Length(x => x.QuantityQualifier, 2);
		validator.Length(x => x.DemandEstimationTypeCode, 2);
		return validator.Results;
	}
}

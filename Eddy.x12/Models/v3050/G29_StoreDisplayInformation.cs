using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("G29")]
public class G29_StoreDisplayInformation : EdiX12Segment
{
	[Position(01)]
	public string DisplayTypeCode { get; set; }

	[Position(02)]
	public decimal? Quantity { get; set; }

	[Position(03)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G29_StoreDisplayInformation>(this);
		validator.Required(x=>x.DisplayTypeCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Quantity, x=>x.UnitOrBasisForMeasurementCode);
		validator.Length(x => x.DisplayTypeCode, 1, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		return validator.Results;
	}
}

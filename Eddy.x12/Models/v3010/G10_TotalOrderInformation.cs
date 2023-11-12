using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("G10")]
public class G10_TotalOrderInformation : EdiX12Segment
{
	[Position(01)]
	public decimal? QuantityReceived { get; set; }

	[Position(02)]
	public decimal? NumberOfUnitsShipped { get; set; }

	[Position(03)]
	public string UnitOfMeasurementCode { get; set; }

	[Position(04)]
	public int? LadingQuantityReceived { get; set; }

	[Position(05)]
	public string UnitOfMeasurementCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G10_TotalOrderInformation>(this);
		validator.Required(x=>x.QuantityReceived);
		validator.Required(x=>x.UnitOfMeasurementCode);
		validator.Length(x => x.QuantityReceived, 1, 7);
		validator.Length(x => x.NumberOfUnitsShipped, 1, 10);
		validator.Length(x => x.UnitOfMeasurementCode, 2);
		validator.Length(x => x.LadingQuantityReceived, 1, 7);
		validator.Length(x => x.UnitOfMeasurementCode2, 2);
		return validator.Results;
	}
}

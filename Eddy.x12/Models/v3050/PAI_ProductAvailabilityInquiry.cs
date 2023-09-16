using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("PAI")]
public class PAI_PrintAdvertisementInformation : EdiX12Segment
{
	[Position(01)]
	public string Date { get; set; }

	[Position(02)]
	public decimal? MeasurementValue { get; set; }

	[Position(03)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(04)]
	public string Amount { get; set; }

	[Position(05)]
	public string Amount2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PAI_PrintAdvertisementInformation>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.MeasurementValue, x=>x.UnitOrBasisForMeasurementCode);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.MeasurementValue, 1, 20);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Amount, 1, 15);
		validator.Length(x => x.Amount2, 1, 15);
		return validator.Results;
	}
}

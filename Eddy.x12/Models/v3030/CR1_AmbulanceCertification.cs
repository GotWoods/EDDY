using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("CR1")]
public class CR1_AmbulanceCertification : EdiX12Segment
{
	[Position(01)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(02)]
	public decimal? Weight { get; set; }

	[Position(03)]
	public string AmbulanceTransportCode { get; set; }

	[Position(04)]
	public string AmbulanceTransportReasonCode { get; set; }

	[Position(05)]
	public string UnitOrBasisForMeasurementCode2 { get; set; }

	[Position(06)]
	public decimal? Quantity { get; set; }

	[Position(07)]
	public string AddressInformation { get; set; }

	[Position(08)]
	public string AddressInformation2 { get; set; }

	[Position(09)]
	public string Description { get; set; }

	[Position(10)]
	public string Description2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CR1_AmbulanceCertification>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.UnitOrBasisForMeasurementCode, x=>x.Weight);
		validator.IfOneIsFilled_AllAreRequired(x=>x.UnitOrBasisForMeasurementCode2, x=>x.Quantity);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.AmbulanceTransportCode, 1);
		validator.Length(x => x.AmbulanceTransportReasonCode, 1);
		validator.Length(x => x.UnitOrBasisForMeasurementCode2, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.AddressInformation, 1, 35);
		validator.Length(x => x.AddressInformation2, 1, 35);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.Description2, 1, 80);
		return validator.Results;
	}
}

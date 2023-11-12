using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("LOC")]
public class LOC_Location : EdiX12Segment
{
	[Position(01)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(02)]
	public string ReferenceNumber { get; set; }

	[Position(03)]
	public string Description { get; set; }

	[Position(04)]
	public string ReferenceNumber2 { get; set; }

	[Position(05)]
	public string Category { get; set; }

	[Position(06)]
	public string ReferenceNumberQualifier2 { get; set; }

	[Position(07)]
	public string ReferenceNumber3 { get; set; }

	[Position(08)]
	public string Description2 { get; set; }

	[Position(09)]
	public string ReferenceNumber4 { get; set; }

	[Position(10)]
	public decimal? MeasurementValue { get; set; }

	[Position(11)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(12)]
	public decimal? MeasurementValue2 { get; set; }

	[Position(13)]
	public string UnitOrBasisForMeasurementCode2 { get; set; }

	[Position(14)]
	public decimal? MeasurementValue3 { get; set; }

	[Position(15)]
	public string UnitOrBasisForMeasurementCode3 { get; set; }

	[Position(16)]
	public decimal? MeasurementValue4 { get; set; }

	[Position(17)]
	public string UnitOrBasisForMeasurementCode4 { get; set; }

	[Position(18)]
	public decimal? MeasurementValue5 { get; set; }

	[Position(19)]
	public string UnitOrBasisForMeasurementCode5 { get; set; }

	[Position(20)]
	public decimal? MeasurementValue6 { get; set; }

	[Position(21)]
	public string UnitOrBasisForMeasurementCode6 { get; set; }

	[Position(22)]
	public string ReferenceNumberQualifier3 { get; set; }

	[Position(23)]
	public string ReferenceNumber5 { get; set; }

	[Position(24)]
	public string Description3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LOC_Location>(this);
		validator.Required(x=>x.ReferenceNumberQualifier);
		validator.Required(x=>x.ReferenceNumber);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceNumberQualifier2, x=>x.ReferenceNumber3);
		validator.ARequiresB(x=>x.UnitOrBasisForMeasurementCode, x=>x.MeasurementValue);
		validator.ARequiresB(x=>x.UnitOrBasisForMeasurementCode2, x=>x.MeasurementValue2);
		validator.ARequiresB(x=>x.UnitOrBasisForMeasurementCode3, x=>x.MeasurementValue3);
		validator.ARequiresB(x=>x.UnitOrBasisForMeasurementCode4, x=>x.MeasurementValue4);
		validator.ARequiresB(x=>x.UnitOrBasisForMeasurementCode5, x=>x.MeasurementValue5);
		validator.ARequiresB(x=>x.UnitOrBasisForMeasurementCode6, x=>x.MeasurementValue6);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceNumberQualifier3, x=>x.ReferenceNumber5);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.ReferenceNumber2, 1, 30);
		validator.Length(x => x.Category, 1, 6);
		validator.Length(x => x.ReferenceNumberQualifier2, 2);
		validator.Length(x => x.ReferenceNumber3, 1, 30);
		validator.Length(x => x.Description2, 1, 80);
		validator.Length(x => x.ReferenceNumber4, 1, 30);
		validator.Length(x => x.MeasurementValue, 1, 10);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.MeasurementValue2, 1, 10);
		validator.Length(x => x.UnitOrBasisForMeasurementCode2, 2);
		validator.Length(x => x.MeasurementValue3, 1, 10);
		validator.Length(x => x.UnitOrBasisForMeasurementCode3, 2);
		validator.Length(x => x.MeasurementValue4, 1, 10);
		validator.Length(x => x.UnitOrBasisForMeasurementCode4, 2);
		validator.Length(x => x.MeasurementValue5, 1, 10);
		validator.Length(x => x.UnitOrBasisForMeasurementCode5, 2);
		validator.Length(x => x.MeasurementValue6, 1, 10);
		validator.Length(x => x.UnitOrBasisForMeasurementCode6, 2);
		validator.Length(x => x.ReferenceNumberQualifier3, 2);
		validator.Length(x => x.ReferenceNumber5, 1, 30);
		validator.Length(x => x.Description3, 1, 80);
		return validator.Results;
	}
}

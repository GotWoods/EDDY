using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("LH2")]
public class LH2_HazardousClassificationInformation : EdiX12Segment
{
	[Position(01)]
	public string HazardousClassification { get; set; }

	[Position(02)]
	public string HazardousClassQualifier { get; set; }

	[Position(03)]
	public string HazardousPlacardNotation { get; set; }

	[Position(04)]
	public string HazardousEndorsement { get; set; }

	[Position(05)]
	public string ReportableQuantityCode { get; set; }

	[Position(06)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(07)]
	public decimal? Temperature { get; set; }

	[Position(08)]
	public string UnitOrBasisForMeasurementCode2 { get; set; }

	[Position(09)]
	public decimal? Temperature2 { get; set; }

	[Position(10)]
	public string UnitOrBasisForMeasurementCode3 { get; set; }

	[Position(11)]
	public decimal? Temperature3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LH2_HazardousClassificationInformation>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.UnitOrBasisForMeasurementCode, x=>x.Temperature);
		validator.IfOneIsFilled_AllAreRequired(x=>x.UnitOrBasisForMeasurementCode2, x=>x.Temperature2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.UnitOrBasisForMeasurementCode3, x=>x.Temperature3);
		validator.Length(x => x.HazardousClassification, 1, 30);
		validator.Length(x => x.HazardousClassQualifier, 1);
		validator.Length(x => x.HazardousPlacardNotation, 14, 40);
		validator.Length(x => x.HazardousEndorsement, 4, 25);
		validator.Length(x => x.ReportableQuantityCode, 2);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Temperature, 1, 4);
		validator.Length(x => x.UnitOrBasisForMeasurementCode2, 2);
		validator.Length(x => x.Temperature2, 1, 4);
		validator.Length(x => x.UnitOrBasisForMeasurementCode3, 2);
		validator.Length(x => x.Temperature3, 1, 4);
		return validator.Results;
	}
}

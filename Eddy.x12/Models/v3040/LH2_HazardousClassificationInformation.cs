using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

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
	public int? Temperature { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LH2_HazardousClassificationInformation>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.UnitOrBasisForMeasurementCode, x=>x.Temperature);
		validator.Length(x => x.HazardousClassification, 1, 30);
		validator.Length(x => x.HazardousClassQualifier, 1);
		validator.Length(x => x.HazardousPlacardNotation, 14, 40);
		validator.Length(x => x.HazardousEndorsement, 4, 25);
		validator.Length(x => x.ReportableQuantityCode, 2);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Temperature, 1, 3);
		return validator.Results;
	}
}

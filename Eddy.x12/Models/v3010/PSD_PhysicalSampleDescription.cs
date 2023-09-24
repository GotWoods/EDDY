using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("PSD")]
public class PSD_PhysicalSampleDescription : EdiX12Segment
{
	[Position(01)]
	public string SampleProcessStatusCode { get; set; }

	[Position(02)]
	public string SampleSelectionMethodCode { get; set; }

	[Position(03)]
	public int? SampleFrequencyValuePerUnitOfMeasurementCode { get; set; }

	[Position(04)]
	public string UnitOfMeasurementCode { get; set; }

	[Position(05)]
	public string SampleDescriptionCode { get; set; }

	[Position(06)]
	public string SampleDirectionCode { get; set; }

	[Position(07)]
	public string SampleLocationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PSD_PhysicalSampleDescription>(this);
		validator.Length(x => x.SampleProcessStatusCode, 2);
		validator.Length(x => x.SampleSelectionMethodCode, 2);
		validator.Length(x => x.SampleFrequencyValuePerUnitOfMeasurementCode, 1, 9);
		validator.Length(x => x.UnitOfMeasurementCode, 2);
		validator.Length(x => x.SampleDescriptionCode, 2);
		validator.Length(x => x.SampleDirectionCode, 2);
		validator.Length(x => x.SampleLocationCode, 2);
		return validator.Results;
	}
}

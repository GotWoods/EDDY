using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D98A.Composites;

namespace Eddy.Edifact.Models.D98A;

[Segment("PSD")]
public class PSD_PhysicalSampleDescription : EdifactSegment
{
	[Position(1)]
	public string SampleProcessStepCoded { get; set; }

	[Position(2)]
	public string SampleSelectionMethodCoded { get; set; }

	[Position(3)]
	public C526_FrequencyDetails FrequencyDetails { get; set; }

	[Position(4)]
	public string SampleDescriptionCoded { get; set; }

	[Position(5)]
	public string SampleDirectionCoded { get; set; }

	[Position(6)]
	public C514_SampleLocationDetails SampleLocationDetails { get; set; }

	[Position(7)]
	public C514_SampleLocationDetails SampleLocationDetails2 { get; set; }

	[Position(8)]
	public C514_SampleLocationDetails SampleLocationDetails3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PSD_PhysicalSampleDescription>(this);
		validator.Length(x => x.SampleProcessStepCoded, 1, 3);
		validator.Length(x => x.SampleSelectionMethodCoded, 1, 3);
		validator.Length(x => x.SampleDescriptionCoded, 1, 3);
		validator.Length(x => x.SampleDirectionCoded, 1, 3);
		return validator.Results;
	}
}

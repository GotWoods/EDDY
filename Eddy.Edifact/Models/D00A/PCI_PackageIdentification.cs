using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("PCI")]
public class PCI_PackageIdentification : EdifactSegment
{
	[Position(1)]
	public string MarkingInstructionsCode { get; set; }

	[Position(2)]
	public C210_MarksAndLabels MarksAndLabels { get; set; }

	[Position(3)]
	public string ContainerOrPackageContentsIndicatorCode { get; set; }

	[Position(4)]
	public C827_TypeOfMarking TypeOfMarking { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PCI_PackageIdentification>(this);
		validator.Length(x => x.MarkingInstructionsCode, 1, 3);
		validator.Length(x => x.ContainerOrPackageContentsIndicatorCode, 1, 3);
		return validator.Results;
	}
}
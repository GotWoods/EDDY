using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Models.D01C;

[Segment("DRD")]
public class DRD_DataRepresentationDetails : EdifactSegment
{
	[Position(1)]
	public string StructureComponentIdentifier { get; set; }

	[Position(2)]
	public string StructureTypeCode { get; set; }

	[Position(3)]
	public string DataRepresentationTypeCode { get; set; }

	[Position(4)]
	public string SizeMeasure { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DRD_DataRepresentationDetails>(this);
		validator.Length(x => x.StructureComponentIdentifier, 1, 35);
		validator.Length(x => x.StructureTypeCode, 1, 3);
		validator.Length(x => x.DataRepresentationTypeCode, 1, 3);
		validator.Length(x => x.SizeMeasure, 1, 15);
		return validator.Results;
	}
}

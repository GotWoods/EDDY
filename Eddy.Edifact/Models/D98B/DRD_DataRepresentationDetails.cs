using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Models.D98B;

[Segment("DRD")]
public class DRD_DataRepresentationDetails : EdifactSegment
{
	[Position(1)]
	public string StructureComponentIdentifier { get; set; }

	[Position(2)]
	public string StructureTypeCoded { get; set; }

	[Position(3)]
	public string DataRepresentationTypeCoded { get; set; }

	[Position(4)]
	public string Size { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DRD_DataRepresentationDetails>(this);
		validator.Length(x => x.StructureComponentIdentifier, 1, 35);
		validator.Length(x => x.StructureTypeCoded, 1, 3);
		validator.Length(x => x.DataRepresentationTypeCoded, 1, 3);
		validator.Length(x => x.Size, 1, 15);
		return validator.Results;
	}
}

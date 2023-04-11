using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("AOL")]
public class AOL_AnimalObservationLocation : EdiX12Segment 
{
	[Position(01)]
	public string ObservationTypeCode { get; set; }

	[Position(02)]
	public string Description { get; set; }

	[Position(03)]
	public string TissueOrSpecimenDispositionCode { get; set; }

	[Position(04)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(05)]
	public string SubLocation { get; set; }

	[Position(06)]
	public string SubLocation2 { get; set; }

	[Position(07)]
	public string SubLocation3 { get; set; }

	[Position(08)]
	public string SurfaceLayerPositionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<AOL_AnimalObservationLocation>(this);
		validator.Required(x=>x.ObservationTypeCode);
		validator.Required(x=>x.Description);
		validator.Length(x => x.ObservationTypeCode, 2);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.TissueOrSpecimenDispositionCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.SubLocation, 1, 24);
		validator.Length(x => x.SubLocation2, 1, 24);
		validator.Length(x => x.SubLocation3, 1, 24);
		validator.Length(x => x.SurfaceLayerPositionCode, 2);
		return validator.Results;
	}
}

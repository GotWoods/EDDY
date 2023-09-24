using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("G4")]
public class G4_ScaleIdentificationSegment : EdiX12Segment
{
	[Position(01)]
	public string CityName { get; set; }

	[Position(02)]
	public string StateOrProvinceCode { get; set; }

	[Position(03)]
	public string Name30CharacterFormat { get; set; }

	[Position(04)]
	public string EventDate { get; set; }

	[Position(05)]
	public string EventTime { get; set; }

	[Position(06)]
	public string ScaleTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G4_ScaleIdentificationSegment>(this);
		validator.Required(x=>x.CityName);
		validator.Required(x=>x.StateOrProvinceCode);
		validator.Required(x=>x.EventDate);
		validator.Length(x => x.CityName, 2, 19);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.Name30CharacterFormat, 2, 30);
		validator.Length(x => x.EventDate, 6);
		validator.Length(x => x.EventTime, 4);
		validator.Length(x => x.ScaleTypeCode, 1);
		return validator.Results;
	}
}
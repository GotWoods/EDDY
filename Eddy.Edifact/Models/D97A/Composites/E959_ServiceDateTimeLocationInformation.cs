using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D97A.Composites;

[Segment("E959")]
public class E959_ServiceDateTimeLocationInformation : EdifactComponent
{
	[Position(1)]
	public string SpecialServicesCoded { get; set; }

	[Position(2)]
	public string Time { get; set; }

	[Position(3)]
	public string Time2 { get; set; }

	[Position(4)]
	public string Date { get; set; }

	[Position(5)]
	public string PlaceLocation { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E959_ServiceDateTimeLocationInformation>(this);
		validator.Required(x=>x.SpecialServicesCoded);
		validator.Length(x => x.SpecialServicesCoded, 1, 3);
		validator.Length(x => x.Time, 4);
		validator.Length(x => x.Time2, 4);
		validator.Length(x => x.Date, 1, 14);
		validator.Length(x => x.PlaceLocation, 1, 70);
		return validator.Results;
	}
}

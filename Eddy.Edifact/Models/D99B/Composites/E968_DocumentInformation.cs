using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("E968")]
public class E968_DocumentInformation : EdifactComponent
{
	[Position(1)]
	public string DocumentNameCode { get; set; }

	[Position(2)]
	public string DocumentMessageNumber { get; set; }

	[Position(3)]
	public string CharacteristicValueCoded { get; set; }

	[Position(4)]
	public string LocationNameCode { get; set; }

	[Position(5)]
	public string CountryNameCode { get; set; }

	[Position(6)]
	public string CountryNameCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E968_DocumentInformation>(this);
		validator.Required(x=>x.DocumentNameCode);
		validator.Length(x => x.DocumentNameCode, 1, 3);
		validator.Length(x => x.DocumentMessageNumber, 1, 35);
		validator.Length(x => x.CharacteristicValueCoded, 1, 3);
		validator.Length(x => x.LocationNameCode, 1, 25);
		validator.Length(x => x.CountryNameCode, 1, 3);
		validator.Length(x => x.CountryNameCode2, 1, 3);
		return validator.Results;
	}
}

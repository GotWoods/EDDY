using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("S4")]
public class S4_StopOffCity : EdiX12Segment
{
	[Position(01)]
	public int? StopSequenceNumber { get; set; }

	[Position(02)]
	public string CityName { get; set; }

	[Position(03)]
	public string StateOrProvinceCode { get; set; }

	[Position(04)]
	public string PostalCode { get; set; }

	[Position(05)]
	public string CountryCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<S4_StopOffCity>(this);
		validator.Required(x=>x.StopSequenceNumber);
		validator.Required(x=>x.CityName);
		validator.Required(x=>x.StateOrProvinceCode);
		validator.Length(x => x.StopSequenceNumber, 1, 2);
		validator.Length(x => x.CityName, 2, 19);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.PostalCode, 4, 9);
		validator.Length(x => x.CountryCode, 2);
		return validator.Results;
	}
}

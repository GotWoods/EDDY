using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("Q5")]
public class Q5_StatusDetails : EdiX12Segment
{
	[Position(01)]
	public string StatusCode { get; set; }

	[Position(02)]
	public string StatusDate { get; set; }

	[Position(03)]
	public string StatusTime { get; set; }

	[Position(04)]
	public string TimeCode { get; set; }

	[Position(05)]
	public string StatusReasonCode { get; set; }

	[Position(06)]
	public string CityName { get; set; }

	[Position(07)]
	public string StateOrProvinceCode { get; set; }

	[Position(08)]
	public string CountryCode { get; set; }

	[Position(09)]
	public string EquipmentInitial { get; set; }

	[Position(10)]
	public string EquipmentNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<Q5_StatusDetails>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.CityName, x=>x.StateOrProvinceCode);
		validator.Length(x => x.StatusCode, 1, 2);
		validator.Length(x => x.StatusDate, 6);
		validator.Length(x => x.StatusTime, 4);
		validator.Length(x => x.TimeCode, 2);
		validator.Length(x => x.StatusReasonCode, 3);
		validator.Length(x => x.CityName, 2, 19);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.CountryCode, 2);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 10);
		return validator.Results;
	}
}

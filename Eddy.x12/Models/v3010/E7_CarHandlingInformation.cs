using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("E7")]
public class E7_CarHandlingInformation : EdiX12Segment
{
	[Position(01)]
	public string CityName { get; set; }

	[Position(02)]
	public string StateOrProvinceCode { get; set; }

	[Position(03)]
	public string StandardPointLocationCode { get; set; }

	[Position(04)]
	public string RailCarStatusOrderCode { get; set; }

	[Position(05)]
	public string EstimatedInterchangeDate { get; set; }

	[Position(06)]
	public string EstimatedInterchangeTime { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E7_CarHandlingInformation>(this);
		validator.Length(x => x.CityName, 2, 19);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.StandardPointLocationCode, 6, 9);
		validator.Length(x => x.RailCarStatusOrderCode, 2);
		validator.Length(x => x.EstimatedInterchangeDate, 6);
		validator.Length(x => x.EstimatedInterchangeTime, 4);
		return validator.Results;
	}
}

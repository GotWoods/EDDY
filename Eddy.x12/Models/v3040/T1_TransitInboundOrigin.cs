using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("T1")]
public class T1_TransitInboundOrigin : EdiX12Segment
{
	[Position(01)]
	public int? AssignedNumber { get; set; }

	[Position(02)]
	public int? WaybillNumber { get; set; }

	[Position(03)]
	public string Date { get; set; }

	[Position(04)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(05)]
	public string CityName { get; set; }

	[Position(06)]
	public string StateOrProvinceCode { get; set; }

	[Position(07)]
	public string StandardPointLocationCode { get; set; }

	[Position(08)]
	public string TransitRegistrationNumber { get; set; }

	[Position(09)]
	public string TransitLevelCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<T1_TransitInboundOrigin>(this);
		validator.Required(x=>x.AssignedNumber);
		validator.Length(x => x.AssignedNumber, 1, 6);
		validator.Length(x => x.WaybillNumber, 1, 6);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.CityName, 2, 30);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.StandardPointLocationCode, 6, 9);
		validator.Length(x => x.TransitRegistrationNumber, 1, 6);
		validator.Length(x => x.TransitLevelCode, 1, 3);
		return validator.Results;
	}
}

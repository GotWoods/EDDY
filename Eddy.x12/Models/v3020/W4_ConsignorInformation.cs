using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("W4")]
public class W4_ConsignorInformation : EdiX12Segment
{
	[Position(01)]
	public string AbbreviatedCustomerName { get; set; }

	[Position(02)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(03)]
	public string FreightStationAccountingCode { get; set; }

	[Position(04)]
	public string CityName { get; set; }

	[Position(05)]
	public string StateOrProvinceCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<W4_ConsignorInformation>(this);
		validator.AtLeastOneIsRequired(x=>x.StandardCarrierAlphaCode, x=>x.CityName);
		validator.IfOneIsFilled_AllAreRequired(x=>x.StandardCarrierAlphaCode, x=>x.FreightStationAccountingCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.CityName, x=>x.StateOrProvinceCode);
		validator.Length(x => x.AbbreviatedCustomerName, 2, 12);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.FreightStationAccountingCode, 1, 5);
		validator.Length(x => x.CityName, 2, 19);
		validator.Length(x => x.StateOrProvinceCode, 2);
		return validator.Results;
	}
}

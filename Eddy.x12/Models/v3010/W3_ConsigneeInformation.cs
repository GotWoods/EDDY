using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("W3")]
public class W3_ConsigneeInformation : EdiX12Segment
{
	[Position(01)]
	public int? WaybillNumber { get; set; }

	[Position(02)]
	public string WaybillDate { get; set; }

	[Position(03)]
	public string AbbreviatedCustomerName { get; set; }

	[Position(04)]
	public string CityName { get; set; }

	[Position(05)]
	public string StateOrProvinceCode { get; set; }

	[Position(06)]
	public string CityNameQualifierCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<W3_ConsigneeInformation>(this);
		validator.Length(x => x.WaybillNumber, 1, 6);
		validator.Length(x => x.WaybillDate, 6);
		validator.Length(x => x.AbbreviatedCustomerName, 2, 12);
		validator.Length(x => x.CityName, 2, 19);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.CityNameQualifierCode, 1);
		return validator.Results;
	}
}

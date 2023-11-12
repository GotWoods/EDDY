using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("PR2")]
public class PR2_PriceRequestParameterList2 : EdiX12Segment
{
	[Position(01)]
	public string Date { get; set; }

	[Position(02)]
	public string Date2 { get; set; }

	[Position(03)]
	public string RouteCode { get; set; }

	[Position(04)]
	public string CarTypeCode { get; set; }

	[Position(05)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(06)]
	public string IdentificationCode { get; set; }

	[Position(07)]
	public string ReferenceNumber { get; set; }

	[Position(08)]
	public string ConveyanceCode { get; set; }

	[Position(09)]
	public string ReferenceNumber2 { get; set; }

	[Position(10)]
	public int? Century { get; set; }

	[Position(11)]
	public int? Century2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PR2_PriceRequestParameterList2>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IdentificationCodeQualifier, x=>x.IdentificationCode);
		validator.ARequiresB(x=>x.Century, x=>x.Date);
		validator.ARequiresB(x=>x.Century2, x=>x.Date2);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Date2, 6);
		validator.Length(x => x.RouteCode, 1, 13);
		validator.Length(x => x.CarTypeCode, 4);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 17);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.ConveyanceCode, 1);
		validator.Length(x => x.ReferenceNumber2, 1, 30);
		validator.Length(x => x.Century, 2);
		validator.Length(x => x.Century2, 2);
		return validator.Results;
	}
}

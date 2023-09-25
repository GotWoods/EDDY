using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("RU3")]
public class RU3_EmployingCarrierClaimProfile : EdiX12Segment
{
	[Position(01)]
	public string Date { get; set; }

	[Position(02)]
	public string PayrollStatusCode { get; set; }

	[Position(03)]
	public string WagesPaidCode { get; set; }

	[Position(04)]
	public string PayrollStatusCode2 { get; set; }

	[Position(05)]
	public string WagesPaidCode2 { get; set; }

	[Position(06)]
	public string PayrollStatusCode3 { get; set; }

	[Position(07)]
	public string WagesPaidCode3 { get; set; }

	[Position(08)]
	public string PayrollStatusCode4 { get; set; }

	[Position(09)]
	public string WagesPaidCode4 { get; set; }

	[Position(10)]
	public string PayrollStatusCode5 { get; set; }

	[Position(11)]
	public string WagesPaidCode5 { get; set; }

	[Position(12)]
	public string PayrollStatusCode6 { get; set; }

	[Position(13)]
	public string WagesPaidCode6 { get; set; }

	[Position(14)]
	public string PayrollStatusCode7 { get; set; }

	[Position(15)]
	public string WagesPaidCode7 { get; set; }

	[Position(16)]
	public string PayrollStatusCode8 { get; set; }

	[Position(17)]
	public string WagesPaidCode8 { get; set; }

	[Position(18)]
	public string PayrollStatusCode9 { get; set; }

	[Position(19)]
	public string WagesPaidCode9 { get; set; }

	[Position(20)]
	public string PayrollStatusCode10 { get; set; }

	[Position(21)]
	public string WagesPaidCode10 { get; set; }

	[Position(22)]
	public string PayrollStatusCode11 { get; set; }

	[Position(23)]
	public string WagesPaidCode11 { get; set; }

	[Position(24)]
	public string PayrollStatusCode12 { get; set; }

	[Position(25)]
	public string WagesPaidCode12 { get; set; }

	[Position(26)]
	public string PayrollStatusCode13 { get; set; }

	[Position(27)]
	public string WagesPaidCode13 { get; set; }

	[Position(28)]
	public string PayrollStatusCode14 { get; set; }

	[Position(29)]
	public string WagesPaidCode14 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RU3_EmployingCarrierClaimProfile>(this);
		validator.Required(x=>x.Date);
		validator.IfOneIsFilled_AllAreRequired(x=>x.PayrollStatusCode, x=>x.WagesPaidCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.PayrollStatusCode2, x=>x.WagesPaidCode2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.PayrollStatusCode3, x=>x.WagesPaidCode3);
		validator.IfOneIsFilled_AllAreRequired(x=>x.PayrollStatusCode4, x=>x.WagesPaidCode4);
		validator.IfOneIsFilled_AllAreRequired(x=>x.PayrollStatusCode5, x=>x.WagesPaidCode5);
		validator.IfOneIsFilled_AllAreRequired(x=>x.PayrollStatusCode6, x=>x.WagesPaidCode6);
		validator.IfOneIsFilled_AllAreRequired(x=>x.PayrollStatusCode7, x=>x.WagesPaidCode7);
		validator.IfOneIsFilled_AllAreRequired(x=>x.PayrollStatusCode8, x=>x.WagesPaidCode8);
		validator.IfOneIsFilled_AllAreRequired(x=>x.PayrollStatusCode9, x=>x.WagesPaidCode9);
		validator.IfOneIsFilled_AllAreRequired(x=>x.PayrollStatusCode10, x=>x.WagesPaidCode10);
		validator.IfOneIsFilled_AllAreRequired(x=>x.PayrollStatusCode11, x=>x.WagesPaidCode11);
		validator.IfOneIsFilled_AllAreRequired(x=>x.PayrollStatusCode12, x=>x.WagesPaidCode12);
		validator.IfOneIsFilled_AllAreRequired(x=>x.PayrollStatusCode13, x=>x.WagesPaidCode13);
		validator.IfOneIsFilled_AllAreRequired(x=>x.PayrollStatusCode14, x=>x.WagesPaidCode14);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.PayrollStatusCode, 2);
		validator.Length(x => x.WagesPaidCode, 1);
		validator.Length(x => x.PayrollStatusCode2, 2);
		validator.Length(x => x.WagesPaidCode2, 1);
		validator.Length(x => x.PayrollStatusCode3, 2);
		validator.Length(x => x.WagesPaidCode3, 1);
		validator.Length(x => x.PayrollStatusCode4, 2);
		validator.Length(x => x.WagesPaidCode4, 1);
		validator.Length(x => x.PayrollStatusCode5, 2);
		validator.Length(x => x.WagesPaidCode5, 1);
		validator.Length(x => x.PayrollStatusCode6, 2);
		validator.Length(x => x.WagesPaidCode6, 1);
		validator.Length(x => x.PayrollStatusCode7, 2);
		validator.Length(x => x.WagesPaidCode7, 1);
		validator.Length(x => x.PayrollStatusCode8, 2);
		validator.Length(x => x.WagesPaidCode8, 1);
		validator.Length(x => x.PayrollStatusCode9, 2);
		validator.Length(x => x.WagesPaidCode9, 1);
		validator.Length(x => x.PayrollStatusCode10, 2);
		validator.Length(x => x.WagesPaidCode10, 1);
		validator.Length(x => x.PayrollStatusCode11, 2);
		validator.Length(x => x.WagesPaidCode11, 1);
		validator.Length(x => x.PayrollStatusCode12, 2);
		validator.Length(x => x.WagesPaidCode12, 1);
		validator.Length(x => x.PayrollStatusCode13, 2);
		validator.Length(x => x.WagesPaidCode13, 1);
		validator.Length(x => x.PayrollStatusCode14, 2);
		validator.Length(x => x.WagesPaidCode14, 1);
		return validator.Results;
	}
}

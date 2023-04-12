using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("SR")]
public class SR_RequestedServiceSchedule : EdiX12Segment
{
	[Position(01)]
	public string AssignedIdentification { get; set; }

	[Position(02)]
	public string DayRotation { get; set; }

	[Position(03)]
	public string Time { get; set; }

	[Position(04)]
	public string Time2 { get; set; }

	[Position(05)]
	public string FreeFormMessage { get; set; }

	[Position(06)]
	public decimal? UnitPrice { get; set; }

	[Position(07)]
	public decimal? Quantity { get; set; }

	[Position(08)]
	public string Date { get; set; }

	[Position(09)]
	public string Date2 { get; set; }

	[Position(10)]
	public string ProductServiceID { get; set; }

	[Position(11)]
	public string ProductServiceID2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SR_RequestedServiceSchedule>(this);
		validator.ARequiresB(x=>x.Time2, x=>x.Time);
		validator.ARequiresB(x=>x.Date2, x=>x.Date);
		validator.Length(x => x.AssignedIdentification, 1, 20);
		validator.Length(x => x.DayRotation, 1, 7);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.Time2, 4, 8);
		validator.Length(x => x.FreeFormMessage, 1, 60);
		validator.Length(x => x.UnitPrice, 1, 17);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Date2, 8);
		validator.Length(x => x.ProductServiceID, 1, 80);
		validator.Length(x => x.ProductServiceID2, 1, 80);
		return validator.Results;
	}
}

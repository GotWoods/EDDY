using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("VAD")]
public class VAD_VehicleAdviceDetail : EdiX12Segment
{
	[Position(01)]
	public string VehicleIdentificationNumber { get; set; }

	[Position(02)]
	public string InvoiceNumber { get; set; }

	[Position(03)]
	public decimal? MonetaryAmount { get; set; }

	[Position(04)]
	public decimal? Rate { get; set; }

	[Position(05)]
	public string DealerCode { get; set; }

	[Position(06)]
	public string ReferenceNumber { get; set; }

	[Position(07)]
	public string ApplicationErrorConditionCode { get; set; }

	[Position(08)]
	public string ApplicationErrorConditionCode2 { get; set; }

	[Position(09)]
	public string ApplicationErrorConditionCode3 { get; set; }

	[Position(10)]
	public string DateTimeQualifier { get; set; }

	[Position(11)]
	public string Date { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<VAD_VehicleAdviceDetail>(this);
		validator.Required(x=>x.VehicleIdentificationNumber);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimeQualifier, x=>x.Date);
		validator.Length(x => x.VehicleIdentificationNumber, 1, 25);
		validator.Length(x => x.InvoiceNumber, 1, 22);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.Rate, 1, 7);
		validator.Length(x => x.DealerCode, 2, 9);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.ApplicationErrorConditionCode, 1, 3);
		validator.Length(x => x.ApplicationErrorConditionCode2, 1, 3);
		validator.Length(x => x.ApplicationErrorConditionCode3, 1, 3);
		validator.Length(x => x.DateTimeQualifier, 3);
		validator.Length(x => x.Date, 6);
		return validator.Results;
	}
}

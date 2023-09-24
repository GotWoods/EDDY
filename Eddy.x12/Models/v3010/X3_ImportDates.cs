using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("X3")]
public class X3_ImportDates : EdiX12Segment
{
	[Position(01)]
	public string ExportationDate { get; set; }

	[Position(02)]
	public string ArrivalDate { get; set; }

	[Position(03)]
	public string CarrierCertificatedReleaseDate { get; set; }

	[Position(04)]
	public string StandardCustomsInvoiceDate { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<X3_ImportDates>(this);
		validator.Required(x=>x.ExportationDate);
		validator.Required(x=>x.ArrivalDate);
		validator.Required(x=>x.CarrierCertificatedReleaseDate);
		validator.Required(x=>x.StandardCustomsInvoiceDate);
		validator.Length(x => x.ExportationDate, 6);
		validator.Length(x => x.ArrivalDate, 6);
		validator.Length(x => x.CarrierCertificatedReleaseDate, 6);
		validator.Length(x => x.StandardCustomsInvoiceDate, 6);
		return validator.Results;
	}
}

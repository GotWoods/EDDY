using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v6010;

[Segment("ACK")]
public class ACK_LineItemAcknowledgment : EdiX12Segment
{
	[Position(01)]
	public string LineItemStatusCode { get; set; }

	[Position(02)]
	public decimal? Quantity { get; set; }

	[Position(03)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(04)]
	public string DateTimeQualifier { get; set; }

	[Position(05)]
	public string Date { get; set; }

	[Position(06)]
	public string RequestReferenceNumber { get; set; }

	[Position(07)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(08)]
	public string ProductServiceID { get; set; }

	[Position(09)]
	public string ProductServiceIDQualifier2 { get; set; }

	[Position(10)]
	public string ProductServiceID2 { get; set; }

	[Position(11)]
	public string ProductServiceIDQualifier3 { get; set; }

	[Position(12)]
	public string ProductServiceID3 { get; set; }

	[Position(13)]
	public string ProductServiceIDQualifier4 { get; set; }

	[Position(14)]
	public string ProductServiceID4 { get; set; }

	[Position(15)]
	public string ProductServiceIDQualifier5 { get; set; }

	[Position(16)]
	public string ProductServiceID5 { get; set; }

	[Position(17)]
	public string ProductServiceIDQualifier6 { get; set; }

	[Position(18)]
	public string ProductServiceID6 { get; set; }

	[Position(19)]
	public string ProductServiceIDQualifier7 { get; set; }

	[Position(20)]
	public string ProductServiceID7 { get; set; }

	[Position(21)]
	public string ProductServiceIDQualifier8 { get; set; }

	[Position(22)]
	public string ProductServiceID8 { get; set; }

	[Position(23)]
	public string ProductServiceIDQualifier9 { get; set; }

	[Position(24)]
	public string ProductServiceID9 { get; set; }

	[Position(25)]
	public string ProductServiceIDQualifier10 { get; set; }

	[Position(26)]
	public string ProductServiceID10 { get; set; }

	[Position(27)]
	public string AgencyQualifierCode { get; set; }

	[Position(28)]
	public string SourceSubqualifier { get; set; }

	[Position(29)]
	public string IndustryCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ACK_LineItemAcknowledgment>(this);
		validator.Required(x=>x.LineItemStatusCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Quantity, x=>x.UnitOrBasisForMeasurementCode);
		validator.ARequiresB(x=>x.DateTimeQualifier, x=>x.Date);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier, x=>x.ProductServiceID);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier2, x=>x.ProductServiceID2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier3, x=>x.ProductServiceID3);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier4, x=>x.ProductServiceID4);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier5, x=>x.ProductServiceID5);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier6, x=>x.ProductServiceID6);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier7, x=>x.ProductServiceID7);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier8, x=>x.ProductServiceID8);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier9, x=>x.ProductServiceID9);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier10, x=>x.ProductServiceID10);
		validator.IfOneIsFilled_AllAreRequired(x=>x.AgencyQualifierCode, x=>x.SourceSubqualifier);
		validator.Length(x => x.LineItemStatusCode, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.DateTimeQualifier, 3);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.RequestReferenceNumber, 1, 45);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 80);
		validator.Length(x => x.ProductServiceIDQualifier2, 2);
		validator.Length(x => x.ProductServiceID2, 1, 80);
		validator.Length(x => x.ProductServiceIDQualifier3, 2);
		validator.Length(x => x.ProductServiceID3, 1, 80);
		validator.Length(x => x.ProductServiceIDQualifier4, 2);
		validator.Length(x => x.ProductServiceID4, 1, 80);
		validator.Length(x => x.ProductServiceIDQualifier5, 2);
		validator.Length(x => x.ProductServiceID5, 1, 80);
		validator.Length(x => x.ProductServiceIDQualifier6, 2);
		validator.Length(x => x.ProductServiceID6, 1, 80);
		validator.Length(x => x.ProductServiceIDQualifier7, 2);
		validator.Length(x => x.ProductServiceID7, 1, 80);
		validator.Length(x => x.ProductServiceIDQualifier8, 2);
		validator.Length(x => x.ProductServiceID8, 1, 80);
		validator.Length(x => x.ProductServiceIDQualifier9, 2);
		validator.Length(x => x.ProductServiceID9, 1, 80);
		validator.Length(x => x.ProductServiceIDQualifier10, 2);
		validator.Length(x => x.ProductServiceID10, 1, 80);
		validator.Length(x => x.AgencyQualifierCode, 2);
		validator.Length(x => x.SourceSubqualifier, 1, 15);
		validator.Length(x => x.IndustryCode, 1, 30);
		return validator.Results;
	}
}

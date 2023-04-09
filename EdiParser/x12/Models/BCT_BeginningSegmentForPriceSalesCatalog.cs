using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("BCT")]
public class BCT_BeginningSegmentForPriceSalesCatalog : EdiX12Segment 
{
	[Position(01)]
	public string CatalogPurposeCode { get; set; }

	[Position(02)]
	public string CatalogNumber { get; set; }

	[Position(03)]
	public string CatalogVersionNumber { get; set; }

	[Position(04)]
	public string CatalogRevisionNumber { get; set; }

	[Position(05)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(06)]
	public string CatalogNumber2 { get; set; }

	[Position(07)]
	public string CatalogVersionNumber2 { get; set; }

	[Position(08)]
	public string CatalogRevisionNumber2 { get; set; }

	[Position(09)]
	public string Description { get; set; }

	[Position(10)]
	public string TransactionSetPurposeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BCT_BeginningSegmentForPriceSalesCatalog>(this);
		validator.Required(x=>x.CatalogPurposeCode);
		validator.Length(x => x.CatalogPurposeCode, 2);
		validator.Length(x => x.CatalogNumber, 1, 15);
		validator.Length(x => x.CatalogVersionNumber, 1, 15);
		validator.Length(x => x.CatalogRevisionNumber, 1, 6);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.CatalogNumber2, 1, 15);
		validator.Length(x => x.CatalogVersionNumber2, 1, 15);
		validator.Length(x => x.CatalogRevisionNumber2, 1, 6);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		return validator.Results;
	}
}

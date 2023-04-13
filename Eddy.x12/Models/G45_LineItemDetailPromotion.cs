using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("G45")]
public class G45_LineItemDetailPromotion : EdiX12Segment
{
	[Position(01)]
	public string UPCCaseCode { get; set; }

	[Position(02)]
	public string UPCEANConsumerPackageCode { get; set; }

	[Position(03)]
	public string AllowanceOrChargeNumber { get; set; }

	[Position(04)]
	public string ExceptionNumber { get; set; }

	[Position(05)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(06)]
	public string ProductServiceID { get; set; }

	[Position(07)]
	public int? Pack { get; set; }

	[Position(08)]
	public decimal? Size { get; set; }

	[Position(09)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(10)]
	public string DateQualifier { get; set; }

	[Position(11)]
	public string Date { get; set; }

	[Position(12)]
	public int? InnerPack { get; set; }

	[Position(13)]
	public decimal? AllowanceOrChargeRate { get; set; }

	[Position(14)]
	public string ProductServiceIDQualifier2 { get; set; }

	[Position(15)]
	public string ProductServiceID2 { get; set; }

	[Position(16)]
	public string ProductServiceIDQualifier3 { get; set; }

	[Position(17)]
	public string ProductServiceID3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G45_LineItemDetailPromotion>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier, x=>x.ProductServiceID);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Size, x=>x.UnitOrBasisForMeasurementCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateQualifier, x=>x.Date);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier2, x=>x.ProductServiceID2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier3, x=>x.ProductServiceID3);
		validator.Length(x => x.UPCCaseCode, 12);
		validator.Length(x => x.UPCEANConsumerPackageCode, 12);
		validator.Length(x => x.AllowanceOrChargeNumber, 1, 16);
		validator.Length(x => x.ExceptionNumber, 1, 16);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 80);
		validator.Length(x => x.Pack, 1, 6);
		validator.Length(x => x.Size, 1, 8);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.DateQualifier, 2);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.InnerPack, 1, 6);
		validator.Length(x => x.AllowanceOrChargeRate, 1, 15);
		validator.Length(x => x.ProductServiceIDQualifier2, 2);
		validator.Length(x => x.ProductServiceID2, 1, 80);
		validator.Length(x => x.ProductServiceIDQualifier3, 2);
		validator.Length(x => x.ProductServiceID3, 1, 80);
		return validator.Results;
	}
}

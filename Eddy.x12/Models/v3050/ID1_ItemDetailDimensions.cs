using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("ID1")]
public class ID1_ItemDetailDimensions : EdiX12Segment
{
	[Position(01)]
	public string UPCEANConsumerPackageCode { get; set; }

	[Position(02)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(03)]
	public string ProductServiceID { get; set; }

	[Position(04)]
	public string FreeFormDescription { get; set; }

	[Position(05)]
	public decimal? Size { get; set; }

	[Position(06)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(07)]
	public decimal? Height { get; set; }

	[Position(08)]
	public decimal? Width { get; set; }

	[Position(09)]
	public decimal? ItemDepth { get; set; }

	[Position(10)]
	public string UnitOrBasisForMeasurementCode2 { get; set; }

	[Position(11)]
	public decimal? Weight { get; set; }

	[Position(12)]
	public string UnitOrBasisForMeasurementCode3 { get; set; }

	[Position(13)]
	public string CategoryReferenceCode { get; set; }

	[Position(14)]
	public string Category { get; set; }

	[Position(15)]
	public string Subcategory { get; set; }

	[Position(16)]
	public string UnitOrBasisForMeasurementCode4 { get; set; }

	[Position(17)]
	public int? Pack { get; set; }

	[Position(18)]
	public int? InnerPack { get; set; }

	[Position(19)]
	public string DateQualifier { get; set; }

	[Position(20)]
	public string Date { get; set; }

	[Position(21)]
	public string NestingCode { get; set; }

	[Position(22)]
	public decimal? Nesting { get; set; }

	[Position(23)]
	public string UnitOrBasisForMeasurementCode5 { get; set; }

	[Position(24)]
	public string PegCode { get; set; }

	[Position(25)]
	public string UnitOrBasisForMeasurementCode6 { get; set; }

	[Position(26)]
	public string ReferenceNumber { get; set; }

	[Position(27)]
	public decimal? XPeg { get; set; }

	[Position(28)]
	public decimal? YPeg { get; set; }

	[Position(29)]
	public string ReferenceNumber2 { get; set; }

	[Position(30)]
	public decimal? XPeg2 { get; set; }

	[Position(31)]
	public decimal? YPeg2 { get; set; }

	[Position(32)]
	public string ReferenceNumber3 { get; set; }

	[Position(33)]
	public decimal? XPeg3 { get; set; }

	[Position(34)]
	public decimal? YPeg3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ID1_ItemDetailDimensions>(this);
		validator.AtLeastOneIsRequired(x=>x.UPCEANConsumerPackageCode, x=>x.ProductServiceIDQualifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier, x=>x.ProductServiceID);
		validator.Required(x=>x.FreeFormDescription);
		validator.Required(x=>x.Size);
		validator.Required(x=>x.UnitOrBasisForMeasurementCode);
		validator.Required(x=>x.Height);
		validator.Required(x=>x.Width);
		validator.Required(x=>x.ItemDepth);
		validator.Required(x=>x.UnitOrBasisForMeasurementCode2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Weight, x=>x.UnitOrBasisForMeasurementCode3);
		validator.IfOneIsFilled_AllAreRequired(x=>x.CategoryReferenceCode, x=>x.Category);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateQualifier, x=>x.Date);
		validator.ARequiresB(x=>x.ReferenceNumber, x=>x.UnitOrBasisForMeasurementCode6);
		validator.ARequiresB(x=>x.ReferenceNumber2, x=>x.UnitOrBasisForMeasurementCode6);
		validator.ARequiresB(x=>x.ReferenceNumber3, x=>x.UnitOrBasisForMeasurementCode6);
		validator.Length(x => x.UPCEANConsumerPackageCode, 12);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 40);
		validator.Length(x => x.FreeFormDescription, 1, 45);
		validator.Length(x => x.Size, 1, 8);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Height, 1, 8);
		validator.Length(x => x.Width, 1, 8);
		validator.Length(x => x.ItemDepth, 1, 6);
		validator.Length(x => x.UnitOrBasisForMeasurementCode2, 2);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.UnitOrBasisForMeasurementCode3, 2);
		validator.Length(x => x.CategoryReferenceCode, 1);
		validator.Length(x => x.Category, 1, 6);
		validator.Length(x => x.Subcategory, 1, 6);
		validator.Length(x => x.UnitOrBasisForMeasurementCode4, 2);
		validator.Length(x => x.Pack, 1, 6);
		validator.Length(x => x.InnerPack, 1, 6);
		validator.Length(x => x.DateQualifier, 2);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.NestingCode, 1);
		validator.Length(x => x.Nesting, 1, 6);
		validator.Length(x => x.UnitOrBasisForMeasurementCode5, 2);
		validator.Length(x => x.PegCode, 1);
		validator.Length(x => x.UnitOrBasisForMeasurementCode6, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.XPeg, 1, 6);
		validator.Length(x => x.YPeg, 1, 6);
		validator.Length(x => x.ReferenceNumber2, 1, 30);
		validator.Length(x => x.XPeg2, 1, 6);
		validator.Length(x => x.YPeg2, 1, 6);
		validator.Length(x => x.ReferenceNumber3, 1, 30);
		validator.Length(x => x.XPeg3, 1, 6);
		validator.Length(x => x.YPeg3, 1, 6);
		return validator.Results;
	}
}

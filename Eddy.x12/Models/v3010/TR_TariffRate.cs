using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("TR")]
public class TR_TariffRate : EdiX12Segment
{
	[Position(01)]
	public int? LineNumber { get; set; }

	[Position(02)]
	public string FreeFormDescription { get; set; }

	[Position(03)]
	public string QuantityQualifier { get; set; }

	[Position(04)]
	public decimal? Quantity { get; set; }

	[Position(05)]
	public string UnitOfMeasurementCode { get; set; }

	[Position(06)]
	public string PackagingCode { get; set; }

	[Position(07)]
	public string QuantityQualifier2 { get; set; }

	[Position(08)]
	public decimal? Quantity2 { get; set; }

	[Position(09)]
	public string UnitOfMeasurementCode2 { get; set; }

	[Position(10)]
	public string PackagingCode2 { get; set; }

	[Position(11)]
	public string TypeOfServiceCode { get; set; }

	[Position(12)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(13)]
	public string RateValueQualifier { get; set; }

	[Position(14)]
	public string EquipmentDescriptionCode { get; set; }

	[Position(15)]
	public int? EquipmentLength { get; set; }

	[Position(16)]
	public string CurrencyCode { get; set; }

	[Position(17)]
	public decimal? FreightRate { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TR_TariffRate>(this);
		validator.Required(x=>x.LineNumber);
		validator.Length(x => x.LineNumber, 1, 3);
		validator.Length(x => x.FreeFormDescription, 1, 45);
		validator.Length(x => x.QuantityQualifier, 2);
		validator.Length(x => x.Quantity, 1, 10);
		validator.Length(x => x.UnitOfMeasurementCode, 2);
		validator.Length(x => x.PackagingCode, 5);
		validator.Length(x => x.QuantityQualifier2, 2);
		validator.Length(x => x.Quantity2, 1, 10);
		validator.Length(x => x.UnitOfMeasurementCode2, 2);
		validator.Length(x => x.PackagingCode2, 5);
		validator.Length(x => x.TypeOfServiceCode, 2);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.RateValueQualifier, 2);
		validator.Length(x => x.EquipmentDescriptionCode, 2);
		validator.Length(x => x.EquipmentLength, 4, 5);
		validator.Length(x => x.CurrencyCode, 3);
		validator.Length(x => x.FreightRate, 1, 9);
		return validator.Results;
	}
}

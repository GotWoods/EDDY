using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("SDQ")]
public class SDQ_DestinationQuantity : EdiX12Segment
{
	[Position(01)]
	public string UnitOfMeasurementCode { get; set; }

	[Position(02)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(03)]
	public string IdentificationCode { get; set; }

	[Position(04)]
	public decimal? Quantity { get; set; }

	[Position(05)]
	public string IdentificationCode2 { get; set; }

	[Position(06)]
	public decimal? Quantity2 { get; set; }

	[Position(07)]
	public string IdentificationCode3 { get; set; }

	[Position(08)]
	public decimal? Quantity3 { get; set; }

	[Position(09)]
	public string IdentificationCode4 { get; set; }

	[Position(10)]
	public decimal? Quantity4 { get; set; }

	[Position(11)]
	public string IdentificationCode5 { get; set; }

	[Position(12)]
	public decimal? Quantity5 { get; set; }

	[Position(13)]
	public string IdentificationCode6 { get; set; }

	[Position(14)]
	public decimal? Quantity6 { get; set; }

	[Position(15)]
	public string IdentificationCode7 { get; set; }

	[Position(16)]
	public decimal? Quantity7 { get; set; }

	[Position(17)]
	public string IdentificationCode8 { get; set; }

	[Position(18)]
	public decimal? Quantity8 { get; set; }

	[Position(19)]
	public string IdentificationCode9 { get; set; }

	[Position(20)]
	public decimal? Quantity9 { get; set; }

	[Position(21)]
	public string IdentificationCode10 { get; set; }

	[Position(22)]
	public decimal? Quantity10 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SDQ_DestinationQuantity>(this);
		validator.Required(x=>x.UnitOfMeasurementCode);
		validator.Required(x=>x.IdentificationCode);
		validator.Required(x=>x.Quantity);
		validator.Length(x => x.UnitOfMeasurementCode, 2);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 17);
		validator.Length(x => x.Quantity, 1, 10);
		validator.Length(x => x.IdentificationCode2, 2, 17);
		validator.Length(x => x.Quantity2, 1, 10);
		validator.Length(x => x.IdentificationCode3, 2, 17);
		validator.Length(x => x.Quantity3, 1, 10);
		validator.Length(x => x.IdentificationCode4, 2, 17);
		validator.Length(x => x.Quantity4, 1, 10);
		validator.Length(x => x.IdentificationCode5, 2, 17);
		validator.Length(x => x.Quantity5, 1, 10);
		validator.Length(x => x.IdentificationCode6, 2, 17);
		validator.Length(x => x.Quantity6, 1, 10);
		validator.Length(x => x.IdentificationCode7, 2, 17);
		validator.Length(x => x.Quantity7, 1, 10);
		validator.Length(x => x.IdentificationCode8, 2, 17);
		validator.Length(x => x.Quantity8, 1, 10);
		validator.Length(x => x.IdentificationCode9, 2, 17);
		validator.Length(x => x.Quantity9, 1, 10);
		validator.Length(x => x.IdentificationCode10, 2, 17);
		validator.Length(x => x.Quantity10, 1, 10);
		return validator.Results;
	}
}

using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("CR5")]
public class CR5_OxygenTherapyCertification : EdiX12Segment
{
	[Position(01)]
	public string CertificationTypeCode { get; set; }

	[Position(02)]
	public decimal? Quantity { get; set; }

	[Position(03)]
	public string OxygenEquipmentTypeCode { get; set; }

	[Position(04)]
	public string OxygenEquipmentTypeCode2 { get; set; }

	[Position(05)]
	public string Description { get; set; }

	[Position(06)]
	public decimal? Quantity2 { get; set; }

	[Position(07)]
	public decimal? Quantity3 { get; set; }

	[Position(08)]
	public decimal? Quantity4 { get; set; }

	[Position(09)]
	public string Description2 { get; set; }

	[Position(10)]
	public decimal? Quantity5 { get; set; }

	[Position(11)]
	public decimal? Quantity6 { get; set; }

	[Position(12)]
	public string OxygenTestConditionCode { get; set; }

	[Position(13)]
	public string OxygenTestFindingsCode { get; set; }

	[Position(14)]
	public string OxygenTestFindingsCode2 { get; set; }

	[Position(15)]
	public string OxygenTestFindingsCode3 { get; set; }

	[Position(16)]
	public decimal? Quantity7 { get; set; }

	[Position(17)]
	public string OxygenDeliverySystemCode { get; set; }

	[Position(18)]
	public string OxygenEquipmentTypeCode3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CR5_OxygenTherapyCertification>(this);
		validator.Length(x => x.CertificationTypeCode, 1);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.OxygenEquipmentTypeCode, 1);
		validator.Length(x => x.OxygenEquipmentTypeCode2, 1);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.Quantity2, 1, 15);
		validator.Length(x => x.Quantity3, 1, 15);
		validator.Length(x => x.Quantity4, 1, 15);
		validator.Length(x => x.Description2, 1, 80);
		validator.Length(x => x.Quantity5, 1, 15);
		validator.Length(x => x.Quantity6, 1, 15);
		validator.Length(x => x.OxygenTestConditionCode, 1);
		validator.Length(x => x.OxygenTestFindingsCode, 1);
		validator.Length(x => x.OxygenTestFindingsCode2, 1);
		validator.Length(x => x.OxygenTestFindingsCode3, 1);
		validator.Length(x => x.Quantity7, 1, 15);
		validator.Length(x => x.OxygenDeliverySystemCode, 1);
		validator.Length(x => x.OxygenEquipmentTypeCode3, 1);
		return validator.Results;
	}
}
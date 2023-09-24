using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("F07")]
public class F07_AutoClaimDetail : EdiX12Segment
{
	[Position(01)]
	public int? AssignedNumber { get; set; }

	[Position(02)]
	public decimal? Quantity { get; set; }

	[Position(03)]
	public string ProductServiceID { get; set; }

	[Position(04)]
	public string PartName { get; set; }

	[Position(05)]
	public string Amount { get; set; }

	[Position(06)]
	public string DamageAreaCode { get; set; }

	[Position(07)]
	public string DamageTypeCode { get; set; }

	[Position(08)]
	public string DamageSeverityCode { get; set; }

	[Position(09)]
	public string LaborOperationIdentifier { get; set; }

	[Position(10)]
	public string FreeFormDescription { get; set; }

	[Position(11)]
	public string LaborHours { get; set; }

	[Position(12)]
	public string LaborHours2 { get; set; }

	[Position(13)]
	public string TotalLaborCost { get; set; }

	[Position(14)]
	public string TotalMiscellaneousCosts { get; set; }

	[Position(15)]
	public string TotalRepairCost { get; set; }

	[Position(16)]
	public string AuthorizationIdentification { get; set; }

	[Position(17)]
	public string InspectionLocationTypeCode { get; set; }

	[Position(18)]
	public string DamageAreaCode2 { get; set; }

	[Position(19)]
	public string DamageTypeCode2 { get; set; }

	[Position(20)]
	public string DamageSeverityCode2 { get; set; }

	[Position(21)]
	public string DeclineAmendReasonCode { get; set; }

	[Position(22)]
	public string ChargeAllowanceQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<F07_AutoClaimDetail>(this);
		validator.Required(x=>x.AssignedNumber);
		validator.Required(x=>x.DamageAreaCode);
		validator.Required(x=>x.DamageTypeCode);
		validator.Required(x=>x.DamageSeverityCode);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.LaborHours, x=>x.LaborHours2, x=>x.TotalLaborCost);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.TotalLaborCost, x=>x.LaborHours, x=>x.LaborHours2);
		validator.Required(x=>x.TotalRepairCost);
		validator.Length(x => x.AssignedNumber, 1, 6);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.ProductServiceID, 1, 30);
		validator.Length(x => x.PartName, 3, 16);
		validator.Length(x => x.Amount, 1, 9);
		validator.Length(x => x.DamageAreaCode, 2);
		validator.Length(x => x.DamageTypeCode, 2);
		validator.Length(x => x.DamageSeverityCode, 1);
		validator.Length(x => x.LaborOperationIdentifier, 5, 6);
		validator.Length(x => x.FreeFormDescription, 1, 45);
		validator.Length(x => x.LaborHours, 1, 3);
		validator.Length(x => x.LaborHours2, 1, 3);
		validator.Length(x => x.TotalLaborCost, 3, 6);
		validator.Length(x => x.TotalMiscellaneousCosts, 2, 6);
		validator.Length(x => x.TotalRepairCost, 3, 9);
		validator.Length(x => x.AuthorizationIdentification, 1, 4);
		validator.Length(x => x.InspectionLocationTypeCode, 1, 2);
		validator.Length(x => x.DamageAreaCode2, 2);
		validator.Length(x => x.DamageTypeCode2, 2);
		validator.Length(x => x.DamageSeverityCode2, 1);
		validator.Length(x => x.DeclineAmendReasonCode, 3);
		validator.Length(x => x.ChargeAllowanceQualifier, 2);
		return validator.Results;
	}
}

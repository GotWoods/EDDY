using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("SSS")]
public class SSS_SpecialServices : EdiX12Segment
{
	[Position(01)]
	public string AllowanceOrChargeIndicator { get; set; }

	[Position(02)]
	public string AssociationQualifierCode { get; set; }

	[Position(03)]
	public string SpecialServicesCode { get; set; }

	[Position(04)]
	public string ServiceMarksAndNumbers { get; set; }

	[Position(05)]
	public decimal? AllowanceOrChargeRate { get; set; }

	[Position(06)]
	public string AllowanceOrChargeTotalAmount { get; set; }

	[Position(07)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SSS_SpecialServices>(this);
		validator.Required(x=>x.AllowanceOrChargeIndicator);
		validator.Required(x=>x.AssociationQualifierCode);
		validator.Required(x=>x.SpecialServicesCode);
		validator.Length(x => x.AllowanceOrChargeIndicator, 1);
		validator.Length(x => x.AssociationQualifierCode, 2);
		validator.Length(x => x.SpecialServicesCode, 2, 10);
		validator.Length(x => x.ServiceMarksAndNumbers, 1, 45);
		validator.Length(x => x.AllowanceOrChargeRate, 1, 9);
		validator.Length(x => x.AllowanceOrChargeTotalAmount, 1, 9);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}

using Eddy.Core.Attributes;
using Eddy.Core.Validation;

using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("FSA")]
public class FSA_TaxAdvantageAccount : EdiX12Segment
{
	[Position(01)]
	public string MaintenanceTypeCode { get; set; }

	[Position(02)]
	public string FlexibleSpendingAccountSelectionCode { get; set; }

	[Position(03)]
	public string MaintenanceReasonCode { get; set; }

	[Position(04)]
	public C062_TaxAdvantageAccountInformation TaxAdvantageAccountInformation { get; set; }

	[Position(05)]
	public string FrequencyCode { get; set; }

	[Position(06)]
	public string PlanCoverageDescription { get; set; }

	[Position(07)]
	public string ProductOptionCode { get; set; }

	[Position(08)]
	public string ProductOptionCode2 { get; set; }

	[Position(09)]
	public string ProductOptionCode3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FSA_TaxAdvantageAccount>(this);
		validator.Required(x=>x.MaintenanceTypeCode);
		validator.Length(x => x.MaintenanceTypeCode, 3);
		validator.Length(x => x.FlexibleSpendingAccountSelectionCode, 1);
		validator.Length(x => x.MaintenanceReasonCode, 2, 3);
		validator.Length(x => x.FrequencyCode, 1);
		validator.Length(x => x.PlanCoverageDescription, 1, 50);
		validator.Length(x => x.ProductOptionCode, 1, 2);
		validator.Length(x => x.ProductOptionCode2, 1, 2);
		validator.Length(x => x.ProductOptionCode3, 1, 2);
		return validator.Results;
	}
}

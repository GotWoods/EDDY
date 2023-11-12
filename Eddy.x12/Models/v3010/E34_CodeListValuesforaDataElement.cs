using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("E34")]
public class E34_CodeListValuesForADataElement : EdiX12Segment
{
	[Position(01)]
	public string MaintenanceOperationCode { get; set; }

	[Position(02)]
	public string CodeValue { get; set; }

	[Position(03)]
	public string PartitionIndicator { get; set; }

	[Position(04)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E34_CodeListValuesForADataElement>(this);
		validator.Required(x=>x.MaintenanceOperationCode);
		validator.Required(x=>x.CodeValue);
		validator.Required(x=>x.Description);
		validator.Length(x => x.MaintenanceOperationCode, 1);
		validator.Length(x => x.CodeValue, 1, 8);
		validator.Length(x => x.PartitionIndicator, 1, 80);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}

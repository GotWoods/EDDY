using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("E12")]
public class E12_SectionIndicator : EdiX12Segment
{
	[Position(01)]
	public string MaintenanceOperationCode { get; set; }

	[Position(02)]
	public int? PositionInSet { get; set; }

	[Position(03)]
	public string SectionDesignator { get; set; }

	[Position(04)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E12_SectionIndicator>(this);
		validator.Required(x=>x.MaintenanceOperationCode);
		validator.Required(x=>x.PositionInSet);
		validator.Required(x=>x.SectionDesignator);
		validator.Length(x => x.MaintenanceOperationCode, 1);
		validator.Length(x => x.PositionInSet, 1, 6);
		validator.Length(x => x.SectionDesignator, 1);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}

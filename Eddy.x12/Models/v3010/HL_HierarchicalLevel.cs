using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("HL")]
public class HL_HierarchicalLevel : EdiX12Segment
{
	[Position(01)]
	public string HierarchicalIDNumber { get; set; }

	[Position(02)]
	public string HierarchicalParentIDNumber { get; set; }

	[Position(03)]
	public string HierarchicalLevelCode { get; set; }

	[Position(04)]
	public string HierarchicalChildCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<HL_HierarchicalLevel>(this);
		validator.Required(x=>x.HierarchicalIDNumber);
		validator.Required(x=>x.HierarchicalLevelCode);
		validator.Length(x => x.HierarchicalIDNumber, 1, 12);
		validator.Length(x => x.HierarchicalParentIDNumber, 1, 12);
		validator.Length(x => x.HierarchicalLevelCode, 1, 2);
		validator.Length(x => x.HierarchicalChildCode, 1);
		return validator.Results;
	}
}

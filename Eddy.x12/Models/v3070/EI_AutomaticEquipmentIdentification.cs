using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("EI")]
public class EI_AutomaticEquipmentIdentification : EdiX12Segment
{
	[Position(01)]
	public int? Count { get; set; }

	[Position(02)]
	public string EquipmentInitial { get; set; }

	[Position(03)]
	public string EquipmentNumber { get; set; }

	[Position(04)]
	public string EquipmentOrientationCode { get; set; }

	[Position(05)]
	public string Position { get; set; }

	[Position(06)]
	public string TagStatusCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<EI_AutomaticEquipmentIdentification>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.EquipmentInitial, x=>x.EquipmentNumber);
		validator.Length(x => x.Count, 1, 9);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 10);
		validator.Length(x => x.EquipmentOrientationCode, 1);
		validator.Length(x => x.Position, 1, 3);
		validator.Length(x => x.TagStatusCode, 1);
		return validator.Results;
	}
}

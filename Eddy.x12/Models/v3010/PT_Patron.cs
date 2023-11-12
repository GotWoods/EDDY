using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("PT")]
public class PT_Patron : EdiX12Segment
{
	[Position(01)]
	public string ConditionSegmentLogicalConnector { get; set; }

	[Position(02)]
	public string EntityIdentifierCode { get; set; }

	[Position(03)]
	public string Name30CharacterFormat { get; set; }

	[Position(04)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(05)]
	public string ReferenceNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PT_Patron>(this);
		validator.Required(x=>x.ConditionSegmentLogicalConnector);
		validator.Required(x=>x.EntityIdentifierCode);
		validator.Required(x=>x.Name30CharacterFormat);
		validator.Length(x => x.ConditionSegmentLogicalConnector, 2, 3);
		validator.Length(x => x.EntityIdentifierCode, 2);
		validator.Length(x => x.Name30CharacterFormat, 2, 30);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		return validator.Results;
	}
}

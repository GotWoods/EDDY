using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("GOV")]
public class GOV_MilitaryStandard1840ARecordDefinition : EdiX12Segment
{
	[Position(01)]
	public string AgencyQualifierCode { get; set; }

	[Position(02)]
	public string RecordFileQualifier { get; set; }

	[Position(03)]
	public string RecordFormatData { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<GOV_MilitaryStandard1840ARecordDefinition>(this);
		validator.Required(x=>x.AgencyQualifierCode);
		validator.Length(x => x.AgencyQualifierCode, 2);
		validator.Length(x => x.RecordFileQualifier, 1, 30);
		validator.Length(x => x.RecordFormatData, 1, 80);
		return validator.Results;
	}
}

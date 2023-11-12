using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("E01")]
public class E01_ElectronicFormMainHeading : EdiX12Segment
{
	[Position(01)]
	public string MaintenanceOperationCode { get; set; }

	[Position(02)]
	public string ElectronicFormStandardsTypeCode { get; set; }

	[Position(03)]
	public string VersionReleaseIndustryIdentifierCode { get; set; }

	[Position(04)]
	public string FullOrPartialIndicator { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E01_ElectronicFormMainHeading>(this);
		validator.Required(x=>x.MaintenanceOperationCode);
		validator.Required(x=>x.ElectronicFormStandardsTypeCode);
		validator.Required(x=>x.VersionReleaseIndustryIdentifierCode);
		validator.Required(x=>x.FullOrPartialIndicator);
		validator.Length(x => x.MaintenanceOperationCode, 1);
		validator.Length(x => x.ElectronicFormStandardsTypeCode, 1);
		validator.Length(x => x.VersionReleaseIndustryIdentifierCode, 1, 12);
		validator.Length(x => x.FullOrPartialIndicator, 1);
		return validator.Results;
	}
}

using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("PKD")]
public class PKD_PackagingDescription : EdiX12Segment
{
	[Position(01)]
	public string PackagingCode { get; set; }

	[Position(02)]
	public string SourceSubqualifier { get; set; }

	[Position(03)]
	public string AgencyQualifierCode { get; set; }

	[Position(04)]
	public string PackagingDescriptionCode { get; set; }

	[Position(05)]
	public string OwnershipCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PKD_PackagingDescription>(this);
		validator.ARequiresB(x=>x.SourceSubqualifier, x=>x.PackagingCode);
		validator.ARequiresB(x=>x.AgencyQualifierCode, x=>x.SourceSubqualifier);
		validator.Length(x => x.PackagingCode, 5);
		validator.Length(x => x.SourceSubqualifier, 1, 15);
		validator.Length(x => x.AgencyQualifierCode, 2);
		validator.Length(x => x.PackagingDescriptionCode, 1, 7);
		validator.Length(x => x.OwnershipCode, 1);
		return validator.Results;
	}
}

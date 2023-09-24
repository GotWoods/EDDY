using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("PKG")]
public class PKG_MarkingPackagingLoading : EdiX12Segment
{
	[Position(01)]
	public string ItemDescriptionType { get; set; }

	[Position(02)]
	public string PackagingCharacteristicCode { get; set; }

	[Position(03)]
	public string AssociationQualifierCode { get; set; }

	[Position(04)]
	public string PackagingDescriptionCode { get; set; }

	[Position(05)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PKG_MarkingPackagingLoading>(this);
		validator.Required(x=>x.ItemDescriptionType);
		validator.Length(x => x.ItemDescriptionType, 1);
		validator.Length(x => x.PackagingCharacteristicCode, 1, 5);
		validator.Length(x => x.AssociationQualifierCode, 2);
		validator.Length(x => x.PackagingDescriptionCode, 1, 7);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}

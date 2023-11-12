using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("PKG")]
public class PKG_MarkingPackagingLoading : EdiX12Segment
{
	[Position(01)]
	public string ItemDescriptionType { get; set; }

	[Position(02)]
	public string PackagingCharacteristicCode { get; set; }

	[Position(03)]
	public string AgencyQualifierCode { get; set; }

	[Position(04)]
	public string PackagingDescriptionCode { get; set; }

	[Position(05)]
	public string Description { get; set; }

	[Position(06)]
	public string UnitLoadOptionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PKG_MarkingPackagingLoading>(this);
		validator.ARequiresB(x=>x.PackagingDescriptionCode, x=>x.AgencyQualifierCode);
		validator.ARequiresB(x=>x.Description, x=>x.ItemDescriptionType);
		validator.Length(x => x.ItemDescriptionType, 1);
		validator.Length(x => x.PackagingCharacteristicCode, 1, 5);
		validator.Length(x => x.AgencyQualifierCode, 2);
		validator.Length(x => x.PackagingDescriptionCode, 1, 7);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.UnitLoadOptionCode, 2);
		return validator.Results;
	}
}

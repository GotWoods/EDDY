using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("PAC")]
public class PAC_Package : EdifactSegment
{
	[Position(1)]
	public string PackageQuantity { get; set; }

	[Position(2)]
	public C531_PackagingDetails PackagingDetails { get; set; }

	[Position(3)]
	public C202_PackageType PackageType { get; set; }

	[Position(4)]
	public C402_PackageTypeIdentification PackageTypeIdentification { get; set; }

	[Position(5)]
	public C532_ReturnablePackageDetails ReturnablePackageDetails { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PAC_Package>(this);
		validator.Length(x => x.PackageQuantity, 1, 8);
		return validator.Results;
	}
}

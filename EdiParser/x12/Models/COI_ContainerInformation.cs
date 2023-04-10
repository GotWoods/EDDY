using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("COI")]
public class COI_ContainerInformation : EdiX12Segment
{
	[Position(01)]
	public string PackagingCode { get; set; }

	[Position(02)]
	public string ContainerMaterialColor { get; set; }

	[Position(03)]
	public string ClosureType { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<COI_ContainerInformation>(this);
		validator.Length(x => x.PackagingCode, 3, 5);
		validator.Length(x => x.ContainerMaterialColor, 2, 3);
		validator.Length(x => x.ClosureType, 2, 3);
		return validator.Results;
	}
}

using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C402")]
public class C402_PackageTypeIdentification : EdifactComponent
{
	[Position(1)]
	public string DescriptionFormatCode { get; set; }

	[Position(2)]
	public string TypeOfPackages { get; set; }

	[Position(3)]
	public string ItemTypeIdentificationCode { get; set; }

	[Position(4)]
	public string TypeOfPackages2 { get; set; }

	[Position(5)]
	public string ItemTypeIdentificationCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C402_PackageTypeIdentification>(this);
		validator.Required(x=>x.DescriptionFormatCode);
		validator.Required(x=>x.TypeOfPackages);
		validator.Length(x => x.DescriptionFormatCode, 1, 3);
		validator.Length(x => x.TypeOfPackages, 1, 35);
		validator.Length(x => x.ItemTypeIdentificationCode, 1, 3);
		validator.Length(x => x.TypeOfPackages2, 1, 35);
		validator.Length(x => x.ItemTypeIdentificationCode2, 1, 3);
		return validator.Results;
	}
}

using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4020.Composites;

[Segment("C053")]
public class C053_StandardsInformation : EdiX12Component
{
	[Position(00)]
	public string ElectronicFormStandardsTypeCode { get; set; }

	[Position(01)]
	public string ElectronicFormStandardsIdentifier { get; set; }

	[Position(02)]
	public string ImplementationConventionReference { get; set; }

	[Position(03)]
	public string VersionIdentifier { get; set; }

	[Position(04)]
	public string RevisionValue { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C053_StandardsInformation>(this);
		validator.Required(x=>x.ElectronicFormStandardsTypeCode);
		validator.Required(x=>x.ElectronicFormStandardsIdentifier);
		validator.Required(x=>x.ImplementationConventionReference);
		validator.Length(x => x.ElectronicFormStandardsTypeCode, 1);
		validator.Length(x => x.ElectronicFormStandardsIdentifier, 1, 15);
		validator.Length(x => x.ImplementationConventionReference, 1, 35);
		validator.Length(x => x.VersionIdentifier, 1, 30);
		validator.Length(x => x.RevisionValue, 1, 30);
		return validator.Results;
	}
}

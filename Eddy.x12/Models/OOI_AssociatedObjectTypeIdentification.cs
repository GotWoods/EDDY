using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("OOI")]
public class OOI_AssociatedObjectTypeIdentification : EdiX12Segment
{
	[Position(01)]
	public string ObjectIdentificationGroup { get; set; }

	[Position(02)]
	public string ObjectTypeQualifier { get; set; }

	[Position(03)]
	public string ObjectAttributeIdentification { get; set; }

	[Position(04)]
	public string ControllingAgencyCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<OOI_AssociatedObjectTypeIdentification>(this);
		validator.Required(x=>x.ObjectIdentificationGroup);
		validator.Required(x=>x.ObjectTypeQualifier);
		validator.Required(x=>x.ObjectAttributeIdentification);
		validator.Length(x => x.ObjectIdentificationGroup, 1, 2);
		validator.Length(x => x.ObjectTypeQualifier, 1, 3);
		validator.Length(x => x.ObjectAttributeIdentification, 1, 256);
		validator.Length(x => x.ControllingAgencyCode, 1, 3);
		return validator.Results;
	}
}

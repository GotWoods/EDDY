using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("NAM")]
public class NAM_PartyName : EdifactSegment
{
	[Position(1)]
	public string PartyFunctionCodeQualifier { get; set; }

	[Position(2)]
	public E206_ObjectIdentification ObjectIdentification { get; set; }

	[Position(3)]
	public E082_PartyIdentificationDetails PartyIdentificationDetails { get; set; }

	[Position(4)]
	public string NameTypeCoded { get; set; }

	[Position(5)]
	public string NameStatusCoded { get; set; }

	[Position(6)]
	public E816_NameComponentDetails NameComponentDetails { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<NAM_PartyName>(this);
		validator.Required(x=>x.PartyFunctionCodeQualifier);
		validator.Length(x => x.PartyFunctionCodeQualifier, 1, 3);
		validator.Length(x => x.NameTypeCoded, 1, 3);
		validator.Length(x => x.NameStatusCoded, 1, 3);
		return validator.Results;
	}
}

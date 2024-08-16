using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("PNA")]
public class PNA_PartyIdentification : EdifactSegment
{
	[Position(1)]
	public string PartyFunctionCodeQualifier { get; set; }

	[Position(2)]
	public C206_IdentificationNumber IdentificationNumber { get; set; }

	[Position(3)]
	public C082_PartyIdentificationDetails PartyIdentificationDetails { get; set; }

	[Position(4)]
	public string NameTypeCode { get; set; }

	[Position(5)]
	public string NameStatusCoded { get; set; }

	[Position(6)]
	public C816_NameComponentDetails NameComponentDetails { get; set; }

	[Position(7)]
	public C816_NameComponentDetails NameComponentDetails2 { get; set; }

	[Position(8)]
	public C816_NameComponentDetails NameComponentDetails3 { get; set; }

	[Position(9)]
	public C816_NameComponentDetails NameComponentDetails4 { get; set; }

	[Position(10)]
	public C816_NameComponentDetails NameComponentDetails5 { get; set; }

	[Position(11)]
	public string ActionRequestNotificationDescriptionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PNA_PartyIdentification>(this);
		validator.Required(x=>x.PartyFunctionCodeQualifier);
		validator.Length(x => x.PartyFunctionCodeQualifier, 1, 3);
		validator.Length(x => x.NameTypeCode, 1, 3);
		validator.Length(x => x.NameStatusCoded, 1, 3);
		validator.Length(x => x.ActionRequestNotificationDescriptionCode, 1, 3);
		return validator.Results;
	}
}

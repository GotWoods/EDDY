using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("USH")]
public class USH_SecurityHeader : EdifactSegment
{
	[Position(1)]
	public string SecurityServiceCoded { get; set; }

	[Position(2)]
	public string SecurityReferenceNumber { get; set; }

	[Position(3)]
	public string ScopeOfSecurityApplicationCoded { get; set; }

	[Position(4)]
	public string ResponseTypeCoded { get; set; }

	[Position(5)]
	public string FilterFunctionCoded { get; set; }

	[Position(6)]
	public string OriginalCharacterSetEncodingCoded { get; set; }

	[Position(7)]
	public string RoleOfSecurityProviderCoded { get; set; }

	[Position(8)]
	public S500_SecurityIdentificationDetails SecurityIdentificationDetails { get; set; }

	[Position(9)]
	public string SecuritySequenceNumber { get; set; }

	[Position(10)]
	public S501_SecurityDateAndTime SecurityDateAndTime { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<USH_SecurityHeader>(this);
		validator.Required(x=>x.SecurityServiceCoded);
		validator.Required(x=>x.SecurityReferenceNumber);
		validator.Length(x => x.SecurityServiceCoded, 1, 3);
		validator.Length(x => x.SecurityReferenceNumber, 1, 14);
		validator.Length(x => x.ScopeOfSecurityApplicationCoded, 1, 3);
		validator.Length(x => x.ResponseTypeCoded, 1, 3);
		validator.Length(x => x.FilterFunctionCoded, 1, 3);
		validator.Length(x => x.OriginalCharacterSetEncodingCoded, 1, 3);
		validator.Length(x => x.RoleOfSecurityProviderCoded, 1, 3);
		validator.Length(x => x.SecuritySequenceNumber, 1, 35);
		return validator.Results;
	}
}

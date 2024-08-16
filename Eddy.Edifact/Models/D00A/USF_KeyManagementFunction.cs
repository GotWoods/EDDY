using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("USF")]
public class USF_KeyManagementFunction : EdifactSegment
{
	[Position(1)]
	public string KeyManagementFunctionQualifier { get; set; }

	[Position(2)]
	public S504_ListParameter ListParameter { get; set; }

	[Position(3)]
	public string SecurityStatusCoded { get; set; }

	[Position(4)]
	public string CertificateSequenceNumber { get; set; }

	[Position(5)]
	public string FilterFunctionCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<USF_KeyManagementFunction>(this);
		validator.Length(x => x.KeyManagementFunctionQualifier, 1, 3);
		validator.Length(x => x.SecurityStatusCoded, 1, 3);
		validator.Length(x => x.CertificateSequenceNumber, 1, 4);
		validator.Length(x => x.FilterFunctionCoded, 1, 3);
		return validator.Results;
	}
}

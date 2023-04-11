using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("G85")]
public class G85_RecordIntegrityCheck : EdiX12Segment
{
	[Position(01)]
	public string IntegrityCheckValue { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G85_RecordIntegrityCheck>(this);
		validator.Required(x=>x.IntegrityCheckValue);
		validator.Length(x => x.IntegrityCheckValue, 1, 12);
		return validator.Results;
	}
}

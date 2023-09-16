using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("N9")]
public class N9_ReferenceNumber : EdiX12Segment
{
	[Position(01)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(02)]
	public string ReferenceNumber { get; set; }

	[Position(03)]
	public string FreeFormDescription { get; set; }

	[Position(04)]
	public string Date { get; set; }

	[Position(05)]
	public string Time { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<N9_ReferenceNumber>(this);
		validator.Required(x=>x.ReferenceNumberQualifier);
		validator.AtLeastOneIsRequired(x=>x.ReferenceNumber, x=>x.FreeFormDescription);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.FreeFormDescription, 1, 45);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Time, 4, 6);
		return validator.Results;
	}
}

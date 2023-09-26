using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5030;

[Segment("SHI")]
public class SHI_SecurityHoldingInformation : EdiX12Segment
{
	[Position(01)]
	public string SecurityHoldingTypeCode { get; set; }

	[Position(02)]
	public string Name { get; set; }

	[Position(03)]
	public string ReferenceIdentification { get; set; }

	[Position(04)]
	public string ProductTransferTypeCode { get; set; }

	[Position(05)]
	public string StatusCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SHI_SecurityHoldingInformation>(this);
		validator.Required(x=>x.SecurityHoldingTypeCode);
		validator.AtLeastOneIsRequired(x=>x.Name, x=>x.ReferenceIdentification);
		validator.Length(x => x.SecurityHoldingTypeCode, 1, 2);
		validator.Length(x => x.Name, 1, 60);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.ProductTransferTypeCode, 2);
		validator.Length(x => x.StatusCode, 2);
		return validator.Results;
	}
}

using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("LH")]
public class LH_MixedHazardousCommodities : EdiX12Segment
{
	[Position(01)]
	public int? LadingLineItemNumber { get; set; }

	[Position(02)]
	public string HazardousMnemonicCode { get; set; }

	[Position(03)]
	public string ReferenceIdentification { get; set; }

	[Position(04)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(05)]
	public string ReportableQuantityCode { get; set; }

	[Position(06)]
	public string LimitedQuantityIndicationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LH_MixedHazardousCommodities>(this);
		validator.Required(x=>x.LadingLineItemNumber);
		validator.Required(x=>x.HazardousMnemonicCode);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Required(x=>x.ReferenceIdentificationQualifier);
		validator.Length(x => x.LadingLineItemNumber, 1, 6);
		validator.Length(x => x.HazardousMnemonicCode, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReportableQuantityCode, 2);
		validator.Length(x => x.LimitedQuantityIndicationCode, 1);
		return validator.Results;
	}
}

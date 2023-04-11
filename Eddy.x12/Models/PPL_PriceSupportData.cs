using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("PPL")]
public class PPL_PriceSupportData : EdiX12Segment
{
	[Position(01)]
	public string AcquisitionDataCode { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string Date2 { get; set; }

	[Position(04)]
	public string Description { get; set; }

	[Position(05)]
	public string ProposalDataDetailIdentifierCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PPL_PriceSupportData>(this);
		validator.Length(x => x.AcquisitionDataCode, 2);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Date2, 8);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.ProposalDataDetailIdentifierCode, 1, 3);
		return validator.Results;
	}
}

using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("PBI")]
public class PBI_ProblemIdentification : EdiX12Segment
{
	[Position(01)]
	public string ReferenceNumber { get; set; }

	[Position(02)]
	public string ActionCode { get; set; }

	[Position(03)]
	public string FreeFormMessageText { get; set; }

	[Position(04)]
	public string TaxInformationIdentificationNumber { get; set; }

	[Position(05)]
	public decimal? Quantity { get; set; }

	[Position(06)]
	public string FixedFormatInformation { get; set; }

	[Position(07)]
	public decimal? Quantity2 { get; set; }

	[Position(08)]
	public string FixedFormatInformation2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PBI_ProblemIdentification>(this);
		validator.AtLeastOneIsRequired(x=>x.ReferenceNumber, x=>x.ActionCode);
		validator.OnlyOneOf(x=>x.Quantity, x=>x.FixedFormatInformation);
		validator.OnlyOneOf(x=>x.Quantity2, x=>x.FixedFormatInformation2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.ActionCode, 1);
		validator.Length(x => x.FreeFormMessageText, 1, 264);
		validator.Length(x => x.TaxInformationIdentificationNumber, 1, 30);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.FixedFormatInformation, 1, 80);
		validator.Length(x => x.Quantity2, 1, 15);
		validator.Length(x => x.FixedFormatInformation2, 1, 80);
		return validator.Results;
	}
}

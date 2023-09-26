using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("PEN")]
public class PEN_PensionInformation : EdiX12Segment
{
	[Position(01)]
	public string TransactionTypeCode { get; set; }

	[Position(02)]
	public decimal? MonetaryAmount { get; set; }

	[Position(03)]
	public string ContributionCode { get; set; }

	[Position(04)]
	public decimal? Percent { get; set; }

	[Position(05)]
	public string SpecialProcessingType { get; set; }

	[Position(06)]
	public string ReferenceNumber { get; set; }

	[Position(07)]
	public int? Number { get; set; }

	[Position(08)]
	public string LoanTypeCode { get; set; }

	[Position(09)]
	public string MaintenanceTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PEN_PensionInformation>(this);
		validator.Required(x=>x.TransactionTypeCode);
		validator.AtLeastOneIsRequired(x=>x.MonetaryAmount, x=>x.Percent);
		validator.Length(x => x.TransactionTypeCode, 2);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.ContributionCode, 2);
		validator.Length(x => x.Percent, 1, 10);
		validator.Length(x => x.SpecialProcessingType, 1, 6);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.Number, 1, 9);
		validator.Length(x => x.LoanTypeCode, 1, 2);
		validator.Length(x => x.MaintenanceTypeCode, 3);
		return validator.Results;
	}
}

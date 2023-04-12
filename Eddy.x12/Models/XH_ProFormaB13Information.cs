using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("XH")]
public class XH_ProFormaB13Information : EdiX12Segment
{
	[Position(01)]
	public string CurrencyCode { get; set; }

	[Position(02)]
	public string RelatedCompanyIndicationCode { get; set; }

	[Position(03)]
	public string SpecialChargeOrAllowanceCode { get; set; }

	[Position(04)]
	public string Amount { get; set; }

	[Position(05)]
	public string Block20Code { get; set; }

	[Position(06)]
	public string ChemicalAnalysisPercentage { get; set; }

	[Position(07)]
	public decimal? UnitPrice { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<XH_ProFormaB13Information>(this);
		validator.Required(x=>x.CurrencyCode);
		validator.Length(x => x.CurrencyCode, 3);
		validator.Length(x => x.RelatedCompanyIndicationCode, 1);
		validator.Length(x => x.SpecialChargeOrAllowanceCode, 3);
		validator.Length(x => x.Amount, 1, 15);
		validator.Length(x => x.Block20Code, 1);
		validator.Length(x => x.ChemicalAnalysisPercentage, 2, 9);
		validator.Length(x => x.UnitPrice, 1, 17);
		return validator.Results;
	}
}

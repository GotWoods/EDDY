using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("BT1")]
public class BT1_BatchTotals : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetIdentifierCode { get; set; }

	[Position(02)]
	public int? NumberOfTransactionSetsTotalled { get; set; }

	[Position(03)]
	public string TotalQualifier { get; set; }

	[Position(04)]
	public string DataElementTotalled { get; set; }

	[Position(05)]
	public decimal? Total { get; set; }

	[Position(06)]
	public string TotalQualifier2 { get; set; }

	[Position(07)]
	public string DataElementTotalled2 { get; set; }

	[Position(08)]
	public decimal? Total2 { get; set; }

	[Position(09)]
	public string TotalQualifier3 { get; set; }

	[Position(10)]
	public string DataElementTotalled3 { get; set; }

	[Position(11)]
	public decimal? Total3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BT1_BatchTotals>(this);
		validator.Required(x=>x.TransactionSetIdentifierCode);
		validator.Required(x=>x.NumberOfTransactionSetsTotalled);
		validator.Required(x=>x.TotalQualifier);
		validator.Required(x=>x.Total);
		validator.IfOneIsFilled_AllAreRequired(x=>x.TotalQualifier2, x=>x.Total2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.TotalQualifier3, x=>x.Total3);
		validator.Length(x => x.TransactionSetIdentifierCode, 3);
		validator.Length(x => x.NumberOfTransactionSetsTotalled, 1, 7);
		validator.Length(x => x.TotalQualifier, 1);
		validator.Length(x => x.DataElementTotalled, 4, 5);
		validator.Length(x => x.Total, 1, 11);
		validator.Length(x => x.TotalQualifier2, 1);
		validator.Length(x => x.DataElementTotalled2, 4, 5);
		validator.Length(x => x.Total2, 1, 11);
		validator.Length(x => x.TotalQualifier3, 1);
		validator.Length(x => x.DataElementTotalled3, 4, 5);
		validator.Length(x => x.Total3, 1, 11);
		return validator.Results;
	}
}

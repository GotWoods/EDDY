using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("CF1")]
public class CF1_BeginningSegmentForSummaryFreightBillManifest : EdiX12Segment
{
	[Position(01)]
	public string MasterReferenceLinkNumber { get; set; }

	[Position(02)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(03)]
	public string Date { get; set; }

	[Position(04)]
	public int? Count { get; set; }

	[Position(05)]
	public string Amount { get; set; }

	[Position(06)]
	public string Date2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CF1_BeginningSegmentForSummaryFreightBillManifest>(this);
		validator.Required(x=>x.MasterReferenceLinkNumber);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Length(x => x.MasterReferenceLinkNumber, 1, 22);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Count, 1, 9);
		validator.Length(x => x.Amount, 1, 15);
		validator.Length(x => x.Date2, 8);
		return validator.Results;
	}
}

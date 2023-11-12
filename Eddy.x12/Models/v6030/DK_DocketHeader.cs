using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v6030;

[Segment("DK")]
public class DK_DocketHeader : EdiX12Segment
{
	[Position(01)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(02)]
	public string DocketControlNumber { get; set; }

	[Position(03)]
	public string DocketIdentification { get; set; }

	[Position(04)]
	public int? RevisionNumber { get; set; }

	[Position(05)]
	public string ConveyanceCode { get; set; }

	[Position(06)]
	public string DocketTypeCode { get; set; }

	[Position(07)]
	public string Date { get; set; }

	[Position(08)]
	public string Date2 { get; set; }

	[Position(09)]
	public string ApplicationTypeCode { get; set; }

	[Position(10)]
	public string GroupTitle { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DK_DocketHeader>(this);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Required(x=>x.DocketControlNumber);
		validator.Required(x=>x.DocketIdentification);
		validator.Required(x=>x.RevisionNumber);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.DocketControlNumber, 1, 7);
		validator.Length(x => x.DocketIdentification, 1, 11);
		validator.Length(x => x.RevisionNumber, 1, 4);
		validator.Length(x => x.ConveyanceCode, 1);
		validator.Length(x => x.DocketTypeCode, 1);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Date2, 8);
		validator.Length(x => x.ApplicationTypeCode, 2);
		validator.Length(x => x.GroupTitle, 2, 30);
		return validator.Results;
	}
}

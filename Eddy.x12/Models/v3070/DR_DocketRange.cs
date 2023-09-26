using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("DR")]
public class DR_DocketRange : EdiX12Segment
{
	[Position(01)]
	public string Date { get; set; }

	[Position(02)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(03)]
	public string DocketControlNumber { get; set; }

	[Position(04)]
	public string DocketIdentification { get; set; }

	[Position(05)]
	public int? RevisionNumber { get; set; }

	[Position(06)]
	public string DocketIdentification2 { get; set; }

	[Position(07)]
	public int? Century { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DR_DocketRange>(this);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Required(x=>x.DocketControlNumber);
		validator.Required(x=>x.DocketIdentification);
		validator.AtLeastOneIsRequired(x=>x.DocketIdentification2, x=>x.RevisionNumber);
		validator.OnlyOneOf(x=>x.DocketIdentification2, x=>x.RevisionNumber);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.DocketControlNumber, 1, 7);
		validator.Length(x => x.DocketIdentification, 1, 11);
		validator.Length(x => x.RevisionNumber, 1, 4);
		validator.Length(x => x.DocketIdentification2, 1, 11);
		validator.Length(x => x.Century, 2);
		return validator.Results;
	}
}

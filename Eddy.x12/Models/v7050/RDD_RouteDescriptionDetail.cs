using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v7050;

[Segment("RDD")]
public class RDD_RouteDescriptionDetail : EdiX12Segment
{
	[Position(01)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(02)]
	public string Rule260JunctionCode { get; set; }

	[Position(03)]
	public string StandardCarrierAlphaCode2 { get; set; }

	[Position(04)]
	public string Rule260JunctionCode2 { get; set; }

	[Position(05)]
	public int? AssignedNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RDD_RouteDescriptionDetail>(this);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.ARequiresB(x=>x.Rule260JunctionCode2, x=>x.StandardCarrierAlphaCode2);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.Rule260JunctionCode, 1, 5);
		validator.Length(x => x.StandardCarrierAlphaCode2, 2, 4);
		validator.Length(x => x.Rule260JunctionCode2, 1, 5);
		validator.Length(x => x.AssignedNumber, 1, 9);
		return validator.Results;
	}
}

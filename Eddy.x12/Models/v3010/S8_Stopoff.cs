using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("S8")]
public class S8_StopOff : EdiX12Segment
{
	[Position(01)]
	public int? StopSequenceNumber { get; set; }

	[Position(02)]
	public string StopReasonCode { get; set; }

	[Position(03)]
	public int? StopOffWeight { get; set; }

	[Position(04)]
	public string WeightQualifier { get; set; }

	[Position(05)]
	public int? LadingQuantity { get; set; }

	[Position(06)]
	public string PackagingCode { get; set; }

	[Position(07)]
	public string StopReasonDescription { get; set; }

	[Position(08)]
	public string Name { get; set; }

	[Position(09)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(10)]
	public string IdentificationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<S8_StopOff>(this);
		validator.Required(x=>x.StopSequenceNumber);
		validator.Required(x=>x.StopReasonCode);
		validator.Required(x=>x.StopOffWeight);
		validator.Required(x=>x.WeightQualifier);
		validator.Length(x => x.StopSequenceNumber, 1, 2);
		validator.Length(x => x.StopReasonCode, 2);
		validator.Length(x => x.StopOffWeight, 3, 8);
		validator.Length(x => x.WeightQualifier, 1, 2);
		validator.Length(x => x.LadingQuantity, 1, 7);
		validator.Length(x => x.PackagingCode, 5);
		validator.Length(x => x.StopReasonDescription, 2, 20);
		validator.Length(x => x.Name, 1, 35);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 17);
		return validator.Results;
	}
}

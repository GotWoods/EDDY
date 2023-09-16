using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("SRC")]
public class SRC_ScaleRateColumnID : EdiX12Segment
{
	[Position(01)]
	public string RateValueQualifier { get; set; }

	[Position(02)]
	public string Scale { get; set; }

	[Position(03)]
	public string Scale2 { get; set; }

	[Position(04)]
	public string Scale3 { get; set; }

	[Position(05)]
	public string Scale4 { get; set; }

	[Position(06)]
	public string Scale5 { get; set; }

	[Position(07)]
	public string Scale6 { get; set; }

	[Position(08)]
	public string Scale7 { get; set; }

	[Position(09)]
	public string Scale8 { get; set; }

	[Position(10)]
	public string Scale9 { get; set; }

	[Position(11)]
	public string Scale10 { get; set; }

	[Position(12)]
	public string Scale11 { get; set; }

	[Position(13)]
	public string Scale12 { get; set; }

	[Position(14)]
	public string Scale13 { get; set; }

	[Position(15)]
	public string Scale14 { get; set; }

	[Position(16)]
	public string Scale15 { get; set; }

	[Position(17)]
	public string Scale16 { get; set; }

	[Position(18)]
	public string Scale17 { get; set; }

	[Position(19)]
	public string Scale18 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SRC_ScaleRateColumnID>(this);
		validator.Required(x=>x.RateValueQualifier);
		validator.Required(x=>x.Scale);
		validator.Length(x => x.RateValueQualifier, 2);
		validator.Length(x => x.Scale, 1, 10);
		validator.Length(x => x.Scale2, 1, 10);
		validator.Length(x => x.Scale3, 1, 10);
		validator.Length(x => x.Scale4, 1, 10);
		validator.Length(x => x.Scale5, 1, 10);
		validator.Length(x => x.Scale6, 1, 10);
		validator.Length(x => x.Scale7, 1, 10);
		validator.Length(x => x.Scale8, 1, 10);
		validator.Length(x => x.Scale9, 1, 10);
		validator.Length(x => x.Scale10, 1, 10);
		validator.Length(x => x.Scale11, 1, 10);
		validator.Length(x => x.Scale12, 1, 10);
		validator.Length(x => x.Scale13, 1, 10);
		validator.Length(x => x.Scale14, 1, 10);
		validator.Length(x => x.Scale15, 1, 10);
		validator.Length(x => x.Scale16, 1, 10);
		validator.Length(x => x.Scale17, 1, 10);
		validator.Length(x => x.Scale18, 1, 10);
		return validator.Results;
	}
}

using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("ISC")]
public class ISC_InterlineServiceCommitmentDetail : EdiX12Segment
{
	[Position(01)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(02)]
	public string StandardPointLocationCode { get; set; }

	[Position(03)]
	public string EventCode { get; set; }

	[Position(04)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(05)]
	public string DateTimePeriod { get; set; }

	[Position(06)]
	public string Time { get; set; }

	[Position(07)]
	public int? NumberOfDays { get; set; }

	[Position(08)]
	public string StandardCarrierAlphaCode2 { get; set; }

	[Position(09)]
	public string InterchangeTrainIdentification { get; set; }

	[Position(10)]
	public string BlockIdentifier { get; set; }

	[Position(11)]
	public string CityName { get; set; }

	[Position(12)]
	public string StateOrProvinceCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ISC_InterlineServiceCommitmentDetail>(this);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Required(x=>x.StandardPointLocationCode);
		validator.Required(x=>x.EventCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod);
		validator.IfOneIsFilled_AllAreRequired(x=>x.CityName, x=>x.StateOrProvinceCode);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.StandardPointLocationCode, 6, 9);
		validator.Length(x => x.EventCode, 3);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.NumberOfDays, 1, 3);
		validator.Length(x => x.StandardCarrierAlphaCode2, 2, 4);
		validator.Length(x => x.InterchangeTrainIdentification, 1, 10);
		validator.Length(x => x.BlockIdentifier, 1, 12);
		validator.Length(x => x.CityName, 2, 30);
		validator.Length(x => x.StateOrProvinceCode, 2);
		return validator.Results;
	}
}

using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("TST")]
public class TST_TestScoreRecord : EdiX12Segment
{
	[Position(01)]
	public string StudentTestCode { get; set; }

	[Position(02)]
	public string Name { get; set; }

	[Position(03)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(04)]
	public string DateTimePeriod { get; set; }

	[Position(05)]
	public string ReferenceNumber { get; set; }

	[Position(06)]
	public string ReferenceNumber2 { get; set; }

	[Position(07)]
	public string LevelOfIndividualOrTestCode { get; set; }

	[Position(08)]
	public string LevelOfIndividualOrTestCode2 { get; set; }

	[Position(09)]
	public string DateTimePeriod2 { get; set; }

	[Position(10)]
	public string TestNormTypeCode { get; set; }

	[Position(11)]
	public string TestNormingPeriodCode { get; set; }

	[Position(12)]
	public string LanguageCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TST_TestScoreRecord>(this);
		validator.Required(x=>x.StudentTestCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod);
		validator.Length(x => x.StudentTestCode, 1, 3);
		validator.Length(x => x.Name, 1, 35);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.ReferenceNumber2, 1, 30);
		validator.Length(x => x.LevelOfIndividualOrTestCode, 2);
		validator.Length(x => x.LevelOfIndividualOrTestCode2, 2);
		validator.Length(x => x.DateTimePeriod2, 1, 35);
		validator.Length(x => x.TestNormTypeCode, 1);
		validator.Length(x => x.TestNormingPeriodCode, 1);
		validator.Length(x => x.LanguageCode, 2, 3);
		return validator.Results;
	}
}

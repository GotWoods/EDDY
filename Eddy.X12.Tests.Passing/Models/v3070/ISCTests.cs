using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class ISCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ISC*iP*jHIevu*D5p*8z*5*Ixl1*3*Gi*N*Q";

		var expected = new ISC_InterlineServiceCommitmentDetail()
		{
			StandardCarrierAlphaCode = "iP",
			StandardPointLocationCode = "jHIevu",
			EventCode = "D5p",
			DateTimePeriodFormatQualifier = "8z",
			DateTimePeriod = "5",
			Time = "Ixl1",
			NumberOfDays = 3,
			StandardCarrierAlphaCode2 = "Gi",
			InterchangeTrainIdentification = "N",
			BlockIdentification = "Q",
		};

		var actual = Map.MapObject<ISC_InterlineServiceCommitmentDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("iP", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new ISC_InterlineServiceCommitmentDetail();
		//Required fields
		subject.StandardPointLocationCode = "jHIevu";
		subject.EventCode = "D5p";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "8z";
			subject.DateTimePeriod = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jHIevu", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new ISC_InterlineServiceCommitmentDetail();
		//Required fields
		subject.StandardCarrierAlphaCode = "iP";
		subject.EventCode = "D5p";
		//Test Parameters
		subject.StandardPointLocationCode = standardPointLocationCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "8z";
			subject.DateTimePeriod = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D5p", true)]
	public void Validation_RequiredEventCode(string eventCode, bool isValidExpected)
	{
		var subject = new ISC_InterlineServiceCommitmentDetail();
		//Required fields
		subject.StandardCarrierAlphaCode = "iP";
		subject.StandardPointLocationCode = "jHIevu";
		//Test Parameters
		subject.EventCode = eventCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "8z";
			subject.DateTimePeriod = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("8z", "5", true)]
	[InlineData("8z", "", false)]
	[InlineData("", "5", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new ISC_InterlineServiceCommitmentDetail();
		//Required fields
		subject.StandardCarrierAlphaCode = "iP";
		subject.StandardPointLocationCode = "jHIevu";
		subject.EventCode = "D5p";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

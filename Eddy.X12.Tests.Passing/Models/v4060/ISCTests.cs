using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.Tests.Models.v4060;

public class ISCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ISC*hg*s0KMSX*NAC*Vz*l*YF93*1*zg*X*D";

		var expected = new ISC_InterlineServiceCommitmentDetail()
		{
			StandardCarrierAlphaCode = "hg",
			StandardPointLocationCode = "s0KMSX",
			EventCode = "NAC",
			DateTimePeriodFormatQualifier = "Vz",
			DateTimePeriod = "l",
			Time = "YF93",
			NumberOfDays = 1,
			StandardCarrierAlphaCode2 = "zg",
			InterchangeTrainIdentification = "X",
			BlockIdentifier = "D",
		};

		var actual = Map.MapObject<ISC_InterlineServiceCommitmentDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hg", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new ISC_InterlineServiceCommitmentDetail();
		//Required fields
		subject.StandardPointLocationCode = "s0KMSX";
		subject.EventCode = "NAC";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "Vz";
			subject.DateTimePeriod = "l";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s0KMSX", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new ISC_InterlineServiceCommitmentDetail();
		//Required fields
		subject.StandardCarrierAlphaCode = "hg";
		subject.EventCode = "NAC";
		//Test Parameters
		subject.StandardPointLocationCode = standardPointLocationCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "Vz";
			subject.DateTimePeriod = "l";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("NAC", true)]
	public void Validation_RequiredEventCode(string eventCode, bool isValidExpected)
	{
		var subject = new ISC_InterlineServiceCommitmentDetail();
		//Required fields
		subject.StandardCarrierAlphaCode = "hg";
		subject.StandardPointLocationCode = "s0KMSX";
		//Test Parameters
		subject.EventCode = eventCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "Vz";
			subject.DateTimePeriod = "l";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Vz", "l", true)]
	[InlineData("Vz", "", false)]
	[InlineData("", "l", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new ISC_InterlineServiceCommitmentDetail();
		//Required fields
		subject.StandardCarrierAlphaCode = "hg";
		subject.StandardPointLocationCode = "s0KMSX";
		subject.EventCode = "NAC";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

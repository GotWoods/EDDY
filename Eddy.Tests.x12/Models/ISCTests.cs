using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ISCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ISC*H5*rjUcwH*RAe*jR*r*ooNt*8*ND*h*p*IX*9k";

		var expected = new ISC_InterlineServiceCommitmentDetail()
		{
			StandardCarrierAlphaCode = "H5",
			StandardPointLocationCode = "rjUcwH",
			EventCode = "RAe",
			DateTimePeriodFormatQualifier = "jR",
			DateTimePeriod = "r",
			Time = "ooNt",
			NumberOfDays = 8,
			StandardCarrierAlphaCode2 = "ND",
			InterchangeTrainIdentification = "h",
			BlockIdentifier = "p",
			CityName = "IX",
			StateOrProvinceCode = "9k",
		};

		var actual = Map.MapObject<ISC_InterlineServiceCommitmentDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H5", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new ISC_InterlineServiceCommitmentDetail();
		subject.StandardPointLocationCode = "rjUcwH";
		subject.EventCode = "RAe";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rjUcwH", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new ISC_InterlineServiceCommitmentDetail();
		subject.StandardCarrierAlphaCode = "H5";
		subject.EventCode = "RAe";
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("RAe", true)]
	public void Validation_RequiredEventCode(string eventCode, bool isValidExpected)
	{
		var subject = new ISC_InterlineServiceCommitmentDetail();
		subject.StandardCarrierAlphaCode = "H5";
		subject.StandardPointLocationCode = "rjUcwH";
		subject.EventCode = eventCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("jR", "r", true)]
	[InlineData("", "r", false)]
	[InlineData("jR", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new ISC_InterlineServiceCommitmentDetail();
		subject.StandardCarrierAlphaCode = "H5";
		subject.StandardPointLocationCode = "rjUcwH";
		subject.EventCode = "RAe";
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("IX", "9k", true)]
	[InlineData("", "9k", false)]
	[InlineData("IX", "", false)]
	public void Validation_AllAreRequiredCityName(string cityName, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new ISC_InterlineServiceCommitmentDetail();
		subject.StandardCarrierAlphaCode = "H5";
		subject.StandardPointLocationCode = "rjUcwH";
		subject.EventCode = "RAe";
		subject.CityName = cityName;
		subject.StateOrProvinceCode = stateOrProvinceCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

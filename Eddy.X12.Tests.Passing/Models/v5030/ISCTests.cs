using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class ISCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ISC*XH*54w2Oe*L1Q*ZJ*q*UDip*8*HZ*2*7*mh*Jm";

		var expected = new ISC_InterlineServiceCommitmentDetail()
		{
			StandardCarrierAlphaCode = "XH",
			StandardPointLocationCode = "54w2Oe",
			EventCode = "L1Q",
			DateTimePeriodFormatQualifier = "ZJ",
			DateTimePeriod = "q",
			Time = "UDip",
			NumberOfDays = 8,
			StandardCarrierAlphaCode2 = "HZ",
			InterchangeTrainIdentification = "2",
			BlockIdentifier = "7",
			CityName = "mh",
			StateOrProvinceCode = "Jm",
		};

		var actual = Map.MapObject<ISC_InterlineServiceCommitmentDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("XH", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new ISC_InterlineServiceCommitmentDetail();
		//Required fields
		subject.StandardPointLocationCode = "54w2Oe";
		subject.EventCode = "L1Q";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "ZJ";
			subject.DateTimePeriod = "q";
		}
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "mh";
			subject.StateOrProvinceCode = "Jm";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("54w2Oe", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new ISC_InterlineServiceCommitmentDetail();
		//Required fields
		subject.StandardCarrierAlphaCode = "XH";
		subject.EventCode = "L1Q";
		//Test Parameters
		subject.StandardPointLocationCode = standardPointLocationCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "ZJ";
			subject.DateTimePeriod = "q";
		}
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "mh";
			subject.StateOrProvinceCode = "Jm";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L1Q", true)]
	public void Validation_RequiredEventCode(string eventCode, bool isValidExpected)
	{
		var subject = new ISC_InterlineServiceCommitmentDetail();
		//Required fields
		subject.StandardCarrierAlphaCode = "XH";
		subject.StandardPointLocationCode = "54w2Oe";
		//Test Parameters
		subject.EventCode = eventCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "ZJ";
			subject.DateTimePeriod = "q";
		}
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "mh";
			subject.StateOrProvinceCode = "Jm";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ZJ", "q", true)]
	[InlineData("ZJ", "", false)]
	[InlineData("", "q", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new ISC_InterlineServiceCommitmentDetail();
		//Required fields
		subject.StandardCarrierAlphaCode = "XH";
		subject.StandardPointLocationCode = "54w2Oe";
		subject.EventCode = "L1Q";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "mh";
			subject.StateOrProvinceCode = "Jm";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("mh", "Jm", true)]
	[InlineData("mh", "", false)]
	[InlineData("", "Jm", false)]
	public void Validation_AllAreRequiredCityName(string cityName, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new ISC_InterlineServiceCommitmentDetail();
		//Required fields
		subject.StandardCarrierAlphaCode = "XH";
		subject.StandardPointLocationCode = "54w2Oe";
		subject.EventCode = "L1Q";
		//Test Parameters
		subject.CityName = cityName;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "ZJ";
			subject.DateTimePeriod = "q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

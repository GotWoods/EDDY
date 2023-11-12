using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class XFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "XF*9z*E*te*1k*l5*lL*GEvrGD*KRFy";

		var expected = new XF_SwitchAccomplishedInformation()
		{
			SwitchTypeCode = "9z",
			PlacePullIdentifierCode = "E",
			Zone = "te",
			Track = "1k",
			Spot = "l5",
			StandardCarrierAlphaCode = "lL",
			Date = "GEvrGD",
			Time = "KRFy",
		};

		var actual = Map.MapObject<XF_SwitchAccomplishedInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9z", true)]
	public void Validation_RequiredSwitchTypeCode(string switchTypeCode, bool isValidExpected)
	{
		var subject = new XF_SwitchAccomplishedInformation();
		//Required fields
		subject.PlacePullIdentifierCode = "E";
		subject.Date = "GEvrGD";
		subject.Time = "KRFy";
		//Test Parameters
		subject.SwitchTypeCode = switchTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredPlacePullIdentifierCode(string placePullIdentifierCode, bool isValidExpected)
	{
		var subject = new XF_SwitchAccomplishedInformation();
		//Required fields
		subject.SwitchTypeCode = "9z";
		subject.Date = "GEvrGD";
		subject.Time = "KRFy";
		//Test Parameters
		subject.PlacePullIdentifierCode = placePullIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("GEvrGD", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new XF_SwitchAccomplishedInformation();
		//Required fields
		subject.SwitchTypeCode = "9z";
		subject.PlacePullIdentifierCode = "E";
		subject.Time = "KRFy";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("KRFy", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new XF_SwitchAccomplishedInformation();
		//Required fields
		subject.SwitchTypeCode = "9z";
		subject.PlacePullIdentifierCode = "E";
		subject.Date = "GEvrGD";
		//Test Parameters
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

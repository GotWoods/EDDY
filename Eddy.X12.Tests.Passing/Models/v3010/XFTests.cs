using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class XFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "XF*gV*f*DJ*K5*uO*80*2qVzmq*bA1H";

		var expected = new XF_SwitchAccomplishedInformation()
		{
			SwitchTypeCode = "gV",
			PlacePullIdentifierCode = "f",
			Zone = "DJ",
			Track = "K5",
			Spot = "uO",
			StandardCarrierAlphaCode = "80",
			Date = "2qVzmq",
			Time = "bA1H",
		};

		var actual = Map.MapObject<XF_SwitchAccomplishedInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("gV", true)]
	public void Validation_RequiredSwitchTypeCode(string switchTypeCode, bool isValidExpected)
	{
		var subject = new XF_SwitchAccomplishedInformation();
		//Required fields
		subject.PlacePullIdentifierCode = "f";
		subject.Date = "2qVzmq";
		subject.Time = "bA1H";
		//Test Parameters
		subject.SwitchTypeCode = switchTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredPlacePullIdentifierCode(string placePullIdentifierCode, bool isValidExpected)
	{
		var subject = new XF_SwitchAccomplishedInformation();
		//Required fields
		subject.SwitchTypeCode = "gV";
		subject.Date = "2qVzmq";
		subject.Time = "bA1H";
		//Test Parameters
		subject.PlacePullIdentifierCode = placePullIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2qVzmq", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new XF_SwitchAccomplishedInformation();
		//Required fields
		subject.SwitchTypeCode = "gV";
		subject.PlacePullIdentifierCode = "f";
		subject.Time = "bA1H";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bA1H", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new XF_SwitchAccomplishedInformation();
		//Required fields
		subject.SwitchTypeCode = "gV";
		subject.PlacePullIdentifierCode = "f";
		subject.Date = "2qVzmq";
		//Test Parameters
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

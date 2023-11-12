using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class XFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "XF*Hj*m*Fr*JV*EP*sN*W4SysT*R9Hf";

		var expected = new XF_SwitchAccomplishedInformation()
		{
			SwitchTypeCode = "Hj",
			PlacePullIdentifierCode = "m",
			Zone = "Fr",
			Track = "JV",
			Spot = "EP",
			StandardCarrierAlphaCode = "sN",
			Date = "W4SysT",
			Time = "R9Hf",
		};

		var actual = Map.MapObject<XF_SwitchAccomplishedInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Hj", true)]
	public void Validation_RequiredSwitchTypeCode(string switchTypeCode, bool isValidExpected)
	{
		var subject = new XF_SwitchAccomplishedInformation();
		//Required fields
		subject.PlacePullIdentifierCode = "m";
		subject.Date = "W4SysT";
		subject.Time = "R9Hf";
		//Test Parameters
		subject.SwitchTypeCode = switchTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredPlacePullIdentifierCode(string placePullIdentifierCode, bool isValidExpected)
	{
		var subject = new XF_SwitchAccomplishedInformation();
		//Required fields
		subject.SwitchTypeCode = "Hj";
		subject.Date = "W4SysT";
		subject.Time = "R9Hf";
		//Test Parameters
		subject.PlacePullIdentifierCode = placePullIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W4SysT", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new XF_SwitchAccomplishedInformation();
		//Required fields
		subject.SwitchTypeCode = "Hj";
		subject.PlacePullIdentifierCode = "m";
		subject.Time = "R9Hf";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R9Hf", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new XF_SwitchAccomplishedInformation();
		//Required fields
		subject.SwitchTypeCode = "Hj";
		subject.PlacePullIdentifierCode = "m";
		subject.Date = "W4SysT";
		//Test Parameters
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

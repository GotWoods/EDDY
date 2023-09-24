using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BLRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BLR*BG*8Hxqv6";

		var expected = new BLR_BeginningSegmentLoadingAndRouteGuide()
		{
			StandardCarrierAlphaCode = "BG",
			Date = "8Hxqv6",
		};

		var actual = Map.MapObject<BLR_BeginningSegmentLoadingAndRouteGuide>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("BG", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BLR_BeginningSegmentLoadingAndRouteGuide();
		subject.Date = "8Hxqv6";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8Hxqv6", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BLR_BeginningSegmentLoadingAndRouteGuide();
		subject.StandardCarrierAlphaCode = "BG";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

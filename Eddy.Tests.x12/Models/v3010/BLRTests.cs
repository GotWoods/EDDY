using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BLRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BLR*O9*XSaQNp";

		var expected = new BLR_BeginningSegmentLoadingAndRouteGuide()
		{
			StandardCarrierAlphaCode = "O9",
			Date = "XSaQNp",
		};

		var actual = Map.MapObject<BLR_BeginningSegmentLoadingAndRouteGuide>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O9", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BLR_BeginningSegmentLoadingAndRouteGuide();
		subject.Date = "XSaQNp";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("XSaQNp", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BLR_BeginningSegmentLoadingAndRouteGuide();
		subject.StandardCarrierAlphaCode = "O9";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

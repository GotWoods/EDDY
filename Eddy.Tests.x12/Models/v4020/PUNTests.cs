using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class PUNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PUN*fl*D3kGEE0D*XYLJ*3*gW8o";

		var expected = new PUN_BeginningSegmentForMotorCarrierPickUpNotification()
		{
			StandardCarrierAlphaCode = "fl",
			Date = "D3kGEE0D",
			Time = "XYLJ",
			ReferenceIdentification = "3",
			Time2 = "gW8o",
		};

		var actual = Map.MapObject<PUN_BeginningSegmentForMotorCarrierPickUpNotification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fl", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new PUN_BeginningSegmentForMotorCarrierPickUpNotification();
		//Required fields
		subject.Date = "D3kGEE0D";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D3kGEE0D", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new PUN_BeginningSegmentForMotorCarrierPickUpNotification();
		//Required fields
		subject.StandardCarrierAlphaCode = "fl";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

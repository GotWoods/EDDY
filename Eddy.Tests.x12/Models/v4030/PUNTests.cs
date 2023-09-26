using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class PUNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PUN*yp*1ZvUtRbd*YLEe*Q*QSIZ";

		var expected = new PUN_BeginningSegmentForMotorCarrierPickUpNotification()
		{
			StandardCarrierAlphaCode = "yp",
			Date = "1ZvUtRbd",
			Time = "YLEe",
			ReferenceIdentification = "Q",
			Time2 = "QSIZ",
		};

		var actual = Map.MapObject<PUN_BeginningSegmentForMotorCarrierPickUpNotification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yp", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new PUN_BeginningSegmentForMotorCarrierPickUpNotification();
		//Required fields
		subject.Date = "1ZvUtRbd";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1ZvUtRbd", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new PUN_BeginningSegmentForMotorCarrierPickUpNotification();
		//Required fields
		subject.StandardCarrierAlphaCode = "yp";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

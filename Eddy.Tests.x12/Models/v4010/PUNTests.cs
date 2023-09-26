using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class PUNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PUN*M8*cE19Iitu*81y7*q";

		var expected = new PUN_BeginningSegmentForMotorCarrierPickUpNotification()
		{
			StandardCarrierAlphaCode = "M8",
			Date = "cE19Iitu",
			Time = "81y7",
			ReferenceIdentification = "q",
		};

		var actual = Map.MapObject<PUN_BeginningSegmentForMotorCarrierPickUpNotification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M8", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new PUN_BeginningSegmentForMotorCarrierPickUpNotification();
		//Required fields
		subject.Date = "cE19Iitu";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("cE19Iitu", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new PUN_BeginningSegmentForMotorCarrierPickUpNotification();
		//Required fields
		subject.StandardCarrierAlphaCode = "M8";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

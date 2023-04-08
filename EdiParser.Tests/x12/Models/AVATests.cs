using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class AVATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AVA*6*8";

		var expected = new AVA_FundsAvailability()
		{
			MonetaryAmount = 6,
			Availability = 8,
		};

		var actual = Map.MapObject<AVA_FundsAvailability>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validatation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new AVA_FundsAvailability();
		subject.Availability = 8;
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validatation_RequiredAvailability(decimal availability, bool isValidExpected)
	{
		var subject = new AVA_FundsAvailability();
		subject.MonetaryAmount = 6;
		if (availability > 0)
		subject.Availability = availability;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

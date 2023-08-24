using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class AVATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AVA*5*3";

		var expected = new AVA_FundsAvailability()
		{
			MonetaryAmount = 5,
			Availability = 3,
		};

		var actual = Map.MapObject<AVA_FundsAvailability>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new AVA_FundsAvailability();
		subject.Availability = 3;
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredAvailability(decimal availability, bool isValidExpected)
	{
		var subject = new AVA_FundsAvailability();
		subject.MonetaryAmount = 5;
		if (availability > 0)
		subject.Availability = availability;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

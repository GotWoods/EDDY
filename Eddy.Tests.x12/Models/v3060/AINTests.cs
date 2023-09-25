using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class AINTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AIN*D9*l*1*5*K*e*d";

		var expected = new AIN_Income()
		{
			TypeOfIncomeCode = "D9",
			FrequencyCode = "l",
			MonetaryAmount = 1,
			Quantity = 5,
			YesNoConditionOrResponseCode = "K",
			ReferenceIdentification = "e",
			AmountQualifierCode = "d",
		};

		var actual = Map.MapObject<AIN_Income>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D9", true)]
	public void Validation_RequiredTypeOfIncomeCode(string typeOfIncomeCode, bool isValidExpected)
	{
		var subject = new AIN_Income();
		//Required fields
		subject.FrequencyCode = "l";
		subject.MonetaryAmount = 1;
		//Test Parameters
		subject.TypeOfIncomeCode = typeOfIncomeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredFrequencyCode(string frequencyCode, bool isValidExpected)
	{
		var subject = new AIN_Income();
		//Required fields
		subject.TypeOfIncomeCode = "D9";
		subject.MonetaryAmount = 1;
		//Test Parameters
		subject.FrequencyCode = frequencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new AIN_Income();
		//Required fields
		subject.TypeOfIncomeCode = "D9";
		subject.FrequencyCode = "l";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

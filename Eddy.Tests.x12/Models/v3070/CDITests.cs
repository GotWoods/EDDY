using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class CDITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CDI*a**k*7LL*lt*1*6*2*p4*d";

		var expected = new CDI_ChangeDetailInformation()
		{
			OptionTypeCode = "a",
			ConditionsIndicated = null,
			ConvertibilityRateTypeCode = "k",
			StatusReasonCode = "7LL",
			RateValueQualifier = "lt",
			Quantity = 1,
			Number = 6,
			Number2 = 2,
			IndexIdentityCode = "p4",
			FreeFormMessageText = "d",
		};

		var actual = Map.MapObject<CDI_ChangeDetailInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("lt", 1, true)]
	[InlineData("lt", 0, false)]
	[InlineData("", 1, false)]
	public void Validation_AllAreRequiredRateValueQualifier(string rateValueQualifier, decimal quantity, bool isValidExpected)
	{
		var subject = new CDI_ChangeDetailInformation();
		//Required fields
		//Test Parameters
		subject.RateValueQualifier = rateValueQualifier;
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(2, 6, true)]
	[InlineData(2, 0, false)]
	[InlineData(0, 6, true)]
	public void Validation_ARequiresBNumber2(int number2, int number, bool isValidExpected)
	{
		var subject = new CDI_ChangeDetailInformation();
		//Required fields
		//Test Parameters
		if (number2 > 0) 
			subject.Number2 = number2;
		if (number > 0) 
			subject.Number = number;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.Quantity > 0)
		{
			subject.RateValueQualifier = "lt";
			subject.Quantity = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

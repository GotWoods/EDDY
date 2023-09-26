using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class CDITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CDI*t**5*yvk*WX*1*7*9*1f*Zj*g";

		var expected = new CDI_ChangeDetailInformation()
		{
			OptionTypeCode = "t",
			ConditionsIndicated = null,
			ConvertibilityRateTypeCode = "5",
			StatusReasonCode = "yvk",
			RateValueQualifier = "WX",
			Quantity = 1,
			Number = 7,
			Number2 = 9,
			IndexIdentityCode = "1f",
			PrimarySourceOfIndexCode = "Zj",
			Description = "g",
		};

		var actual = Map.MapObject<CDI_ChangeDetailInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("WX", 1, true)]
	[InlineData("WX", 0, false)]
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
	[InlineData(9, 7, true)]
	[InlineData(9, 0, false)]
	[InlineData(0, 7, true)]
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
			subject.RateValueQualifier = "WX";
			subject.Quantity = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

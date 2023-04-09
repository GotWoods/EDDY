using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;
using EdiParser.x12.Models.Elements;

namespace EdiParser.Tests.x12.Models;

public class CDITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CDI*c**R*DGq*87*3*5*8*2P*3m*M";

		var expected = new CDI_ChangeDetailInformation()
		{
			OptionTypeCode = "c",
			ConditionsIndicated = new C045_ConditionsIndicated() {},
			ConvertibilityRateTypeCode = "R",
			StatusReasonCode = "DGq",
			RateValueQualifier = "87",
			Quantity = 3,
			Number = 5,
			Number2 = 8,
			IndexIdentityCode = "2P",
			PrimarySourceOfIndexCode = "3m",
			Description = "M",
		};

		var actual = Map.MapObject<CDI_ChangeDetailInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		try
		{
			Assert.Equivalent(expected, actual);
		}
		catch
		{
			Assert.Fail(actual.ValidationResult.ToString());
		}
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("87", 3, true)]
	[InlineData("", 3, false)]
	[InlineData("87", 0, false)]
	public void Validation_AllAreRequiredRateValueQualifier(string rateValueQualifier, decimal quantity, bool isValidExpected)
	{
		var subject = new CDI_ChangeDetailInformation();
		subject.RateValueQualifier = rateValueQualifier;
		if (quantity > 0)
		subject.Quantity = quantity;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(0, 5, true)]
	[InlineData(8, 0, false)]
	public void Validation_ARequiresBNumber2(int number2, int number, bool isValidExpected)
	{
		var subject = new CDI_ChangeDetailInformation();
		if (number2 > 0)
		subject.Number2 = number2;
		if (number > 0)
		subject.Number = number;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.Tests.Models.v4060;

public class AP1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AP1*VX*VB*hWb*1*6*StC*LC5*wt*2*1*J*K*c";

		var expected = new AP1_AlternateParts()
		{
			ConditionIndicator = "VX",
			StateOrProvinceCode = "VB",
			PriceIdentifierCode = "hWb",
			PercentageAsDecimal = 1,
			MonetaryAmount = 6,
			PostalCode = "StC",
			PostalCode2 = "LC5",
			PrintOptionCode = "wt",
			Number = 2,
			Quantity = 1,
			FreeFormInformation = "J",
			ProductServiceID = "K",
			Description = "c",
		};

		var actual = Map.MapObject<AP1_AlternateParts>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("VX", true)]
	public void Validation_RequiredConditionIndicator(string conditionIndicator, bool isValidExpected)
	{
		var subject = new AP1_AlternateParts();
		//Required fields
		//Test Parameters
		subject.ConditionIndicator = conditionIndicator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("LC5", "StC", true)]
	[InlineData("LC5", "", false)]
	[InlineData("", "StC", true)]
	public void Validation_ARequiresBPostalCode2(string postalCode2, string postalCode, bool isValidExpected)
	{
		var subject = new AP1_AlternateParts();
		//Required fields
		subject.ConditionIndicator = "VX";
		//Test Parameters
		subject.PostalCode2 = postalCode2;
		subject.PostalCode = postalCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

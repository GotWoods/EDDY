using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class RDITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RDI*dY*Ae*7*V*a";

		var expected = new RDI_RetailAccountDemographicInformation()
		{
			EntityIdentifierCode = "dY",
			CountryCode = "Ae",
			AmountQualifierCode = "7",
			Amount = "V",
			Description = "a",
		};

		var actual = Map.MapObject<RDI_RetailAccountDemographicInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dY", true)]
	public void Validation_RequiredEntityIdentifierCode(string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new RDI_RetailAccountDemographicInformation();
		//Required fields
		//Test Parameters
		subject.EntityIdentifierCode = entityIdentifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.AmountQualifierCode = "7";
			subject.Amount = "V";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("7", "V", true)]
	[InlineData("7", "", false)]
	[InlineData("", "V", false)]
	public void Validation_AllAreRequiredAmountQualifierCode(string amountQualifierCode, string amount, bool isValidExpected)
	{
		var subject = new RDI_RetailAccountDemographicInformation();
		//Required fields
		subject.EntityIdentifierCode = "dY";
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		subject.Amount = amount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

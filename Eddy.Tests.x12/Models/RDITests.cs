using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class RDITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RDI*F7*q5*R*g*C";

		var expected = new RDI_RetailAccountDemographicInformation()
		{
			EntityIdentifierCode = "F7",
			CountryCode = "q5",
			AmountQualifierCode = "R",
			Amount = "g",
			Description = "C",
		};

		var actual = Map.MapObject<RDI_RetailAccountDemographicInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F7", true)]
	public void Validation_RequiredEntityIdentifierCode(string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new RDI_RetailAccountDemographicInformation();
		subject.EntityIdentifierCode = entityIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("R", "g", true)]
	[InlineData("", "g", false)]
	[InlineData("R", "", false)]
	public void Validation_AllAreRequiredAmountQualifierCode(string amountQualifierCode, string amount, bool isValidExpected)
	{
		var subject = new RDI_RetailAccountDemographicInformation();
		subject.EntityIdentifierCode = "F7";
		subject.AmountQualifierCode = amountQualifierCode;
		subject.Amount = amount;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

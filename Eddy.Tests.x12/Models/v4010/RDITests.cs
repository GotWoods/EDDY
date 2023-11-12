using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class RDITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RDI*Z0*DT*4*q*c";

		var expected = new RDI_RetailAccountDemographicInformation()
		{
			EntityIdentifierCode = "Z0",
			CountryCode = "DT",
			AmountQualifierCode = "4",
			Amount = "q",
			Description = "c",
		};

		var actual = Map.MapObject<RDI_RetailAccountDemographicInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z0", true)]
	public void Validation_RequiredEntityIdentifierCode(string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new RDI_RetailAccountDemographicInformation();
		//Required fields
		//Test Parameters
		subject.EntityIdentifierCode = entityIdentifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.Amount))
		{
			subject.AmountQualifierCode = "4";
			subject.Amount = "q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("4", "q", true)]
	[InlineData("4", "", false)]
	[InlineData("", "q", false)]
	public void Validation_AllAreRequiredAmountQualifierCode(string amountQualifierCode, string amount, bool isValidExpected)
	{
		var subject = new RDI_RetailAccountDemographicInformation();
		//Required fields
		subject.EntityIdentifierCode = "Z0";
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		subject.Amount = amount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class SD1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SD1*e*Pew*WM*E*7*q*BM*E7";

		var expected = new SD1_SafetyData()
		{
			ItemDescriptionType = "e",
			SafetyCharacteristicHazardCode = "Pew",
			AgencyQualifierCode = "WM",
			SourceSubqualifier = "E",
			ProductDescriptionCode = "7",
			Description = "q",
			StateOrProvinceCode = "BM",
			CountryCode = "E7",
		};

		var actual = Map.MapObject<SD1_SafetyData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredItemDescriptionType(string itemDescriptionType, bool isValidExpected)
	{
		var subject = new SD1_SafetyData();
		//Required fields
		subject.SafetyCharacteristicHazardCode = "Pew";
		//Test Parameters
		subject.ItemDescriptionType = itemDescriptionType;
		//At Least one
		subject.ProductDescriptionCode = "7";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Pew", true)]
	public void Validation_RequiredSafetyCharacteristicHazardCode(string safetyCharacteristicHazardCode, bool isValidExpected)
	{
		var subject = new SD1_SafetyData();
		//Required fields
		subject.ItemDescriptionType = "e";
		//Test Parameters
		subject.SafetyCharacteristicHazardCode = safetyCharacteristicHazardCode;
		//At Least one
		subject.ProductDescriptionCode = "7";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("7", "q", true)]
	[InlineData("7", "", true)]
	[InlineData("", "q", true)]
	public void Validation_AtLeastOneProductDescriptionCode(string productDescriptionCode, string description, bool isValidExpected)
	{
		var subject = new SD1_SafetyData();
		//Required fields
		subject.ItemDescriptionType = "e";
		subject.SafetyCharacteristicHazardCode = "Pew";
		//Test Parameters
		subject.ProductDescriptionCode = productDescriptionCode;
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}

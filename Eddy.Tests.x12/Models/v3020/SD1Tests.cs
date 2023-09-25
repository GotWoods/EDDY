using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class SD1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SD1*2*X5M*yN*B*h*f*z2*R4";

		var expected = new SD1_SafetyData()
		{
			ItemDescriptionType = "2",
			SafetyCharacteristicHazardCode = "X5M",
			AgencyQualifierCode = "yN",
			SourceSubqualifier = "B",
			ProductDescriptionCode = "h",
			Description = "f",
			StateOrProvinceCode = "z2",
			CountryCode = "R4",
		};

		var actual = Map.MapObject<SD1_SafetyData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredItemDescriptionType(string itemDescriptionType, bool isValidExpected)
	{
		var subject = new SD1_SafetyData();
		//Required fields
		subject.SafetyCharacteristicHazardCode = "X5M";
		subject.AgencyQualifierCode = "yN";
		//Test Parameters
		subject.ItemDescriptionType = itemDescriptionType;
		//At Least one
		subject.ProductDescriptionCode = "h";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X5M", true)]
	public void Validation_RequiredSafetyCharacteristicHazardCode(string safetyCharacteristicHazardCode, bool isValidExpected)
	{
		var subject = new SD1_SafetyData();
		//Required fields
		subject.ItemDescriptionType = "2";
		subject.AgencyQualifierCode = "yN";
		//Test Parameters
		subject.SafetyCharacteristicHazardCode = safetyCharacteristicHazardCode;
		//At Least one
		subject.ProductDescriptionCode = "h";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yN", true)]
	public void Validation_RequiredAgencyQualifierCode(string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new SD1_SafetyData();
		//Required fields
		subject.ItemDescriptionType = "2";
		subject.SafetyCharacteristicHazardCode = "X5M";
		//Test Parameters
		subject.AgencyQualifierCode = agencyQualifierCode;
		//At Least one
		subject.ProductDescriptionCode = "h";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("h", "f", true)]
	[InlineData("h", "", true)]
	[InlineData("", "f", true)]
	public void Validation_AtLeastOneProductDescriptionCode(string productDescriptionCode, string description, bool isValidExpected)
	{
		var subject = new SD1_SafetyData();
		//Required fields
		subject.ItemDescriptionType = "2";
		subject.SafetyCharacteristicHazardCode = "X5M";
		subject.AgencyQualifierCode = "yN";
		//Test Parameters
		subject.ProductDescriptionCode = productDescriptionCode;
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}

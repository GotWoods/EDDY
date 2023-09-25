using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class SD1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SD1*y*NZv*Fa*0*E*t*3m*uW";

		var expected = new SD1_SafetyData()
		{
			ItemDescriptionType = "y",
			SafetyCharacteristicHazardCode = "NZv",
			AgencyQualifierCode = "Fa",
			SourceSubqualifier = "0",
			ProductDescriptionCode = "E",
			Description = "t",
			StateOrProvinceCode = "3m",
			CountryCode = "uW",
		};

		var actual = Map.MapObject<SD1_SafetyData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredItemDescriptionType(string itemDescriptionType, bool isValidExpected)
	{
		var subject = new SD1_SafetyData();
		//Required fields
		subject.SafetyCharacteristicHazardCode = "NZv";
		//Test Parameters
		subject.ItemDescriptionType = itemDescriptionType;
		//At Least one
		subject.ProductDescriptionCode = "E";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.ProductDescriptionCode) || !string.IsNullOrEmpty(subject.Description))
		{
			subject.AgencyQualifierCode = "Fa";
			subject.ProductDescriptionCode = "E";
			subject.Description = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("NZv", true)]
	public void Validation_RequiredSafetyCharacteristicHazardCode(string safetyCharacteristicHazardCode, bool isValidExpected)
	{
		var subject = new SD1_SafetyData();
		//Required fields
		subject.ItemDescriptionType = "y";
		//Test Parameters
		subject.SafetyCharacteristicHazardCode = safetyCharacteristicHazardCode;
		//At Least one
		subject.ProductDescriptionCode = "E";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.ProductDescriptionCode) || !string.IsNullOrEmpty(subject.Description))
		{
			subject.AgencyQualifierCode = "Fa";
			subject.ProductDescriptionCode = "E";
			subject.Description = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("Fa", "E", "t", true)]
	[InlineData("", "E", "t", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_AgencyQualifierCode(string agencyQualifierCode, string productDescriptionCode, string description, bool isValidExpected)
	{
		var subject = new SD1_SafetyData();
		//Required fields
		subject.ItemDescriptionType = "y";
		subject.SafetyCharacteristicHazardCode = "NZv";
		//Test Parameters
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.ProductDescriptionCode = productDescriptionCode;
		subject.Description = description;
		//A Requires B
		if (productDescriptionCode != "")
			subject.AgencyQualifierCode = "Fa";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("E", "Fa", true)]
	[InlineData("E", "", false)]
	[InlineData("", "Fa", true)]
	public void Validation_ARequiresBProductDescriptionCode(string productDescriptionCode, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new SD1_SafetyData();
		//Required fields
		subject.ItemDescriptionType = "y";
		subject.SafetyCharacteristicHazardCode = "NZv";
		//Test Parameters
		subject.ProductDescriptionCode = productDescriptionCode;
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.Description = "t";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("E", "t", true)]
	[InlineData("E", "", true)]
	[InlineData("", "t", true)]
	public void Validation_AtLeastOneProductDescriptionCode(string productDescriptionCode, string description, bool isValidExpected)
	{
		var subject = new SD1_SafetyData();
		//Required fields
		subject.ItemDescriptionType = "y";
		subject.SafetyCharacteristicHazardCode = "NZv";
		//Test Parameters
		subject.ProductDescriptionCode = productDescriptionCode;
		subject.Description = description;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode))
		{
			subject.AgencyQualifierCode = "Fa";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}

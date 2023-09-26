using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class SD1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SD1*Z*BZ0*Dc*3*K*N*Vr*cE";

		var expected = new SD1_SafetyData()
		{
			ItemDescriptionTypeCode = "Z",
			SafetyCharacteristicHazardCode = "BZ0",
			AgencyQualifierCode = "Dc",
			SourceSubqualifier = "3",
			ProductDescriptionCode = "K",
			Description = "N",
			StateOrProvinceCode = "Vr",
			CountryCode = "cE",
		};

		var actual = Map.MapObject<SD1_SafetyData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredItemDescriptionTypeCode(string itemDescriptionTypeCode, bool isValidExpected)
	{
		var subject = new SD1_SafetyData();
		//Required fields
		subject.SafetyCharacteristicHazardCode = "BZ0";
		//Test Parameters
		subject.ItemDescriptionTypeCode = itemDescriptionTypeCode;
		//At Least one
		subject.ProductDescriptionCode = "K";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.ProductDescriptionCode) || !string.IsNullOrEmpty(subject.Description))
		{
			subject.AgencyQualifierCode = "Dc";
			subject.ProductDescriptionCode = "K";
			subject.Description = "N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("BZ0", true)]
	public void Validation_RequiredSafetyCharacteristicHazardCode(string safetyCharacteristicHazardCode, bool isValidExpected)
	{
		var subject = new SD1_SafetyData();
		//Required fields
		subject.ItemDescriptionTypeCode = "Z";
		//Test Parameters
		subject.SafetyCharacteristicHazardCode = safetyCharacteristicHazardCode;
		//At Least one
		subject.ProductDescriptionCode = "K";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.ProductDescriptionCode) || !string.IsNullOrEmpty(subject.Description))
		{
			subject.AgencyQualifierCode = "Dc";
			subject.ProductDescriptionCode = "K";
			subject.Description = "N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("Dc", "K", "N", true)]
	[InlineData("", "K", "N", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_AgencyQualifierCode(string agencyQualifierCode, string productDescriptionCode, string description, bool isValidExpected)
	{
		var subject = new SD1_SafetyData();
		//Required fields
		subject.ItemDescriptionTypeCode = "Z";
		subject.SafetyCharacteristicHazardCode = "BZ0";
		//Test Parameters
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.ProductDescriptionCode = productDescriptionCode;
		subject.Description = description;
		//A Requires B
		if (productDescriptionCode != "")
			subject.AgencyQualifierCode = "Dc";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("K", "Dc", true)]
	[InlineData("K", "", false)]
	[InlineData("", "Dc", true)]
	public void Validation_ARequiresBProductDescriptionCode(string productDescriptionCode, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new SD1_SafetyData();
		//Required fields
		subject.ItemDescriptionTypeCode = "Z";
		subject.SafetyCharacteristicHazardCode = "BZ0";
		//Test Parameters
		subject.ProductDescriptionCode = productDescriptionCode;
		subject.AgencyQualifierCode = agencyQualifierCode;
	    subject.Description = "N";
	
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("K", "N", true)]
	[InlineData("K", "", true)]
	[InlineData("", "N", true)]
	public void Validation_AtLeastOneProductDescriptionCode(string productDescriptionCode, string description, bool isValidExpected)
	{
		var subject = new SD1_SafetyData();
		//Required fields
		subject.ItemDescriptionTypeCode = "Z";
		subject.SafetyCharacteristicHazardCode = "BZ0";
		//Test Parameters
		subject.ProductDescriptionCode = productDescriptionCode;
		subject.Description = description;
        //If one, at least one
        if (productDescriptionCode != "")
            subject.AgencyQualifierCode = "AB";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}

using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SD1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SD1*S*gHG*3D*l*S*x*Bp*0X";

		var expected = new SD1_SafetyData()
		{
			ItemDescriptionTypeCode = "S",
			SafetyCharacteristicHazardCode = "gHG",
			AgencyQualifierCode = "3D",
			SourceSubqualifier = "l",
			ProductDescriptionCode = "S",
			Description = "x",
			StateOrProvinceCode = "Bp",
			CountryCode = "0X",
		};

		var actual = Map.MapObject<SD1_SafetyData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredItemDescriptionTypeCode(string itemDescriptionTypeCode, bool isValidExpected)
	{
		var subject = new SD1_SafetyData();
		subject.SafetyCharacteristicHazardCode = "gHG";
		subject.ItemDescriptionTypeCode = itemDescriptionTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("gHG", true)]
	public void Validation_RequiredSafetyCharacteristicHazardCode(string safetyCharacteristicHazardCode, bool isValidExpected)
	{
		var subject = new SD1_SafetyData();
		subject.ItemDescriptionTypeCode = "S";
		subject.SafetyCharacteristicHazardCode = safetyCharacteristicHazardCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("3D", "S", true)]
	[InlineData("","S", true)]
	[InlineData("3D", "", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_AgencyQualifierCode(string agencyQualifierCode, string productDescriptionCode, string description, bool isValidExpected)
	{
		var subject = new SD1_SafetyData();
		subject.ItemDescriptionTypeCode = "S";
		subject.SafetyCharacteristicHazardCode = "gHG";
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.ProductDescriptionCode = productDescriptionCode;
		subject.Description = description;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "3D", true)]
	[InlineData("S", "", false)]
	public void Validation_ARequiresBProductDescriptionCode(string productDescriptionCode, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new SD1_SafetyData();
		subject.ItemDescriptionTypeCode = "S";
		subject.SafetyCharacteristicHazardCode = "gHG";
		subject.ProductDescriptionCode = productDescriptionCode;
		subject.AgencyQualifierCode = agencyQualifierCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("S","x", true)]
	[InlineData("", "x", true)]
	[InlineData("S", "", true)]
	public void Validation_AtLeastOneProductDescriptionCode(string productDescriptionCode, string description, bool isValidExpected)
	{
		var subject = new SD1_SafetyData();
		subject.ItemDescriptionTypeCode = "S";
		subject.SafetyCharacteristicHazardCode = "gHG";
		subject.ProductDescriptionCode = productDescriptionCode;
		subject.Description = description;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}

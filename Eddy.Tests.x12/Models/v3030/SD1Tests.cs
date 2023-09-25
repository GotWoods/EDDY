using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class SD1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SD1*X*DOF*Nq*n*H*Z*vI*HD";

		var expected = new SD1_SafetyData()
		{
			ItemDescriptionType = "X",
			SafetyCharacteristicHazardCode = "DOF",
			AgencyQualifierCode = "Nq",
			SourceSubqualifier = "n",
			ProductDescriptionCode = "H",
			Description = "Z",
			StateOrProvinceCode = "vI",
			CountryCode = "HD",
		};

		var actual = Map.MapObject<SD1_SafetyData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredItemDescriptionType(string itemDescriptionType, bool isValidExpected)
	{
		var subject = new SD1_SafetyData();
		//Required fields
		subject.SafetyCharacteristicHazardCode = "DOF";
		subject.AgencyQualifierCode = "Nq";
		//Test Parameters
		subject.ItemDescriptionType = itemDescriptionType;
		//At Least one
		subject.ProductDescriptionCode = "H";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("DOF", true)]
	public void Validation_RequiredSafetyCharacteristicHazardCode(string safetyCharacteristicHazardCode, bool isValidExpected)
	{
		var subject = new SD1_SafetyData();
		//Required fields
		subject.ItemDescriptionType = "X";
		subject.AgencyQualifierCode = "Nq";
		//Test Parameters
		subject.SafetyCharacteristicHazardCode = safetyCharacteristicHazardCode;
		//At Least one
		subject.ProductDescriptionCode = "H";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Nq", true)]
	public void Validation_RequiredAgencyQualifierCode(string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new SD1_SafetyData();
		//Required fields
		subject.ItemDescriptionType = "X";
		subject.SafetyCharacteristicHazardCode = "DOF";
		//Test Parameters
		subject.AgencyQualifierCode = agencyQualifierCode;
		//At Least one
		subject.ProductDescriptionCode = "H";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("H", "Z", true)]
	[InlineData("H", "", true)]
	[InlineData("", "Z", true)]
	public void Validation_AtLeastOneProductDescriptionCode(string productDescriptionCode, string description, bool isValidExpected)
	{
		var subject = new SD1_SafetyData();
		//Required fields
		subject.ItemDescriptionType = "X";
		subject.SafetyCharacteristicHazardCode = "DOF";
		subject.AgencyQualifierCode = "Nq";
		//Test Parameters
		subject.ProductDescriptionCode = productDescriptionCode;
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}

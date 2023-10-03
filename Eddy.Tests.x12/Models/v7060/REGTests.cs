using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v7060.Composites;
using Eddy.x12.Models.v7060;

namespace Eddy.x12.Tests.Models.v7060;

public class REGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "REG*Sb*Qx**L";

		var expected = new REG_RegulatoryApplication()
		{
			RegulatoryType = "Sb",
			CountryCode = "Qx",
			CompositeStateOrProvinceCode = null,
			YesNoConditionOrResponseCode = "L",
		};

		var actual = Map.MapObject<REG_RegulatoryApplication>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Sb", true)]
	public void Validation_RequiredRegulatoryType(string regulatoryType, bool isValidExpected)
	{
		var subject = new REG_RegulatoryApplication();
		//Required fields
		//Test Parameters
		subject.RegulatoryType = regulatoryType;
		//At Least one
		subject.CountryCode = "Qx";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("Qx", "A", true)]
	[InlineData("Qx", "", true)]
	[InlineData("", "A", true)]
	public void Validation_AtLeastOneCountryCode(string countryCode, string compositeStateOrProvinceCode, bool isValidExpected)
	{
		var subject = new REG_RegulatoryApplication();
		//Required fields
		subject.RegulatoryType = "Sb";
		//Test Parameters
		subject.CountryCode = countryCode;
		if (compositeStateOrProvinceCode != "") 
			subject.CompositeStateOrProvinceCode = new C069_CompositeStateOrProvinceCode();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}

using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class REGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "REG*Xe*Zt**C";

		var expected = new REG_RegulatoryApplication()
		{
			RegulatoryType = "Xe",
			CountryCode = "Zt",
			CompositeStateOrProvinceCode = "",
			YesNoConditionOrResponseCode = "C",
		};

		var actual = Map.MapObject<REG_RegulatoryApplication>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Xe", true)]
	public void Validation_RequiredRegulatoryType(string regulatoryType, bool isValidExpected)
	{
		var subject = new REG_RegulatoryApplication();
		subject.RegulatoryType = regulatoryType;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("Zt","", true)]
	[InlineData("", "", true)]
	[InlineData("Zt", "", true)]
	public void Validation_AtLeastOneCountryCode(string countryCode, C069_CompositeStateOrProvinceCode compositeStateOrProvinceCode, bool isValidExpected)
	{
		var subject = new REG_RegulatoryApplication();
		subject.RegulatoryType = "Xe";
		subject.CountryCode = countryCode;
		subject.CompositeStateOrProvinceCode = compositeStateOrProvinceCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}

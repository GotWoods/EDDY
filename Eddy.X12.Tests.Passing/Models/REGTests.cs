using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using Eddy.x12.Models.Elements;

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
			CompositeStateOrProvinceCode = null,
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
	[InlineData("", "AA", true)]
	[InlineData("Zt", "AA", true)]
	public void Validation_AtLeastOneCountryCode(string countryCode, string compositeStateOrProvinceCode, bool isValidExpected)
	{
		var subject = new REG_RegulatoryApplication();
		subject.RegulatoryType = "Xe";
		subject.CountryCode = countryCode;
		if (compositeStateOrProvinceCode != "")
		    subject.CompositeStateOrProvinceCode = new C069_CompositeStateOrProvinceCode() ;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}

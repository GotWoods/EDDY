using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class PDPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PDP*Lw*x*r";

		var expected = new PDP_PropertyDescriptionPersonal()
		{
			TypeOfPersonalPropertyCode = "Lw",
			CommodityCodeQualifier = "x",
			CommodityCode = "r",
		};

		var actual = Map.MapObject<PDP_PropertyDescriptionPersonal>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Lw", true)]
	public void Validation_RequiredTypeOfPersonalPropertyCode(string typeOfPersonalPropertyCode, bool isValidExpected)
	{
		var subject = new PDP_PropertyDescriptionPersonal();
		//Required fields
		//Test Parameters
		subject.TypeOfPersonalPropertyCode = typeOfPersonalPropertyCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCode))
		{
			subject.CommodityCodeQualifier = "x";
			subject.CommodityCode = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("x", "r", true)]
	[InlineData("x", "", false)]
	[InlineData("", "r", false)]
	public void Validation_AllAreRequiredCommodityCodeQualifier(string commodityCodeQualifier, string commodityCode, bool isValidExpected)
	{
		var subject = new PDP_PropertyDescriptionPersonal();
		//Required fields
		subject.TypeOfPersonalPropertyCode = "Lw";
		//Test Parameters
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		subject.CommodityCode = commodityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

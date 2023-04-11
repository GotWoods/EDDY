using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PDPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PDP*yb*0*z";

		var expected = new PDP_PropertyDescriptionPersonal()
		{
			TypeOfPersonalOrBusinessAssetCode = "yb",
			CommodityCodeQualifier = "0",
			CommodityCode = "z",
		};

		var actual = Map.MapObject<PDP_PropertyDescriptionPersonal>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yb", true)]
	public void Validation_RequiredTypeOfPersonalOrBusinessAssetCode(string typeOfPersonalOrBusinessAssetCode, bool isValidExpected)
	{
		var subject = new PDP_PropertyDescriptionPersonal();
		subject.TypeOfPersonalOrBusinessAssetCode = typeOfPersonalOrBusinessAssetCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("0", "z", true)]
	[InlineData("", "z", false)]
	[InlineData("0", "", false)]
	public void Validation_AllAreRequiredCommodityCodeQualifier(string commodityCodeQualifier, string commodityCode, bool isValidExpected)
	{
		var subject = new PDP_PropertyDescriptionPersonal();
		subject.TypeOfPersonalOrBusinessAssetCode = "yb";
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		subject.CommodityCode = commodityCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

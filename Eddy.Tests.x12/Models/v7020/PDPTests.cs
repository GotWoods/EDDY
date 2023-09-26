using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.Tests.Models.v7020;

public class PDPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PDP*hE*J*P";

		var expected = new PDP_PropertyDescriptionPersonal()
		{
			TypeOfPersonalOrBusinessAssetCode = "hE",
			CommodityCodeQualifier = "J",
			CommodityCode = "P",
		};

		var actual = Map.MapObject<PDP_PropertyDescriptionPersonal>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hE", true)]
	public void Validation_RequiredTypeOfPersonalOrBusinessAssetCode(string typeOfPersonalOrBusinessAssetCode, bool isValidExpected)
	{
		var subject = new PDP_PropertyDescriptionPersonal();
		//Required fields
		//Test Parameters
		subject.TypeOfPersonalOrBusinessAssetCode = typeOfPersonalOrBusinessAssetCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCode))
		{
			subject.CommodityCodeQualifier = "J";
			subject.CommodityCode = "P";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("J", "P", true)]
	[InlineData("J", "", false)]
	[InlineData("", "P", false)]
	public void Validation_AllAreRequiredCommodityCodeQualifier(string commodityCodeQualifier, string commodityCode, bool isValidExpected)
	{
		var subject = new PDP_PropertyDescriptionPersonal();
		//Required fields
		subject.TypeOfPersonalOrBusinessAssetCode = "hE";
		//Test Parameters
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		subject.CommodityCode = commodityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

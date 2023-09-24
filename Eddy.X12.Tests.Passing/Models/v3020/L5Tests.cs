using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class L5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L5*5*J*a*n*HYYgL*T*m*U*Z*e";

		var expected = new L5_DescriptionMarksAndNumbers()
		{
			LadingLineItemNumber = 5,
			LadingDescription = "J",
			CommodityCode = "a",
			CommodityCodeQualifier = "n",
			PackagingCode = "HYYgL",
			MarksAndNumbers = "T",
			MarksAndNumbersQualifier = "m",
			CommodityCodeQualifier2 = "U",
			CommodityCode2 = "Z",
			CompartmentIDCode = "e",
		};

		var actual = Map.MapObject<L5_DescriptionMarksAndNumbers>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("a", "n", true)]
	[InlineData("a", "", false)]
	[InlineData("", "n", false)]
	public void Validation_AllAreRequiredCommodityCode(string commodityCode, string commodityCodeQualifier, bool isValidExpected)
	{
		var subject = new L5_DescriptionMarksAndNumbers();
		subject.CommodityCode = commodityCode;
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommodityCodeQualifier2) || !string.IsNullOrEmpty(subject.CommodityCodeQualifier2) || !string.IsNullOrEmpty(subject.CommodityCode2))
		{
			subject.CommodityCodeQualifier2 = "U";
			subject.CommodityCode2 = "Z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("U", "Z", true)]
	[InlineData("U", "", false)]
	[InlineData("", "Z", false)]
	public void Validation_AllAreRequiredCommodityCodeQualifier2(string commodityCodeQualifier2, string commodityCode2, bool isValidExpected)
	{
		var subject = new L5_DescriptionMarksAndNumbers();
		subject.CommodityCodeQualifier2 = commodityCodeQualifier2;
		subject.CommodityCode2 = commodityCode2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommodityCode) || !string.IsNullOrEmpty(subject.CommodityCode) || !string.IsNullOrEmpty(subject.CommodityCodeQualifier))
		{
			subject.CommodityCode = "a";
			subject.CommodityCodeQualifier = "n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

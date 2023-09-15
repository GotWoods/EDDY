using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8030;

namespace Eddy.x12.Tests.Models.v8030;

public class L5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L5*1*E*n*u*PJw*Z*r*t*8*J";

		var expected = new L5_DescriptionMarksAndNumbers()
		{
			LadingLineItemNumber = 1,
			LadingDescription = "E",
			CommodityCode = "n",
			CommodityCodeQualifier = "u",
			PackagingCode = "PJw",
			MarksAndNumbers = "Z",
			MarksAndNumbersQualifier = "r",
			CommodityCodeQualifier2 = "t",
			CommodityCode2 = "8",
			CompartmentIDCode = "J",
		};

		var actual = Map.MapObject<L5_DescriptionMarksAndNumbers>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("n", "u", true)]
	[InlineData("n", "", false)]
	[InlineData("", "u", false)]
	public void Validation_AllAreRequiredCommodityCode(string commodityCode, string commodityCodeQualifier, bool isValidExpected)
	{
		var subject = new L5_DescriptionMarksAndNumbers();
		subject.CommodityCode = commodityCode;
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommodityCodeQualifier2) || !string.IsNullOrEmpty(subject.CommodityCodeQualifier2) || !string.IsNullOrEmpty(subject.CommodityCode2))
		{
			subject.CommodityCodeQualifier2 = "t";
			subject.CommodityCode2 = "8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("r", "Z", true)]
	[InlineData("r", "", false)]
	[InlineData("", "Z", true)]
	public void Validation_ARequiresBMarksAndNumbersQualifier(string marksAndNumbersQualifier, string marksAndNumbers, bool isValidExpected)
	{
		var subject = new L5_DescriptionMarksAndNumbers();
		subject.MarksAndNumbersQualifier = marksAndNumbersQualifier;
		subject.MarksAndNumbers = marksAndNumbers;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommodityCode) || !string.IsNullOrEmpty(subject.CommodityCode) || !string.IsNullOrEmpty(subject.CommodityCodeQualifier))
		{
			subject.CommodityCode = "n";
			subject.CommodityCodeQualifier = "u";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommodityCodeQualifier2) || !string.IsNullOrEmpty(subject.CommodityCodeQualifier2) || !string.IsNullOrEmpty(subject.CommodityCode2))
		{
			subject.CommodityCodeQualifier2 = "t";
			subject.CommodityCode2 = "8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("t", "8", true)]
	[InlineData("t", "", false)]
	[InlineData("", "8", false)]
	public void Validation_AllAreRequiredCommodityCodeQualifier2(string commodityCodeQualifier2, string commodityCode2, bool isValidExpected)
	{
		var subject = new L5_DescriptionMarksAndNumbers();
		subject.CommodityCodeQualifier2 = commodityCodeQualifier2;
		subject.CommodityCode2 = commodityCode2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommodityCode) || !string.IsNullOrEmpty(subject.CommodityCode) || !string.IsNullOrEmpty(subject.CommodityCodeQualifier))
		{
			subject.CommodityCode = "n";
			subject.CommodityCodeQualifier = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

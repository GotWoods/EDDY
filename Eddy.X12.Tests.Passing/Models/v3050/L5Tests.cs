using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class L5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L5*5*s*I*F*hsI*D*4*1*4*6";

		var expected = new L5_DescriptionMarksAndNumbers()
		{
			LadingLineItemNumber = 5,
			LadingDescription = "s",
			CommodityCode = "I",
			CommodityCodeQualifier = "F",
			PackagingCode = "hsI",
			MarksAndNumbers = "D",
			MarksAndNumbersQualifier = "4",
			CommodityCodeQualifier2 = "1",
			CommodityCode2 = "4",
			CompartmentIDCode = "6",
		};

		var actual = Map.MapObject<L5_DescriptionMarksAndNumbers>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("I", "F", true)]
	[InlineData("I", "", false)]
	[InlineData("", "F", false)]
	public void Validation_AllAreRequiredCommodityCode(string commodityCode, string commodityCodeQualifier, bool isValidExpected)
	{
		var subject = new L5_DescriptionMarksAndNumbers();
		subject.CommodityCode = commodityCode;
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommodityCodeQualifier2) || !string.IsNullOrEmpty(subject.CommodityCodeQualifier2) || !string.IsNullOrEmpty(subject.CommodityCode2))
		{
			subject.CommodityCodeQualifier2 = "1";
			subject.CommodityCode2 = "4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("4", "D", true)]
	[InlineData("4", "", false)]
	[InlineData("", "D", true)]
	public void Validation_ARequiresBMarksAndNumbersQualifier(string marksAndNumbersQualifier, string marksAndNumbers, bool isValidExpected)
	{
		var subject = new L5_DescriptionMarksAndNumbers();
		subject.MarksAndNumbersQualifier = marksAndNumbersQualifier;
		subject.MarksAndNumbers = marksAndNumbers;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommodityCode) || !string.IsNullOrEmpty(subject.CommodityCode) || !string.IsNullOrEmpty(subject.CommodityCodeQualifier))
		{
			subject.CommodityCode = "I";
			subject.CommodityCodeQualifier = "F";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommodityCodeQualifier2) || !string.IsNullOrEmpty(subject.CommodityCodeQualifier2) || !string.IsNullOrEmpty(subject.CommodityCode2))
		{
			subject.CommodityCodeQualifier2 = "1";
			subject.CommodityCode2 = "4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("1", "4", true)]
	[InlineData("1", "", false)]
	[InlineData("", "4", false)]
	public void Validation_AllAreRequiredCommodityCodeQualifier2(string commodityCodeQualifier2, string commodityCode2, bool isValidExpected)
	{
		var subject = new L5_DescriptionMarksAndNumbers();
		subject.CommodityCodeQualifier2 = commodityCodeQualifier2;
		subject.CommodityCode2 = commodityCode2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommodityCode) || !string.IsNullOrEmpty(subject.CommodityCode) || !string.IsNullOrEmpty(subject.CommodityCodeQualifier))
		{
			subject.CommodityCode = "I";
			subject.CommodityCodeQualifier = "F";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

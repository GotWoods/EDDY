using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class L5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L5*3*t*q*T*mYpWx*v*R*B*g*x";

		var expected = new L5_DescriptionMarksAndNumbers()
		{
			LadingLineItemNumber = 3,
			LadingDescription = "t",
			CommodityCode = "q",
			CommodityCodeQualifier = "T",
			PackagingCode = "mYpWx",
			MarksAndNumbers = "v",
			MarksAndNumbersQualifier = "R",
			CommodityCodeQualifier2 = "B",
			CommodityCode2 = "g",
			CompartmentIDCode = "x",
		};

		var actual = Map.MapObject<L5_DescriptionMarksAndNumbers>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("q", "T", true)]
	[InlineData("q", "", false)]
	[InlineData("", "T", false)]
	public void Validation_AllAreRequiredCommodityCode(string commodityCode, string commodityCodeQualifier, bool isValidExpected)
	{
		var subject = new L5_DescriptionMarksAndNumbers();
		subject.CommodityCode = commodityCode;
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommodityCodeQualifier2) || !string.IsNullOrEmpty(subject.CommodityCodeQualifier2) || !string.IsNullOrEmpty(subject.CommodityCode2))
		{
			subject.CommodityCodeQualifier2 = "B";
			subject.CommodityCode2 = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("R", "v", true)]
	[InlineData("R", "", false)]
	[InlineData("", "v", true)]
	public void Validation_ARequiresBMarksAndNumbersQualifier(string marksAndNumbersQualifier, string marksAndNumbers, bool isValidExpected)
	{
		var subject = new L5_DescriptionMarksAndNumbers();
		subject.MarksAndNumbersQualifier = marksAndNumbersQualifier;
		subject.MarksAndNumbers = marksAndNumbers;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommodityCode) || !string.IsNullOrEmpty(subject.CommodityCode) || !string.IsNullOrEmpty(subject.CommodityCodeQualifier))
		{
			subject.CommodityCode = "q";
			subject.CommodityCodeQualifier = "T";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommodityCodeQualifier2) || !string.IsNullOrEmpty(subject.CommodityCodeQualifier2) || !string.IsNullOrEmpty(subject.CommodityCode2))
		{
			subject.CommodityCodeQualifier2 = "B";
			subject.CommodityCode2 = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("B", "g", true)]
	[InlineData("B", "", false)]
	[InlineData("", "g", false)]
	public void Validation_AllAreRequiredCommodityCodeQualifier2(string commodityCodeQualifier2, string commodityCode2, bool isValidExpected)
	{
		var subject = new L5_DescriptionMarksAndNumbers();
		subject.CommodityCodeQualifier2 = commodityCodeQualifier2;
		subject.CommodityCode2 = commodityCode2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommodityCode) || !string.IsNullOrEmpty(subject.CommodityCode) || !string.IsNullOrEmpty(subject.CommodityCodeQualifier))
		{
			subject.CommodityCode = "q";
			subject.CommodityCodeQualifier = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

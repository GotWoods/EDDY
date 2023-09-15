using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.Tests.Models.v5050;

public class L5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L5*3*F*j*q*zM2*Y*Q*f*6*B";

		var expected = new L5_DescriptionMarksAndNumbers()
		{
			LadingLineItemNumber = 3,
			LadingDescription = "F",
			CommodityCode = "j",
			CommodityCodeQualifier = "q",
			PackagingCode = "zM2",
			MarksAndNumbers = "Y",
			MarksAndNumbersQualifier = "Q",
			CommodityCodeQualifier2 = "f",
			CommodityCode2 = "6",
			CompartmentIDCode = "B",
		};

		var actual = Map.MapObject<L5_DescriptionMarksAndNumbers>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("j", "q", true)]
	[InlineData("j", "", false)]
	[InlineData("", "q", false)]
	public void Validation_AllAreRequiredCommodityCode(string commodityCode, string commodityCodeQualifier, bool isValidExpected)
	{
		var subject = new L5_DescriptionMarksAndNumbers();
		subject.CommodityCode = commodityCode;
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommodityCodeQualifier2) || !string.IsNullOrEmpty(subject.CommodityCodeQualifier2) || !string.IsNullOrEmpty(subject.CommodityCode2))
		{
			subject.CommodityCodeQualifier2 = "f";
			subject.CommodityCode2 = "6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Q", "Y", true)]
	[InlineData("Q", "", false)]
	[InlineData("", "Y", true)]
	public void Validation_ARequiresBMarksAndNumbersQualifier(string marksAndNumbersQualifier, string marksAndNumbers, bool isValidExpected)
	{
		var subject = new L5_DescriptionMarksAndNumbers();
		subject.MarksAndNumbersQualifier = marksAndNumbersQualifier;
		subject.MarksAndNumbers = marksAndNumbers;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommodityCode) || !string.IsNullOrEmpty(subject.CommodityCode) || !string.IsNullOrEmpty(subject.CommodityCodeQualifier))
		{
			subject.CommodityCode = "j";
			subject.CommodityCodeQualifier = "q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommodityCodeQualifier2) || !string.IsNullOrEmpty(subject.CommodityCodeQualifier2) || !string.IsNullOrEmpty(subject.CommodityCode2))
		{
			subject.CommodityCodeQualifier2 = "f";
			subject.CommodityCode2 = "6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("f", "6", true)]
	[InlineData("f", "", false)]
	[InlineData("", "6", false)]
	public void Validation_AllAreRequiredCommodityCodeQualifier2(string commodityCodeQualifier2, string commodityCode2, bool isValidExpected)
	{
		var subject = new L5_DescriptionMarksAndNumbers();
		subject.CommodityCodeQualifier2 = commodityCodeQualifier2;
		subject.CommodityCode2 = commodityCode2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommodityCode) || !string.IsNullOrEmpty(subject.CommodityCode) || !string.IsNullOrEmpty(subject.CommodityCodeQualifier))
		{
			subject.CommodityCode = "j";
			subject.CommodityCodeQualifier = "q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

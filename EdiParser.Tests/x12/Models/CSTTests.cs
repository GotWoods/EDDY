using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class CSTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CST*rPW*3*AA*5";

		var expected = new CST_CostAnalysis()
		{
			CostCode = "rPW",
			MonetaryAmount = 3,
			CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure() { UnitOrBasisForMeasurementCode = "AA"},
			Quantity = 5,
		};

		var actual = Map.MapObject<CST_CostAnalysis>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		try
		{
			Assert.Equivalent(expected, actual);
		}
		catch
		{
			Assert.Fail(actual.ValidationResult.ToString());
		}
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rPW", true)]
	public void Validatation_RequiredCostCode(string costCode, bool isValidExpected)
	{
		var subject = new CST_CostAnalysis();
		subject.MonetaryAmount = 3;
		subject.CostCode = costCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validatation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new CST_CostAnalysis();
		subject.CostCode = "rPW";
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

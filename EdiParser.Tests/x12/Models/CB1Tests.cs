using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class CB1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CB1*fR*s";

		var expected = new CB1_ContractAndCostAccountingStandardsData()
		{
			AcquisitionDataCode = "fR",
			FinancingTypeCode = "s",
		};

		var actual = Map.MapObject<CB1_ContractAndCostAccountingStandardsData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
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
	[InlineData("fR", true)]
	public void Validatation_RequiredAcquisitionDataCode(string acquisitionDataCode, bool isValidExpected)
	{
		var subject = new CB1_ContractAndCostAccountingStandardsData();
		subject.AcquisitionDataCode = acquisitionDataCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

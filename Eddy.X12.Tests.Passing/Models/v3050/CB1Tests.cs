using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class CB1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CB1*Yj*a";

		var expected = new CB1_ContractAndCostAccountingStandardsData()
		{
			AcquisitionDataCode = "Yj",
			FinancingTypeCode = "a",
		};

		var actual = Map.MapObject<CB1_ContractAndCostAccountingStandardsData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Yj", true)]
	public void Validation_RequiredAcquisitionDataCode(string acquisitionDataCode, bool isValidExpected)
	{
		var subject = new CB1_ContractAndCostAccountingStandardsData();
		//Required fields
		//Test Parameters
		subject.AcquisitionDataCode = acquisitionDataCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

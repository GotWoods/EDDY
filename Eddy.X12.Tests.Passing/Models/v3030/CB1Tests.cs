using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class CB1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CB1*os*M";

		var expected = new CB1_ContractAndCostAccountingStandardsData()
		{
			PricingProposalDataCode = "os",
			FinancingTypeCode = "M",
		};

		var actual = Map.MapObject<CB1_ContractAndCostAccountingStandardsData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("os", true)]
	public void Validation_RequiredPricingProposalDataCode(string pricingProposalDataCode, bool isValidExpected)
	{
		var subject = new CB1_ContractAndCostAccountingStandardsData();
		//Required fields
		//Test Parameters
		subject.PricingProposalDataCode = pricingProposalDataCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

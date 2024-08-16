using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C536Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "C:b:t";

		var expected = new C536_ContractAndCarriageCondition()
		{
			ContractAndCarriageConditionCode = "C",
			CodeListIdentificationCode = "b",
			CodeListResponsibleAgencyCode = "t",
		};

		var actual = Map.MapComposite<C536_ContractAndCarriageCondition>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredContractAndCarriageConditionCode(string contractAndCarriageConditionCode, bool isValidExpected)
	{
		var subject = new C536_ContractAndCarriageCondition();
		//Required fields
		//Test Parameters
		subject.ContractAndCarriageConditionCode = contractAndCarriageConditionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

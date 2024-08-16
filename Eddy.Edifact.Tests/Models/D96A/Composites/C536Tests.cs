using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C536Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "g:6:q";

		var expected = new C536_ContractAndCarriageCondition()
		{
			ContractAndCarriageConditionCoded = "g",
			CodeListQualifier = "6",
			CodeListResponsibleAgencyCoded = "q",
		};

		var actual = Map.MapComposite<C536_ContractAndCarriageCondition>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredContractAndCarriageConditionCoded(string contractAndCarriageConditionCoded, bool isValidExpected)
	{
		var subject = new C536_ContractAndCarriageCondition();
		//Required fields
		//Test Parameters
		subject.ContractAndCarriageConditionCoded = contractAndCarriageConditionCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

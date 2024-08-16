using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C536Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "h:c:I";

		var expected = new C536_ContractAndCarriageCondition()
		{
			ContractAndCarriageConditionCode = "h",
			CodeListIdentificationCode = "c",
			CodeListResponsibleAgencyCode = "I",
		};

		var actual = Map.MapComposite<C536_ContractAndCarriageCondition>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredContractAndCarriageConditionCode(string contractAndCarriageConditionCode, bool isValidExpected)
	{
		var subject = new C536_ContractAndCarriageCondition();
		//Required fields
		//Test Parameters
		subject.ContractAndCarriageConditionCode = contractAndCarriageConditionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C878Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "D:f:Z:9:m";

		var expected = new C878_ChargeAllowanceAccount()
		{
			InstitutionBranchNumber = "D",
			CodeListQualifier = "f",
			CodeListResponsibleAgencyCoded = "Z",
			AccountHolderNumber = "9",
			CurrencyCoded = "m",
		};

		var actual = Map.MapComposite<C878_ChargeAllowanceAccount>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredInstitutionBranchNumber(string institutionBranchNumber, bool isValidExpected)
	{
		var subject = new C878_ChargeAllowanceAccount();
		//Required fields
		//Test Parameters
		subject.InstitutionBranchNumber = institutionBranchNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C878Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "D:p:G:F:0";

		var expected = new C878_ChargeAllowanceAccount()
		{
			InstitutionBranchNumber = "D",
			CodeListIdentificationCode = "p",
			CodeListResponsibleAgencyCode = "G",
			AccountHolderNumber = "F",
			CurrencyIdentificationCode = "0",
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

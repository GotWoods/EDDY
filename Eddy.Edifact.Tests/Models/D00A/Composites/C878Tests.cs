using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C878Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "y:e:J:f:b";

		var expected = new C878_ChargeAllowanceAccount()
		{
			InstitutionBranchIdentifier = "y",
			CodeListIdentificationCode = "e",
			CodeListResponsibleAgencyCode = "J",
			AccountHolderIdentifier = "f",
			CurrencyIdentificationCode = "b",
		};

		var actual = Map.MapComposite<C878_ChargeAllowanceAccount>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredInstitutionBranchIdentifier(string institutionBranchIdentifier, bool isValidExpected)
	{
		var subject = new C878_ChargeAllowanceAccount();
		//Required fields
		//Test Parameters
		subject.InstitutionBranchIdentifier = institutionBranchIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

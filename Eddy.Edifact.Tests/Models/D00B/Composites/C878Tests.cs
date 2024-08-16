using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C878Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "d:i:m:O:j";

		var expected = new C878_ChargeAllowanceAccount()
		{
			InstitutionBranchIdentifier = "d",
			CodeListIdentificationCode = "i",
			CodeListResponsibleAgencyCode = "m",
			AccountHolderIdentifier = "O",
			CurrencyIdentificationCode = "j",
		};

		var actual = Map.MapComposite<C878_ChargeAllowanceAccount>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredInstitutionBranchIdentifier(string institutionBranchIdentifier, bool isValidExpected)
	{
		var subject = new C878_ChargeAllowanceAccount();
		//Required fields
		//Test Parameters
		subject.InstitutionBranchIdentifier = institutionBranchIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

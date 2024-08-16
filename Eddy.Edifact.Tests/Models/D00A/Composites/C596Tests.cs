using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C596Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "m:G:Z:Q";

		var expected = new C596_AccountingEntryTypeDetails()
		{
			AccountingEntryTypeNameCode = "m",
			CodeListIdentificationCode = "G",
			CodeListResponsibleAgencyCode = "Z",
			AccountingEntryTypeName = "Q",
		};

		var actual = Map.MapComposite<C596_AccountingEntryTypeDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredAccountingEntryTypeNameCode(string accountingEntryTypeNameCode, bool isValidExpected)
	{
		var subject = new C596_AccountingEntryTypeDetails();
		//Required fields
		//Test Parameters
		subject.AccountingEntryTypeNameCode = accountingEntryTypeNameCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

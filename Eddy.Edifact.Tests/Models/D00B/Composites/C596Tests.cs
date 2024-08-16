using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C596Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "l:O:h:u";

		var expected = new C596_AccountingEntryTypeDetails()
		{
			AccountingEntryTypeNameCode = "l",
			CodeListIdentificationCode = "O",
			CodeListResponsibleAgencyCode = "h",
			AccountingEntryTypeName = "u",
		};

		var actual = Map.MapComposite<C596_AccountingEntryTypeDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredAccountingEntryTypeNameCode(string accountingEntryTypeNameCode, bool isValidExpected)
	{
		var subject = new C596_AccountingEntryTypeDetails();
		//Required fields
		//Test Parameters
		subject.AccountingEntryTypeNameCode = accountingEntryTypeNameCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

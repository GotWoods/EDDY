using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C595Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "X:o:1:N";

		var expected = new C595_AccountingJournalIdentification()
		{
			AccountingJournalIdentifier = "X",
			CodeListIdentificationCode = "o",
			CodeListResponsibleAgencyCode = "1",
			AccountingJournalName = "N",
		};

		var actual = Map.MapComposite<C595_AccountingJournalIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredAccountingJournalIdentifier(string accountingJournalIdentifier, bool isValidExpected)
	{
		var subject = new C595_AccountingJournalIdentification();
		//Required fields
		//Test Parameters
		subject.AccountingJournalIdentifier = accountingJournalIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

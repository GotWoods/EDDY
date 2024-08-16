using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98A;
using Eddy.Edifact.Models.D98A.Composites;

namespace Eddy.Edifact.Tests.Models.D98A.Composites;

public class C595Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "E:C:2:2";

		var expected = new C595_AccountingJournalIdentification()
		{
			AccountingJournalIdentification = "E",
			CodeListQualifier = "C",
			CodeListResponsibleAgencyCoded = "2",
			AccountingJournal = "2",
		};

		var actual = Map.MapComposite<C595_AccountingJournalIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredAccountingJournalIdentification(string accountingJournalIdentification, bool isValidExpected)
	{
		var subject = new C595_AccountingJournalIdentification();
		//Required fields
		//Test Parameters
		subject.AccountingJournalIdentification = accountingJournalIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

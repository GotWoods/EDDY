using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C595Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "S:6:V:D";

		var expected = new C595_AccountingJournalIdentification()
		{
			AccountingJournalIdentification = "S",
			CodeListIdentificationCode = "6",
			CodeListResponsibleAgencyCode = "V",
			AccountingJournal = "D",
		};

		var actual = Map.MapComposite<C595_AccountingJournalIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredAccountingJournalIdentification(string accountingJournalIdentification, bool isValidExpected)
	{
		var subject = new C595_AccountingJournalIdentification();
		//Required fields
		//Test Parameters
		subject.AccountingJournalIdentification = accountingJournalIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

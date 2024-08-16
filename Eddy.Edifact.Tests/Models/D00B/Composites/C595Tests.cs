using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C595Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "m:K:Z:1";

		var expected = new C595_AccountingJournalIdentification()
		{
			AccountingJournalIdentifier = "m",
			CodeListIdentificationCode = "K",
			CodeListResponsibleAgencyCode = "Z",
			AccountingJournalName = "1",
		};

		var actual = Map.MapComposite<C595_AccountingJournalIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredAccountingJournalIdentifier(string accountingJournalIdentifier, bool isValidExpected)
	{
		var subject = new C595_AccountingJournalIdentification();
		//Required fields
		//Test Parameters
		subject.AccountingJournalIdentifier = accountingJournalIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

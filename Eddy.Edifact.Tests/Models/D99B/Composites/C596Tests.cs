using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C596Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "Q:r:x:K";

		var expected = new C596_AccountingEntryTypeDetails()
		{
			TypeOfAccountingEntryIdentification = "Q",
			CodeListIdentificationCode = "r",
			CodeListResponsibleAgencyCode = "x",
			TypeOfAccountingEntry = "K",
		};

		var actual = Map.MapComposite<C596_AccountingEntryTypeDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredTypeOfAccountingEntryIdentification(string typeOfAccountingEntryIdentification, bool isValidExpected)
	{
		var subject = new C596_AccountingEntryTypeDetails();
		//Required fields
		//Test Parameters
		subject.TypeOfAccountingEntryIdentification = typeOfAccountingEntryIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

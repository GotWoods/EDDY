using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98A;
using Eddy.Edifact.Models.D98A.Composites;

namespace Eddy.Edifact.Tests.Models.D98A.Composites;

public class C596Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "2:Y:x:z";

		var expected = new C596_AccountingEntryTypeDetails()
		{
			TypeOfAccountingEntryIdentification = "2",
			CodeListQualifier = "Y",
			CodeListResponsibleAgencyCoded = "x",
			TypeOfAccountingEntry = "z",
		};

		var actual = Map.MapComposite<C596_AccountingEntryTypeDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredTypeOfAccountingEntryIdentification(string typeOfAccountingEntryIdentification, bool isValidExpected)
	{
		var subject = new C596_AccountingEntryTypeDetails();
		//Required fields
		//Test Parameters
		subject.TypeOfAccountingEntryIdentification = typeOfAccountingEntryIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

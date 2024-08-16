using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C551Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "u:s:p";

		var expected = new C551_BankOperation()
		{
			BankOperationCoded = "u",
			CodeListQualifier = "s",
			CodeListResponsibleAgencyCoded = "p",
		};

		var actual = Map.MapComposite<C551_BankOperation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredBankOperationCoded(string bankOperationCoded, bool isValidExpected)
	{
		var subject = new C551_BankOperation();
		//Required fields
		//Test Parameters
		subject.BankOperationCoded = bankOperationCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

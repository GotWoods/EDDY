using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C551Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "G:B:F";

		var expected = new C551_BankOperation()
		{
			BankOperationCode = "G",
			CodeListIdentificationCode = "B",
			CodeListResponsibleAgencyCode = "F",
		};

		var actual = Map.MapComposite<C551_BankOperation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredBankOperationCode(string bankOperationCode, bool isValidExpected)
	{
		var subject = new C551_BankOperation();
		//Required fields
		//Test Parameters
		subject.BankOperationCode = bankOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

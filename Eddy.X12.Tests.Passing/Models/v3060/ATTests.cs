using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class ATTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AT*C*VW81oOX*U*Fl8*6*phW0*Xnm*RHW7uX8Y*F*D";

		var expected = new AT_FinancialAccounting()
		{
			IndustryCode = "C",
			TreasurySymbolNumber = "VW81oOX",
			BudgetActivityNumber = "U",
			ObjectClassNumber = "Fl8",
			ReimbursableSourceNumber = "6",
			TransactionReferenceNumber = "phW0",
			AccountableStationNumber = "Xnm",
			PayingStationNumber = "RHW7uX8Y",
			Description = "F",
			CodeListQualifierCode = "D",
		};

		var actual = Map.MapObject<AT_FinancialAccounting>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("D", "C", true)]
	[InlineData("D", "", false)]
	[InlineData("", "C", true)]
	public void Validation_ARequiresBCodeListQualifierCode(string codeListQualifierCode, string industryCode, bool isValidExpected)
	{
		var subject = new AT_FinancialAccounting();
		//Required fields
		//Test Parameters
		subject.CodeListQualifierCode = codeListQualifierCode;
		subject.IndustryCode = industryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

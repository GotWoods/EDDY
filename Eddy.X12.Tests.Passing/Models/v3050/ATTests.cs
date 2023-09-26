using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class ATTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AT*j*W5vmJQt*K*wf8*F*Yg8N*sY5*8syI1lvG*i*s";

		var expected = new AT_FinancialAccounting()
		{
			IndustryCode = "j",
			TreasurySymbolNumber = "W5vmJQt",
			BudgetActivityNumber = "K",
			ObjectClassNumber = "wf8",
			ReimbursableSourceNumber = "F",
			TransactionReferenceNumber = "Yg8N",
			AccountableStationNumber = "sY5",
			PayingStationNumber = "8syI1lvG",
			Description = "i",
			CodeListQualifierCode = "s",
		};

		var actual = Map.MapObject<AT_FinancialAccounting>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("s", "j", true)]
	[InlineData("s", "", false)]
	[InlineData("", "j", true)]
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

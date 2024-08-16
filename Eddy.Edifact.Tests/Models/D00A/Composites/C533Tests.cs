using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C533Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "E:i:O";

		var expected = new C533_DutyTaxFeeAccountDetail()
		{
			DutyOrTaxOrFeeAccountCode = "E",
			CodeListIdentificationCode = "i",
			CodeListResponsibleAgencyCode = "O",
		};

		var actual = Map.MapComposite<C533_DutyTaxFeeAccountDetail>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredDutyOrTaxOrFeeAccountCode(string dutyOrTaxOrFeeAccountCode, bool isValidExpected)
	{
		var subject = new C533_DutyTaxFeeAccountDetail();
		//Required fields
		//Test Parameters
		subject.DutyOrTaxOrFeeAccountCode = dutyOrTaxOrFeeAccountCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

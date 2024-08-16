using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C533Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "T:5:i";

		var expected = new C533_DutyTaxFeeAccountDetail()
		{
			DutyOrTaxOrFeeAccountCode = "T",
			CodeListIdentificationCode = "5",
			CodeListResponsibleAgencyCode = "i",
		};

		var actual = Map.MapComposite<C533_DutyTaxFeeAccountDetail>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredDutyOrTaxOrFeeAccountCode(string dutyOrTaxOrFeeAccountCode, bool isValidExpected)
	{
		var subject = new C533_DutyTaxFeeAccountDetail();
		//Required fields
		//Test Parameters
		subject.DutyOrTaxOrFeeAccountCode = dutyOrTaxOrFeeAccountCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

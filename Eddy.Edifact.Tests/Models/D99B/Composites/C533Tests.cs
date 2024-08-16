using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C533Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "C:O:V";

		var expected = new C533_DutyTaxFeeAccountDetail()
		{
			DutyTaxFeeAccountIdentification = "C",
			CodeListIdentificationCode = "O",
			CodeListResponsibleAgencyCode = "V",
		};

		var actual = Map.MapComposite<C533_DutyTaxFeeAccountDetail>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredDutyTaxFeeAccountIdentification(string dutyTaxFeeAccountIdentification, bool isValidExpected)
	{
		var subject = new C533_DutyTaxFeeAccountDetail();
		//Required fields
		//Test Parameters
		subject.DutyTaxFeeAccountIdentification = dutyTaxFeeAccountIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C533Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "n:I:a";

		var expected = new C533_DutyTaxFeeAccountDetail()
		{
			DutyTaxFeeAccountIdentification = "n",
			CodeListQualifier = "I",
			CodeListResponsibleAgencyCoded = "a",
		};

		var actual = Map.MapComposite<C533_DutyTaxFeeAccountDetail>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredDutyTaxFeeAccountIdentification(string dutyTaxFeeAccountIdentification, bool isValidExpected)
	{
		var subject = new C533_DutyTaxFeeAccountDetail();
		//Required fields
		//Test Parameters
		subject.DutyTaxFeeAccountIdentification = dutyTaxFeeAccountIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

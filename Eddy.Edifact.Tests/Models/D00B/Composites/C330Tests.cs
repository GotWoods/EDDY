using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C330Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "v:g:Z";

		var expected = new C330_InsuranceCoverType()
		{
			InsuranceCoverTypeCode = "v",
			CodeListIdentificationCode = "g",
			CodeListResponsibleAgencyCode = "Z",
		};

		var actual = Map.MapComposite<C330_InsuranceCoverType>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredInsuranceCoverTypeCode(string insuranceCoverTypeCode, bool isValidExpected)
	{
		var subject = new C330_InsuranceCoverType();
		//Required fields
		//Test Parameters
		subject.InsuranceCoverTypeCode = insuranceCoverTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C330Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "U:V:Z";

		var expected = new C330_InsuranceCoverType()
		{
			InsuranceCoverTypeCode = "U",
			CodeListIdentificationCode = "V",
			CodeListResponsibleAgencyCode = "Z",
		};

		var actual = Map.MapComposite<C330_InsuranceCoverType>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredInsuranceCoverTypeCode(string insuranceCoverTypeCode, bool isValidExpected)
	{
		var subject = new C330_InsuranceCoverType();
		//Required fields
		//Test Parameters
		subject.InsuranceCoverTypeCode = insuranceCoverTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

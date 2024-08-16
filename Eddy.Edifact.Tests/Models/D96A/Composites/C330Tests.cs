using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C330Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "z:0:X";

		var expected = new C330_InsuranceCoverType()
		{
			InsuranceCoverTypeCoded = "z",
			CodeListQualifier = "0",
			CodeListResponsibleAgencyCoded = "X",
		};

		var actual = Map.MapComposite<C330_InsuranceCoverType>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredInsuranceCoverTypeCoded(string insuranceCoverTypeCoded, bool isValidExpected)
	{
		var subject = new C330_InsuranceCoverType();
		//Required fields
		//Test Parameters
		subject.InsuranceCoverTypeCoded = insuranceCoverTypeCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

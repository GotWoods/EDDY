using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v6010.Composites;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class EQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EQ*N**Rhj*4*8";

		var expected = new EQ_EligibilityOrBenefitInquiry()
		{
			IndustryCode = "N",
			CompositeMedicalProcedureIdentifier = null,
			CoverageLevelCode = "Rhj",
			InsuranceTypeCode = "4",
			DiagnosisCodePointer = 8,
		};

		var actual = Map.MapObject<EQ_EligibilityOrBenefitInquiry>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("N", "A", true)]
	[InlineData("N", "", true)]
	[InlineData("", "A", true)]
	public void Validation_AtLeastOneIndustryCode(string industryCode, string compositeMedicalProcedureIdentifier, bool isValidExpected)
	{
		var subject = new EQ_EligibilityOrBenefitInquiry();
		//Required fields
		//Test Parameters
		subject.IndustryCode = industryCode;
		if (compositeMedicalProcedureIdentifier != "") 
			subject.CompositeMedicalProcedureIdentifier = new C003_CompositeMedicalProcedureIdentifier();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}

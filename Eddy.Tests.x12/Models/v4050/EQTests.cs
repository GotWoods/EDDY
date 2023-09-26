using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class EQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EQ*K**gJn*1*";

		var expected = new EQ_EligibilityOrBenefitInquiry()
		{
			ServiceTypeCode = "K",
			CompositeMedicalProcedureIdentifier = null,
			CoverageLevelCode = "gJn",
			InsuranceTypeCode = "1",
			CompositeDiagnosisCodePointer = null,
		};

		var actual = Map.MapObject<EQ_EligibilityOrBenefitInquiry>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("K", "A", true)]
	[InlineData("K", "", true)]
	[InlineData("", "A", true)]
	public void Validation_AtLeastOneServiceTypeCode(string serviceTypeCode, string compositeMedicalProcedureIdentifier, bool isValidExpected)
	{
		var subject = new EQ_EligibilityOrBenefitInquiry();
		//Required fields
		//Test Parameters
		subject.ServiceTypeCode = serviceTypeCode;
		if (compositeMedicalProcedureIdentifier != "") 
			subject.CompositeMedicalProcedureIdentifier = new C003_CompositeMedicalProcedureIdentifier();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}

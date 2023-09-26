using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class EQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EQ*4**SHk*7";

		var expected = new EQ_EligibilityOrBenefitInquiry()
		{
			ServiceTypeCode = "4",
			CompositeMedicalProcedureIdentifier = null,
			CoverageLevelCode = "SHk",
			InsuranceTypeCode = "7",
		};

		var actual = Map.MapObject<EQ_EligibilityOrBenefitInquiry>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("4", "A", true)]
	[InlineData("4", "", true)]
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

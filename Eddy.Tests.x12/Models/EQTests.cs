using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class EQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EQ***dVA*v*6*4";

		var expected = new EQ_EligibilityOrBenefitInquiry()
		{
			ServiceType = null,
			CompositeMedicalProcedureIdentifier = null,
			CoverageLevelCode = "dVA",
			InsuranceProductCode = "v",
			DiagnosisCodePointer = 6,
			NetworkIndicatorCode = "4",
		};

		var actual = Map.MapObject<EQ_EligibilityOrBenefitInquiry>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}

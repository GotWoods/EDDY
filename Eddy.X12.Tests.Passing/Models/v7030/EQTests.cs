using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7030;

namespace Eddy.x12.Tests.Models.v7030;

public class EQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EQ***n0S*l*7*S";

		var expected = new EQ_EligibilityOrBenefitInquiry()
		{
			ServiceType = null,
			CompositeMedicalProcedureIdentifier = null,
			CoverageLevelCode = "n0S",
			InsuranceProductCode = "l",
			DiagnosisCodePointer = 7,
			NetworkIndicatorCode = "S",
		};

		var actual = Map.MapObject<EQ_EligibilityOrBenefitInquiry>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}

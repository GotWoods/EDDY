using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class CRITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CRI*B41*A*TU*n*q";

		var expected = new CRI_ClaimReportInformation()
		{
			MaintenanceTypeCode = "B41",
			ClaimStatusCode = "A",
			MaintenanceReasonCode = "TU",
			YesNoConditionOrResponseCode = "n",
			FrequencyCode = "q",
		};

		var actual = Map.MapObject<CRI_ClaimReportInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}

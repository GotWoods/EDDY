using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class CL1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CL1*X*8*P*q";

		var expected = new CL1_ClaimCodes()
		{
			PriorityTypeOfAdmissionOrVisit = "X",
			PointOfOriginForAdmissionOrVisit = "8",
			PatientDischargeStatus = "P",
			NursingHomeResidentialStatusCode = "q",
		};

		var actual = Map.MapObject<CL1_ClaimCodes>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}

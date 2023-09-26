using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.Tests.Models.v8010;

public class CL1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CL1*v*E*4*b";

		var expected = new CL1_ClaimCodes()
		{
			PriorityTypeOfAdmissionOrVisit = "v",
			PointOfOriginForAdmissionOrVisit = "E",
			PatientDischargeStatus = "4",
			NursingHomeResidentialStatusCode = "b",
		};

		var actual = Map.MapObject<CL1_ClaimCodes>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}

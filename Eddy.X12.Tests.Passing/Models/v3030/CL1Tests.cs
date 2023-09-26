using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class CL1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CL1*E*d*3*9";

		var expected = new CL1_ClaimCodes()
		{
			AdmissionTypeCode = "E",
			AdmissionSourceCode = "d",
			PatientStatusCode = "3",
			NursingHomeResidentialStatusCode = "9",
		};

		var actual = Map.MapObject<CL1_ClaimCodes>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}

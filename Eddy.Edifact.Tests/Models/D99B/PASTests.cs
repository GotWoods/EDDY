using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class PASTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PAS+I+++";

		var expected = new PAS_Attendance()
		{
			AttendanceTypeCodeQualifier = "I",
			AttendeeCategory = null,
			AttendanceAdmissionDetails = null,
			AttendanceDischargeDetails = null,
		};

		var actual = Map.MapObject<PAS_Attendance>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredAttendanceTypeCodeQualifier(string attendanceTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new PAS_Attendance();
		//Required fields
		//Test Parameters
		subject.AttendanceTypeCodeQualifier = attendanceTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96B;
using Eddy.Edifact.Models.D96B.Composites;

namespace Eddy.Edifact.Tests.Models.D96B;

public class PASTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PAS+M+++";

		var expected = new PAS_Attendance()
		{
			AttendanceQualifier = "M",
			AttendeeCategory = null,
			AttendanceAdmissionDetails = null,
			AttendanceDischargeDetails = null,
		};

		var actual = Map.MapObject<PAS_Attendance>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredAttendanceQualifier(string attendanceQualifier, bool isValidExpected)
	{
		var subject = new PAS_Attendance();
		//Required fields
		//Test Parameters
		subject.AttendanceQualifier = attendanceQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

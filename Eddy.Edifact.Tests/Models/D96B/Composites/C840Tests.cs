using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96B;
using Eddy.Edifact.Models.D96B.Composites;

namespace Eddy.Edifact.Tests.Models.D96B.Composites;

public class C840Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "l:F:H:R";

		var expected = new C840_AttendanceAdmissionDetails()
		{
			AdmissionTypeCoded = "l",
			CodeListQualifier = "F",
			CodeListResponsibleAgencyCoded = "H",
			AdmissionType = "R",
		};

		var actual = Map.MapComposite<C840_AttendanceAdmissionDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

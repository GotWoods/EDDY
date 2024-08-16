using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C840Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "B:b:1:2";

		var expected = new C840_AttendanceAdmissionDetails()
		{
			AdmissionTypeDescriptionCode = "B",
			CodeListIdentificationCode = "b",
			CodeListResponsibleAgencyCode = "1",
			AdmissionTypeDescription = "2",
		};

		var actual = Map.MapComposite<C840_AttendanceAdmissionDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

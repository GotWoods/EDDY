using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C840Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "a:A:i:v";

		var expected = new C840_AttendanceAdmissionDetails()
		{
			AdmissionTypeDescriptionCode = "a",
			CodeListIdentificationCode = "A",
			CodeListResponsibleAgencyCode = "i",
			AdmissionTypeDescription = "v",
		};

		var actual = Map.MapComposite<C840_AttendanceAdmissionDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

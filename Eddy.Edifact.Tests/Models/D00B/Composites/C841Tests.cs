using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C841Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "f:6:q:2";

		var expected = new C841_AttendanceDischargeDetails()
		{
			DischargeTypeDescriptionCode = "f",
			CodeListIdentificationCode = "6",
			CodeListResponsibleAgencyCode = "q",
			DischargeTypeDescription = "2",
		};

		var actual = Map.MapComposite<C841_AttendanceDischargeDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

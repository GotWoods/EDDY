using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96B;
using Eddy.Edifact.Models.D96B.Composites;

namespace Eddy.Edifact.Tests.Models.D96B.Composites;

public class C841Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "U:A:l:K";

		var expected = new C841_AttendanceDischargeDetails()
		{
			DischargeTypeCoded = "U",
			CodeListQualifier = "A",
			CodeListResponsibleAgencyCoded = "l",
			DischargeType = "K",
		};

		var actual = Map.MapComposite<C841_AttendanceDischargeDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

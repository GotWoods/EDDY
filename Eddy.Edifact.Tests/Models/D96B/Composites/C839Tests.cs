using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96B;
using Eddy.Edifact.Models.D96B.Composites;

namespace Eddy.Edifact.Tests.Models.D96B.Composites;

public class C839Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "F:0:Z:R";

		var expected = new C839_AttendeeCategory()
		{
			AttendeeCategoryCoded = "F",
			CodeListQualifier = "0",
			CodeListResponsibleAgencyCoded = "Z",
			AttendeeCategory = "R",
		};

		var actual = Map.MapComposite<C839_AttendeeCategory>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

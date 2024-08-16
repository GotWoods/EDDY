using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98B;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Tests.Models.D98B.Composites;

public class C030Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "U:7:t";

		var expected = new C030_EventType()
		{
			EventTypeCoded = "U",
			CodeListQualifier = "7",
			CodeListResponsibleAgencyCoded = "t",
		};

		var actual = Map.MapComposite<C030_EventType>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

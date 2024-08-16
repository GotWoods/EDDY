using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C515Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "b:0:v:Y";

		var expected = new C515_TestReason()
		{
			TestReasonIdentification = "b",
			CodeListQualifier = "0",
			CodeListResponsibleAgencyCoded = "v",
			TestReason = "Y",
		};

		var actual = Map.MapComposite<C515_TestReason>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

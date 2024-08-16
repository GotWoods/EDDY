using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C515Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "k:h:v:d";

		var expected = new C515_TestReason()
		{
			TestReasonNameCode = "k",
			CodeListIdentificationCode = "h",
			CodeListResponsibleAgencyCode = "v",
			TestReasonName = "d",
		};

		var actual = Map.MapComposite<C515_TestReason>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

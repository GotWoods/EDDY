using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C515Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "7:S:9:V";

		var expected = new C515_TestReason()
		{
			TestReasonNameCode = "7",
			CodeListIdentificationCode = "S",
			CodeListResponsibleAgencyCode = "9",
			TestReasonName = "V",
		};

		var actual = Map.MapComposite<C515_TestReason>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

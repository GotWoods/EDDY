using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C515Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "D:E:8:W";

		var expected = new C515_TestReason()
		{
			TestReasonIdentification = "D",
			CodeListIdentificationCode = "E",
			CodeListResponsibleAgencyCode = "8",
			TestReason = "W",
		};

		var actual = Map.MapComposite<C515_TestReason>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

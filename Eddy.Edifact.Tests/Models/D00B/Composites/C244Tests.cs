using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C244Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "i:P:S:X";

		var expected = new C244_TestMethod()
		{
			TestMethodIdentifier = "i",
			CodeListIdentificationCode = "P",
			CodeListResponsibleAgencyCode = "S",
			TestDescription = "X",
		};

		var actual = Map.MapComposite<C244_TestMethod>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

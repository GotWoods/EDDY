using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C244Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "t:r:0:Z";

		var expected = new C244_TestMethod()
		{
			TestMethodIdentifier = "t",
			CodeListIdentificationCode = "r",
			CodeListResponsibleAgencyCode = "0",
			TestDescription = "Z",
		};

		var actual = Map.MapComposite<C244_TestMethod>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

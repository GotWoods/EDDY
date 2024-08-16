using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C244Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "P:h:C:E";

		var expected = new C244_TestMethod()
		{
			TestMethodIdentification = "P",
			CodeListQualifier = "h",
			CodeListResponsibleAgencyCoded = "C",
			TestDescription = "E",
		};

		var actual = Map.MapComposite<C244_TestMethod>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

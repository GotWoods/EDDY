using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C244Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "K:T:X:V";

		var expected = new C244_TestMethod()
		{
			TestMethodIdentification = "K",
			CodeListIdentificationCode = "T",
			CodeListResponsibleAgencyCode = "X",
			TestDescription = "V",
		};

		var actual = Map.MapComposite<C244_TestMethod>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

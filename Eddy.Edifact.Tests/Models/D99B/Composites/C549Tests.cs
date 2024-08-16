using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C549Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "d:W:x:r";

		var expected = new C549_MonetaryAmountFunction()
		{
			MonetaryAmountFunctionDescriptionCode = "d",
			CodeListIdentificationCode = "W",
			CodeListResponsibleAgencyCode = "x",
			MonetaryAmountFunctionDescription = "r",
		};

		var actual = Map.MapComposite<C549_MonetaryAmountFunction>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

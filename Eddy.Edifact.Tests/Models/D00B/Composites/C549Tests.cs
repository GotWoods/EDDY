using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C549Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "G:K:p:x";

		var expected = new C549_MonetaryAmountFunction()
		{
			MonetaryAmountFunctionDescriptionCode = "G",
			CodeListIdentificationCode = "K",
			CodeListResponsibleAgencyCode = "p",
			MonetaryAmountFunctionDescription = "x",
		};

		var actual = Map.MapComposite<C549_MonetaryAmountFunction>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

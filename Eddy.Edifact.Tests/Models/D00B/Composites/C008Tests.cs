using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C008Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "Q:n:J:e";

		var expected = new C008_MonetaryAmountFunctionDetail()
		{
			MonetaryAmountFunctionDetailDescriptionCode = "Q",
			CodeListIdentificationCode = "n",
			CodeListResponsibleAgencyCode = "J",
			MonetaryAmountFunctionDetailDescription = "e",
		};

		var actual = Map.MapComposite<C008_MonetaryAmountFunctionDetail>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

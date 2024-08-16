using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C008Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "N:s:4:u";

		var expected = new C008_MonetaryAmountFunctionDetail()
		{
			MonetaryAmountFunctionDetailCode = "N",
			CodeListIdentificationCode = "s",
			CodeListResponsibleAgencyCode = "4",
			MonetaryAmountFunctionDetailDescription = "u",
		};

		var actual = Map.MapComposite<C008_MonetaryAmountFunctionDetail>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

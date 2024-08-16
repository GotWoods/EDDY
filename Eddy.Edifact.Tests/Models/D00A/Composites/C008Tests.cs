using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C008Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "8:u:w:r";

		var expected = new C008_MonetaryAmountFunctionDetail()
		{
			MonetaryAmountFunctionDetailDescriptionCode = "8",
			CodeListIdentificationCode = "u",
			CodeListResponsibleAgencyCode = "w",
			MonetaryAmountFunctionDetailDescription = "r",
		};

		var actual = Map.MapComposite<C008_MonetaryAmountFunctionDetail>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99A;
using Eddy.Edifact.Models.D99A.Composites;

namespace Eddy.Edifact.Tests.Models.D99A.Composites;

public class E018Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "c:1:G";

		var expected = new E018_PriceInformation()
		{
			PriceQualifier = "c",
			Price = "1",
			PriceTypeCoded = "G",
		};

		var actual = Map.MapComposite<E018_PriceInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredPriceQualifier(string priceQualifier, bool isValidExpected)
	{
		var subject = new E018_PriceInformation();
		//Required fields
		//Test Parameters
		subject.PriceQualifier = priceQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

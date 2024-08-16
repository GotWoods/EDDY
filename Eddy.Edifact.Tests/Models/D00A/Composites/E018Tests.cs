using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E018Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "a:K:2";

		var expected = new E018_PriceInformation()
		{
			PriceCodeQualifier = "a",
			PriceAmount = "K",
			PriceTypeCode = "2",
		};

		var actual = Map.MapComposite<E018_PriceInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredPriceCodeQualifier(string priceCodeQualifier, bool isValidExpected)
	{
		var subject = new E018_PriceInformation();
		//Required fields
		//Test Parameters
		subject.PriceCodeQualifier = priceCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

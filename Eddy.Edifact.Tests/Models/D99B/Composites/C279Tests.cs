using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C279Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "j:i";

		var expected = new C279_QuantityDifferenceInformation()
		{
			QuantityDifference = "j",
			QuantityTypeCodeQualifier = "i",
		};

		var actual = Map.MapComposite<C279_QuantityDifferenceInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredQuantityDifference(string quantityDifference, bool isValidExpected)
	{
		var subject = new C279_QuantityDifferenceInformation();
		//Required fields
		//Test Parameters
		subject.QuantityDifference = quantityDifference;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

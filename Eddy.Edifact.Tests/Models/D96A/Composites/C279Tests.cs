using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C279Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "g:v";

		var expected = new C279_QuantityDifferenceInformation()
		{
			QuantityDifference = "g",
			QuantityQualifier = "v",
		};

		var actual = Map.MapComposite<C279_QuantityDifferenceInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredQuantityDifference(string quantityDifference, bool isValidExpected)
	{
		var subject = new C279_QuantityDifferenceInformation();
		//Required fields
		//Test Parameters
		subject.QuantityDifference = quantityDifference;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

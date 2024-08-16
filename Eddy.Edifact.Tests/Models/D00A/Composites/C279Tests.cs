using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C279Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "T:w";

		var expected = new C279_QuantityDifferenceInformation()
		{
			QuantityVarianceValue = "T",
			QuantityTypeCodeQualifier = "w",
		};

		var actual = Map.MapComposite<C279_QuantityDifferenceInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredQuantityVarianceValue(string quantityVarianceValue, bool isValidExpected)
	{
		var subject = new C279_QuantityDifferenceInformation();
		//Required fields
		//Test Parameters
		subject.QuantityVarianceValue = quantityVarianceValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

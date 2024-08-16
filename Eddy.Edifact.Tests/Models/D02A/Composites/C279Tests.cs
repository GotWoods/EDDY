using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D02A;
using Eddy.Edifact.Models.D02A.Composites;

namespace Eddy.Edifact.Tests.Models.D02A.Composites;

public class C279Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "k:u";

		var expected = new C279_QuantityDifferenceInformation()
		{
			VarianceQuantity = "k",
			QuantityTypeCodeQualifier = "u",
		};

		var actual = Map.MapComposite<C279_QuantityDifferenceInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredVarianceQuantity(string varianceQuantity, bool isValidExpected)
	{
		var subject = new C279_QuantityDifferenceInformation();
		//Required fields
		//Test Parameters
		subject.VarianceQuantity = varianceQuantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C210Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "g:9:z:k:7:p:7:D:0:b";

		var expected = new C210_MarksAndLabels()
		{
			ShippingMarksDescription = "g",
			ShippingMarksDescription2 = "9",
			ShippingMarksDescription3 = "z",
			ShippingMarksDescription4 = "k",
			ShippingMarksDescription5 = "7",
			ShippingMarksDescription6 = "p",
			ShippingMarksDescription7 = "7",
			ShippingMarksDescription8 = "D",
			ShippingMarksDescription9 = "0",
			ShippingMarksDescription10 = "b",
		};

		var actual = Map.MapComposite<C210_MarksAndLabels>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredShippingMarksDescription(string shippingMarksDescription, bool isValidExpected)
	{
		var subject = new C210_MarksAndLabels();
		//Required fields
		//Test Parameters
		subject.ShippingMarksDescription = shippingMarksDescription;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C210Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "l:M:8:Z:I:n:X:s:Q:Q";

		var expected = new C210_MarksAndLabels()
		{
			ShippingMarks = "l",
			ShippingMarks2 = "M",
			ShippingMarks3 = "8",
			ShippingMarks4 = "Z",
			ShippingMarks5 = "I",
			ShippingMarks6 = "n",
			ShippingMarks7 = "X",
			ShippingMarks8 = "s",
			ShippingMarks9 = "Q",
			ShippingMarks10 = "Q",
		};

		var actual = Map.MapComposite<C210_MarksAndLabels>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredShippingMarks(string shippingMarks, bool isValidExpected)
	{
		var subject = new C210_MarksAndLabels();
		//Required fields
		//Test Parameters
		subject.ShippingMarks = shippingMarks;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

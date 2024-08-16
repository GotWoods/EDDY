using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C059Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "f:P:P:g";

		var expected = new C059_Street()
		{
			StreetAndNumberPOBox = "f",
			StreetAndNumberPOBox2 = "P",
			StreetAndNumberPOBox3 = "P",
			StreetAndNumberPOBox4 = "g",
		};

		var actual = Map.MapComposite<C059_Street>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredStreetAndNumberPOBox(string streetAndNumberPOBox, bool isValidExpected)
	{
		var subject = new C059_Street();
		//Required fields
		//Test Parameters
		subject.StreetAndNumberPOBox = streetAndNumberPOBox;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

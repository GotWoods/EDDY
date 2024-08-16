using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D17A;
using Eddy.Edifact.Models.D17A.Composites;

namespace Eddy.Edifact.Tests.Models.D17A.Composites;

public class C059Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "V:d:6:B";

		var expected = new C059_Street()
		{
			StreetAndNumberOrPostOfficeBoxIdentifier = "V",
			StreetAndNumberOrPostOfficeBoxIdentifier2 = "d",
			StreetAndNumberOrPostOfficeBoxIdentifier3 = "6",
			StreetAndNumberOrPostOfficeBoxIdentifier4 = "B",
		};

		var actual = Map.MapComposite<C059_Street>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredStreetAndNumberOrPostOfficeBoxIdentifier(string streetAndNumberOrPostOfficeBoxIdentifier, bool isValidExpected)
	{
		var subject = new C059_Street();
		//Required fields
		//Test Parameters
		subject.StreetAndNumberOrPostOfficeBoxIdentifier = streetAndNumberOrPostOfficeBoxIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

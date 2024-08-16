using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C059Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "o:f:b:B";

		var expected = new C059_Street()
		{
			StreetAndNumberOrPostOfficeBoxIdentifier = "o",
			StreetAndNumberOrPostOfficeBoxIdentifier2 = "f",
			StreetAndNumberOrPostOfficeBoxIdentifier3 = "b",
			StreetAndNumberOrPostOfficeBoxIdentifier4 = "B",
		};

		var actual = Map.MapComposite<C059_Street>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredStreetAndNumberOrPostOfficeBoxIdentifier(string streetAndNumberOrPostOfficeBoxIdentifier, bool isValidExpected)
	{
		var subject = new C059_Street();
		//Required fields
		//Test Parameters
		subject.StreetAndNumberOrPostOfficeBoxIdentifier = streetAndNumberOrPostOfficeBoxIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

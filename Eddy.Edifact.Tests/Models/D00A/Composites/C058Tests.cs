using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C058Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "7:0:q:k:L";

		var expected = new C058_NameAndAddress()
		{
			NameAndAddressDescription = "7",
			NameAndAddressDescription2 = "0",
			NameAndAddressDescription3 = "q",
			NameAndAddressDescription4 = "k",
			NameAndAddressDescription5 = "L",
		};

		var actual = Map.MapComposite<C058_NameAndAddress>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredNameAndAddressDescription(string nameAndAddressDescription, bool isValidExpected)
	{
		var subject = new C058_NameAndAddress();
		//Required fields
		//Test Parameters
		subject.NameAndAddressDescription = nameAndAddressDescription;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

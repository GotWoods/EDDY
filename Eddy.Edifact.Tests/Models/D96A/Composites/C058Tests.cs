using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C058Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "q:v:a:K:N";

		var expected = new C058_NameAndAddress()
		{
			NameAndAddressLine = "q",
			NameAndAddressLine2 = "v",
			NameAndAddressLine3 = "a",
			NameAndAddressLine4 = "K",
			NameAndAddressLine5 = "N",
		};

		var actual = Map.MapComposite<C058_NameAndAddress>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredNameAndAddressLine(string nameAndAddressLine, bool isValidExpected)
	{
		var subject = new C058_NameAndAddress();
		//Required fields
		//Test Parameters
		subject.NameAndAddressLine = nameAndAddressLine;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

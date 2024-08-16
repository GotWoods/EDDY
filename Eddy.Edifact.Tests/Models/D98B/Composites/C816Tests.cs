using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98B;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Tests.Models.D98B.Composites;

public class C816Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "r:t:R:C";

		var expected = new C816_NameComponentDetails()
		{
			NameComponentQualifier = "r",
			NameComponent = "t",
			NameComponentUsageCoded = "R",
			NameComponentOriginalRepresentationCoded = "C",
		};

		var actual = Map.MapComposite<C816_NameComponentDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredNameComponentQualifier(string nameComponentQualifier, bool isValidExpected)
	{
		var subject = new C816_NameComponentDetails();
		//Required fields
		//Test Parameters
		subject.NameComponentQualifier = nameComponentQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

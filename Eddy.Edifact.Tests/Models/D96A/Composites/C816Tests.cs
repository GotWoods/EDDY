using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C816Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "l:O:X:K";

		var expected = new C816_NameComponentDetails()
		{
			NameComponentQualifier = "l",
			NameComponent = "O",
			NameComponentStatusCoded = "X",
			NameComponentOriginalRepresentationCoded = "K",
		};

		var actual = Map.MapComposite<C816_NameComponentDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredNameComponentQualifier(string nameComponentQualifier, bool isValidExpected)
	{
		var subject = new C816_NameComponentDetails();
		//Required fields
		//Test Parameters
		subject.NameComponentQualifier = nameComponentQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

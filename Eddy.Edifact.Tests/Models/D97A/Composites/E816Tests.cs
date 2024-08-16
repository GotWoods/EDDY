using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E816Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "q:Z:C:3";

		var expected = new E816_NameComponentDetails()
		{
			NameComponentQualifier = "q",
			NameComponent = "Z",
			NameComponentStatusCoded = "C",
			NameComponentOriginalRepresentationCoded = "3",
		};

		var actual = Map.MapComposite<E816_NameComponentDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredNameComponentQualifier(string nameComponentQualifier, bool isValidExpected)
	{
		var subject = new E816_NameComponentDetails();
		//Required fields
		//Test Parameters
		subject.NameComponentQualifier = nameComponentQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

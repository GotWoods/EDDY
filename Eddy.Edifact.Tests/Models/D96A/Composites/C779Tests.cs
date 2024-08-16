using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C779Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "a:I";

		var expected = new C779_ArrayStructureIdentification()
		{
			ArrayStructureIdentifier = "a",
			IdentityNumberQualifier = "I",
		};

		var actual = Map.MapComposite<C779_ArrayStructureIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredArrayStructureIdentifier(string arrayStructureIdentifier, bool isValidExpected)
	{
		var subject = new C779_ArrayStructureIdentification();
		//Required fields
		//Test Parameters
		subject.ArrayStructureIdentifier = arrayStructureIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

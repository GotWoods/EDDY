using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C786Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "V:t";

		var expected = new C786_StructureComponentIdentification()
		{
			StructureComponentIdentifier = "V",
			IdentityNumberQualifier = "t",
		};

		var actual = Map.MapComposite<C786_StructureComponentIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredStructureComponentIdentifier(string structureComponentIdentifier, bool isValidExpected)
	{
		var subject = new C786_StructureComponentIdentification();
		//Required fields
		//Test Parameters
		subject.StructureComponentIdentifier = structureComponentIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

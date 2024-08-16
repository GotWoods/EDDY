using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C786Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "K:a";

		var expected = new C786_StructureComponentIdentification()
		{
			StructureComponentIdentifier = "K",
			ObjectIdentificationCodeQualifier = "a",
		};

		var actual = Map.MapComposite<C786_StructureComponentIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredStructureComponentIdentifier(string structureComponentIdentifier, bool isValidExpected)
	{
		var subject = new C786_StructureComponentIdentification();
		//Required fields
		//Test Parameters
		subject.StructureComponentIdentifier = structureComponentIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

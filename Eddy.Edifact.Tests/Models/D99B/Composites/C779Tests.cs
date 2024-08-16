using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C779Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "9:j";

		var expected = new C779_ArrayStructureIdentification()
		{
			ArrayStructureIdentifier = "9",
			ObjectIdentificationCodeQualifier = "j",
		};

		var actual = Map.MapComposite<C779_ArrayStructureIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredArrayStructureIdentifier(string arrayStructureIdentifier, bool isValidExpected)
	{
		var subject = new C779_ArrayStructureIdentification();
		//Required fields
		//Test Parameters
		subject.ArrayStructureIdentifier = arrayStructureIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

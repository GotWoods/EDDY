using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C779Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "L:C";

		var expected = new C779_ArrayStructureIdentification()
		{
			ArrayCellStructureIdentifier = "L",
			ObjectIdentificationCodeQualifier = "C",
		};

		var actual = Map.MapComposite<C779_ArrayStructureIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredArrayCellStructureIdentifier(string arrayCellStructureIdentifier, bool isValidExpected)
	{
		var subject = new C779_ArrayStructureIdentification();
		//Required fields
		//Test Parameters
		subject.ArrayCellStructureIdentifier = arrayCellStructureIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

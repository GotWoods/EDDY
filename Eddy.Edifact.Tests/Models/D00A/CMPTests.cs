using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class CMPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CMP+N+R+0";

		var expected = new CMP_CompositeDataElementIdentification()
		{
			CompositeDataElementTagIdentifier = "N",
			DesignatedClassCode = "R",
			MaintenanceOperationCode = "0",
		};

		var actual = Map.MapObject<CMP_CompositeDataElementIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredCompositeDataElementTagIdentifier(string compositeDataElementTagIdentifier, bool isValidExpected)
	{
		var subject = new CMP_CompositeDataElementIdentification();
		//Required fields
		//Test Parameters
		subject.CompositeDataElementTagIdentifier = compositeDataElementTagIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

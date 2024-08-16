using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class CMPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CMP+M+5+e";

		var expected = new CMP_CompositeDataElementIdentification()
		{
			CompositeDataElementTag = "M",
			ClassDesignatorCoded = "5",
			MaintenanceOperationCoded = "e",
		};

		var actual = Map.MapObject<CMP_CompositeDataElementIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredCompositeDataElementTag(string compositeDataElementTag, bool isValidExpected)
	{
		var subject = new CMP_CompositeDataElementIdentification();
		//Required fields
		//Test Parameters
		subject.CompositeDataElementTag = compositeDataElementTag;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

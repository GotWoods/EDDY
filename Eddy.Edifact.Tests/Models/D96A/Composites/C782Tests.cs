using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C782Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "y:V";

		var expected = new C782_DataSetIdentification()
		{
			DataSetIdentifier = "y",
			IdentityNumberQualifier = "V",
		};

		var actual = Map.MapComposite<C782_DataSetIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredDataSetIdentifier(string dataSetIdentifier, bool isValidExpected)
	{
		var subject = new C782_DataSetIdentification();
		//Required fields
		//Test Parameters
		subject.DataSetIdentifier = dataSetIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

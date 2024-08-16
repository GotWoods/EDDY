using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C782Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "n:o";

		var expected = new C782_DataSetIdentification()
		{
			DataSetIdentifier = "n",
			ObjectIdentificationCodeQualifier = "o",
		};

		var actual = Map.MapComposite<C782_DataSetIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredDataSetIdentifier(string dataSetIdentifier, bool isValidExpected)
	{
		var subject = new C782_DataSetIdentification();
		//Required fields
		//Test Parameters
		subject.DataSetIdentifier = dataSetIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

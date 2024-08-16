using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C546Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "n:A";

		var expected = new C546_IndexValue()
		{
			IndexValue = "n",
			IndexValueRepresentationCoded = "A",
		};

		var actual = Map.MapComposite<C546_IndexValue>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredIndexValue(string indexValue, bool isValidExpected)
	{
		var subject = new C546_IndexValue();
		//Required fields
		//Test Parameters
		subject.IndexValue = indexValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

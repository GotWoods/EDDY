using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C546Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "K:o";

		var expected = new C546_IndexValue()
		{
			IndexValue = "K",
			IndexValueRepresentationCode = "o",
		};

		var actual = Map.MapComposite<C546_IndexValue>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredIndexValue(string indexValue, bool isValidExpected)
	{
		var subject = new C546_IndexValue();
		//Required fields
		//Test Parameters
		subject.IndexValue = indexValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

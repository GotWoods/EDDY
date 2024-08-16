using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97B;
using Eddy.Edifact.Models.D97B.Composites;

namespace Eddy.Edifact.Tests.Models.D97B.Composites;

public class C546Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "b:f";

		var expected = new C546_IndexValue()
		{
			IndexValue = "b",
			IndexValueRepresentationCoded = "f",
		};

		var actual = Map.MapComposite<C546_IndexValue>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredIndexValue(string indexValue, bool isValidExpected)
	{
		var subject = new C546_IndexValue();
		//Required fields
		//Test Parameters
		subject.IndexValue = indexValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class S504Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "7:H";

		var expected = new S504_ListParameter()
		{
			ListParameterQualifier = "7",
			ListParameter = "H",
		};

		var actual = Map.MapComposite<S504_ListParameter>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredListParameterQualifier(string listParameterQualifier, bool isValidExpected)
	{
		var subject = new S504_ListParameter();
		//Required fields
		subject.ListParameter = "H";
		//Test Parameters
		subject.ListParameterQualifier = listParameterQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredListParameter(string listParameter, bool isValidExpected)
	{
		var subject = new S504_ListParameter();
		//Required fields
		subject.ListParameterQualifier = "7";
		//Test Parameters
		subject.ListParameter = listParameter;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

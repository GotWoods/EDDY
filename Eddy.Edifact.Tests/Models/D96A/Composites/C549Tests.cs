using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C549Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "1:u:f";

		var expected = new C549_MonetaryFunction()
		{
			MonetaryFunctionCoded = "1",
			CodeListQualifier = "u",
			CodeListResponsibleAgencyCoded = "f",
		};

		var actual = Map.MapComposite<C549_MonetaryFunction>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredMonetaryFunctionCoded(string monetaryFunctionCoded, bool isValidExpected)
	{
		var subject = new C549_MonetaryFunction();
		//Required fields
		//Test Parameters
		subject.MonetaryFunctionCoded = monetaryFunctionCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

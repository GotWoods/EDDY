using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C521Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "j:o:V:8:9";

		var expected = new C521_BusinessFunction()
		{
			BusinessFunctionQualifier = "j",
			BusinessFunctionCode = "o",
			CodeListIdentificationCode = "V",
			CodeListResponsibleAgencyCode = "8",
			BusinessDescription = "9",
		};

		var actual = Map.MapComposite<C521_BusinessFunction>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredBusinessFunctionQualifier(string businessFunctionQualifier, bool isValidExpected)
	{
		var subject = new C521_BusinessFunction();
		//Required fields
		subject.BusinessFunctionCode = "o";
		//Test Parameters
		subject.BusinessFunctionQualifier = businessFunctionQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredBusinessFunctionCode(string businessFunctionCode, bool isValidExpected)
	{
		var subject = new C521_BusinessFunction();
		//Required fields
		subject.BusinessFunctionQualifier = "j";
		//Test Parameters
		subject.BusinessFunctionCode = businessFunctionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

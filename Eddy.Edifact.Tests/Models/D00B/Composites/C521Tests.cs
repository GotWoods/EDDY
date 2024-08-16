using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C521Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "f:I:d:U:0";

		var expected = new C521_BusinessFunction()
		{
			BusinessFunctionTypeCodeQualifier = "f",
			BusinessFunctionCode = "I",
			CodeListIdentificationCode = "d",
			CodeListResponsibleAgencyCode = "U",
			BusinessDescription = "0",
		};

		var actual = Map.MapComposite<C521_BusinessFunction>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredBusinessFunctionTypeCodeQualifier(string businessFunctionTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new C521_BusinessFunction();
		//Required fields
		subject.BusinessFunctionCode = "I";
		//Test Parameters
		subject.BusinessFunctionTypeCodeQualifier = businessFunctionTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredBusinessFunctionCode(string businessFunctionCode, bool isValidExpected)
	{
		var subject = new C521_BusinessFunction();
		//Required fields
		subject.BusinessFunctionTypeCodeQualifier = "f";
		//Test Parameters
		subject.BusinessFunctionCode = businessFunctionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

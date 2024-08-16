using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C521Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "7:1:q:d:g";

		var expected = new C521_BusinessFunction()
		{
			BusinessFunctionTypeCodeQualifier = "7",
			BusinessFunctionCode = "1",
			CodeListIdentificationCode = "q",
			CodeListResponsibleAgencyCode = "d",
			BusinessDescription = "g",
		};

		var actual = Map.MapComposite<C521_BusinessFunction>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredBusinessFunctionTypeCodeQualifier(string businessFunctionTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new C521_BusinessFunction();
		//Required fields
		subject.BusinessFunctionCode = "1";
		//Test Parameters
		subject.BusinessFunctionTypeCodeQualifier = businessFunctionTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredBusinessFunctionCode(string businessFunctionCode, bool isValidExpected)
	{
		var subject = new C521_BusinessFunction();
		//Required fields
		subject.BusinessFunctionTypeCodeQualifier = "7";
		//Test Parameters
		subject.BusinessFunctionCode = businessFunctionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

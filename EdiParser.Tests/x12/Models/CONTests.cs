using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class CONTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CON*Xg*8*ef";

		var expected = new CON_ContractNumberDetail()
		{
			ReferenceIdentificationQualifier = "Xg",
			ReferenceIdentification = "8",
			ContractStatusCode = "ef",
		};

		var actual = Map.MapObject<CON_ContractNumberDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		try
		{
			Assert.Equivalent(expected, actual);
		}
		catch
		{
			Assert.Fail(actual.ValidationResult.ToString());
		}
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Xg", true)]
	public void Validatation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new CON_ContractNumberDetail();
		subject.ReferenceIdentification = "8";
		subject.ContractStatusCode = "ef";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validatation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new CON_ContractNumberDetail();
		subject.ReferenceIdentificationQualifier = "Xg";
		subject.ContractStatusCode = "ef";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ef", true)]
	public void Validatation_RequiredContractStatusCode(string contractStatusCode, bool isValidExpected)
	{
		var subject = new CON_ContractNumberDetail();
		subject.ReferenceIdentificationQualifier = "Xg";
		subject.ReferenceIdentification = "8";
		subject.ContractStatusCode = contractStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

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
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Xg", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
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
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
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
	public void Validation_RequiredContractStatusCode(string contractStatusCode, bool isValidExpected)
	{
		var subject = new CON_ContractNumberDetail();
		subject.ReferenceIdentificationQualifier = "Xg";
		subject.ReferenceIdentification = "8";
		subject.ContractStatusCode = contractStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

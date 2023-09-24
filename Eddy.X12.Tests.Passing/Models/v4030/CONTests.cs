using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class CONTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CON*Br*Q*DE";

		var expected = new CON_ContractNumberDetail()
		{
			ReferenceIdentificationQualifier = "Br",
			ReferenceIdentification = "Q",
			ContractStatusCode = "DE",
		};

		var actual = Map.MapObject<CON_ContractNumberDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Br", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new CON_ContractNumberDetail();
		subject.ReferenceIdentification = "Q";
		subject.ContractStatusCode = "DE";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new CON_ContractNumberDetail();
		subject.ReferenceIdentificationQualifier = "Br";
		subject.ContractStatusCode = "DE";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("DE", true)]
	public void Validation_RequiredContractStatusCode(string contractStatusCode, bool isValidExpected)
	{
		var subject = new CON_ContractNumberDetail();
		subject.ReferenceIdentificationQualifier = "Br";
		subject.ReferenceIdentification = "Q";
		subject.ContractStatusCode = contractStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class CONTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CON*8F*2*vn";

		var expected = new CON_ContractNumberDetail()
		{
			ReferenceNumberQualifier = "8F",
			ReferenceNumber = "2",
			ContractStatusCode = "vn",
		};

		var actual = Map.MapObject<CON_ContractNumberDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8F", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new CON_ContractNumberDetail();
		subject.ReferenceNumber = "2";
		subject.ContractStatusCode = "vn";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new CON_ContractNumberDetail();
		subject.ReferenceNumberQualifier = "8F";
		subject.ContractStatusCode = "vn";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vn", true)]
	public void Validation_RequiredContractStatusCode(string contractStatusCode, bool isValidExpected)
	{
		var subject = new CON_ContractNumberDetail();
		subject.ReferenceNumberQualifier = "8F";
		subject.ReferenceNumber = "2";
		subject.ContractStatusCode = contractStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

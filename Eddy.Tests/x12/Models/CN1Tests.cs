using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class CN1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CN1*Zo*7*3*G*4*R";

		var expected = new CN1_ContractInformation()
		{
			ContractTypeCode = "Zo",
			MonetaryAmount = 7,
			PercentDecimalFormat = 3,
			ReferenceIdentification = "G",
			TermsDiscountPercent = 4,
			VersionIdentifier = "R",
		};

		var actual = Map.MapObject<CN1_ContractInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Zo", true)]
	public void Validatation_RequiredContractTypeCode(string contractTypeCode, bool isValidExpected)
	{
		var subject = new CN1_ContractInformation();
		subject.ContractTypeCode = contractTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

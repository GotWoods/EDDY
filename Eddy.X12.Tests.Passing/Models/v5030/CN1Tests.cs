using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class CN1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CN1*m1*4*8*X*3*6";

		var expected = new CN1_ContractInformation()
		{
			ContractTypeCode = "m1",
			MonetaryAmount = 4,
			PercentDecimalFormat = 8,
			ReferenceIdentification = "X",
			TermsDiscountPercent = 3,
			VersionIdentifier = "6",
		};

		var actual = Map.MapObject<CN1_ContractInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m1", true)]
	public void Validation_RequiredContractTypeCode(string contractTypeCode, bool isValidExpected)
	{
		var subject = new CN1_ContractInformation();
		//Required fields
		//Test Parameters
		subject.ContractTypeCode = contractTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

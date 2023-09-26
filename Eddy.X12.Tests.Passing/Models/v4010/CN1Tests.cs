using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class CN1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CN1*wB*2*8*0*4*Y";

		var expected = new CN1_ContractInformation()
		{
			ContractTypeCode = "wB",
			MonetaryAmount = 2,
			Percent = 8,
			ReferenceIdentification = "0",
			TermsDiscountPercent = 4,
			VersionIdentifier = "Y",
		};

		var actual = Map.MapObject<CN1_ContractInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wB", true)]
	public void Validation_RequiredContractTypeCode(string contractTypeCode, bool isValidExpected)
	{
		var subject = new CN1_ContractInformation();
		//Required fields
		//Test Parameters
		subject.ContractTypeCode = contractTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class CN1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CN1*G9*3*8*t*9*4";

		var expected = new CN1_ContractInformation()
		{
			ContractTypeCode = "G9",
			MonetaryAmount = 3,
			Percent = 8,
			ReferenceNumber = "t",
			TermsDiscountPercent = 9,
			VersionIdentifier = "4",
		};

		var actual = Map.MapObject<CN1_ContractInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G9", true)]
	public void Validation_RequiredContractTypeCode(string contractTypeCode, bool isValidExpected)
	{
		var subject = new CN1_ContractInformation();
		//Required fields
		//Test Parameters
		subject.ContractTypeCode = contractTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

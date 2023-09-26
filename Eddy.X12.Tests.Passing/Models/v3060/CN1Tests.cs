using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class CN1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CN1*3e*2*6*v*6*H";

		var expected = new CN1_ContractInformation()
		{
			ContractTypeCode = "3e",
			MonetaryAmount = 2,
			Percent = 6,
			ReferenceIdentification = "v",
			TermsDiscountPercent = 6,
			VersionIdentifier = "H",
		};

		var actual = Map.MapObject<CN1_ContractInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3e", true)]
	public void Validation_RequiredContractTypeCode(string contractTypeCode, bool isValidExpected)
	{
		var subject = new CN1_ContractInformation();
		//Required fields
		//Test Parameters
		subject.ContractTypeCode = contractTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

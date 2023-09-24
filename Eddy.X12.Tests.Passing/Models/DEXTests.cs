using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class DEXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DEX*nx*w7*h*9*B*6";

		var expected = new DEX_DeliveryExecutionInformation()
		{
			SalesTermsCode = "nx",
			RemittanceTypeCode = "w7",
			InvestorOwnershipTypeCode = "h",
			Number = 9,
			CodeListQualifierCode = "B",
			IndustryCode = "6",
		};

		var actual = Map.MapObject<DEX_DeliveryExecutionInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("B", "6", true)]
	[InlineData("", "6", false)]
	[InlineData("B", "", false)]
	public void Validation_AllAreRequiredCodeListQualifierCode(string codeListQualifierCode, string industryCode, bool isValidExpected)
	{
		var subject = new DEX_DeliveryExecutionInformation();
		subject.CodeListQualifierCode = codeListQualifierCode;
		subject.IndustryCode = industryCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

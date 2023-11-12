using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class DEXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DEX*0G*sK*f*3*d*8";

		var expected = new DEX_DeliveryExecutionInformation()
		{
			SalesTermsCode = "0G",
			RemittanceTypeCode = "sK",
			InvestorOwnershipTypeCode = "f",
			Number = 3,
			CodeListQualifierCode = "d",
			IndustryCode = "8",
		};

		var actual = Map.MapObject<DEX_DeliveryExecutionInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("d", "8", true)]
	[InlineData("d", "", false)]
	[InlineData("", "8", false)]
	public void Validation_AllAreRequiredCodeListQualifierCode(string codeListQualifierCode, string industryCode, bool isValidExpected)
	{
		var subject = new DEX_DeliveryExecutionInformation();
		//Required fields
		//Test Parameters
		subject.CodeListQualifierCode = codeListQualifierCode;
		subject.IndustryCode = industryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

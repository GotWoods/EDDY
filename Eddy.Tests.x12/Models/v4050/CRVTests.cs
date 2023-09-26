using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class CRVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CRV*3*Y*an*DQ*8*ba*H";

		var expected = new CRV_ProductOriginReference()
		{
			NetCostCode = "3",
			Amount = "Y",
			CountryCode = "an",
			ProductProcessCharacteristicCode = "DQ",
			PercentIntegerFormat = 8,
			CertificationClauseCode = "ba",
			PreferentialDutyCriteriaCode = "H",
		};

		var actual = Map.MapObject<CRV_ProductOriginReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("DQ", "ba", true)]
	[InlineData("DQ", "", false)]
	[InlineData("", "ba", true)]
	public void Validation_ARequiresBProductProcessCharacteristicCode(string productProcessCharacteristicCode, string certificationClauseCode, bool isValidExpected)
	{
		var subject = new CRV_ProductOriginReference();
		//Required fields
		//Test Parameters
		subject.ProductProcessCharacteristicCode = productProcessCharacteristicCode;
		subject.CertificationClauseCode = certificationClauseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class CRVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CRV*K*T*Df*HB*2*RB*K";

		var expected = new CRV_ProductOriginReference()
		{
			NetCostCode = "K",
			Amount = "T",
			CountryCode = "Df",
			ProductProcessCharacteristicCode = "HB",
			Percent = 2,
			CertificationClauseCode = "RB",
			PreferentialDutyCriteriaCode = "K",
		};

		var actual = Map.MapObject<CRV_ProductOriginReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("HB", "RB", true)]
	[InlineData("HB", "", false)]
	[InlineData("", "RB", true)]
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

using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class BCTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCT*Hp*u*S*v*9U*u*v*a*B*Jp";

		var expected = new BCT_BeginningSegmentForPriceSalesCatalog()
		{
			CatalogPurposeCode = "Hp",
			CatalogNumber = "u",
			CatalogVersionNumber = "S",
			CatalogRevisionNumber = "v",
			UnitOrBasisForMeasurementCode = "9U",
			CatalogNumber2 = "u",
			CatalogVersionNumber2 = "v",
			CatalogRevisionNumber2 = "a",
			Description = "B",
			TransactionSetPurposeCode = "Jp",
		};

		var actual = Map.MapObject<BCT_BeginningSegmentForPriceSalesCatalog>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Hp", true)]
	public void Validation_RequiredCatalogPurposeCode(string catalogPurposeCode, bool isValidExpected)
	{
		var subject = new BCT_BeginningSegmentForPriceSalesCatalog();
		subject.CatalogPurposeCode = catalogPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

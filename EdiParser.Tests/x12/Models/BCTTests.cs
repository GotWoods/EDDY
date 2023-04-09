using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class BCTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCT*7m*V*X*X*wl*k*W*K*U*mF";

		var expected = new BCT_BeginningSegmentForPriceSalesCatalog()
		{
			CatalogPurposeCode = "7m",
			CatalogNumber = "V",
			CatalogVersionNumber = "X",
			CatalogRevisionNumber = "X",
			UnitOrBasisForMeasurementCode = "wl",
			CatalogNumber2 = "k",
			CatalogVersionNumber2 = "W",
			CatalogRevisionNumber2 = "K",
			Description = "U",
			TransactionSetPurposeCode = "mF",
		};

		var actual = Map.MapObject<BCT_BeginningSegmentForPriceSalesCatalog>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		try
		{
			Assert.Equivalent(expected, actual);
		}
		catch
		{
			Assert.Fail(actual.ValidationResult.ToString());
		}
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7m", true)]
	public void Validatation_RequiredCatalogPurposeCode(string catalogPurposeCode, bool isValidExpected)
	{
		var subject = new BCT_BeginningSegmentForPriceSalesCatalog();
		subject.CatalogPurposeCode = catalogPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

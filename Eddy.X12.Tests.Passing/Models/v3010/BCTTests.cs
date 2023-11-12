using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BCTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCT*wW*O*q*v*f7*H*R*U*W*wx";

		var expected = new BCT_BeginningSegmentForPriceSalesCatalog()
		{
			CatalogPurposeCode = "wW",
			CatalogNumber = "O",
			CatalogVersionNumber = "q",
			CatalogRevisionNumber = "v",
			UnitOfMeasurementCode = "f7",
			CatalogNumber2 = "H",
			CatalogVersionNumber2 = "R",
			CatalogRevisionNumber2 = "U",
			Description = "W",
			TransactionSetPurposeCode = "wx",
		};

		var actual = Map.MapObject<BCT_BeginningSegmentForPriceSalesCatalog>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wW", true)]
	public void Validation_RequiredCatalogPurposeCode(string catalogPurposeCode, bool isValidExpected)
	{
		var subject = new BCT_BeginningSegmentForPriceSalesCatalog();
		subject.CatalogNumber = "O";
		subject.CatalogPurposeCode = catalogPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredCatalogNumber(string catalogNumber, bool isValidExpected)
	{
		var subject = new BCT_BeginningSegmentForPriceSalesCatalog();
		subject.CatalogPurposeCode = "wW";
		subject.CatalogNumber = catalogNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

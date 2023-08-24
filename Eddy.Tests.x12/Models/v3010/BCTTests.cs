using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BCTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCT*8j*6*W*m*zx*g*h*u*t*6A";

		var expected = new BCT_BeginningSegmentForPriceSalesCatalog()
		{
			CatalogPurposeCode = "8j",
			CatalogNumber = "6",
			CatalogVersionNumber = "W",
			CatalogRevisionNumber = "m",
			UnitOfMeasurementCode = "zx",
			CatalogNumber2 = "g",
			CatalogVersionNumber2 = "h",
			CatalogRevisionNumber2 = "u",
			Description = "t",
			TransactionSetPurposeCode = "6A",
		};

		var actual = Map.MapObject<BCT_BeginningSegmentForPriceSalesCatalog>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8j", true)]
	public void Validation_RequiredCatalogPurposeCode(string catalogPurposeCode, bool isValidExpected)
	{
		var subject = new BCT_BeginningSegmentForPriceSalesCatalog();
		subject.CatalogNumber = "6";
		subject.CatalogPurposeCode = catalogPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredCatalogNumber(string catalogNumber, bool isValidExpected)
	{
		var subject = new BCT_BeginningSegmentForPriceSalesCatalog();
		subject.CatalogPurposeCode = "8j";
		subject.CatalogNumber = catalogNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

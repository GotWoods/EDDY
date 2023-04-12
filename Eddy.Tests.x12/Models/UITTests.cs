using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models;

public class UITTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "UIT**2*zp";

		var expected = new UIT_UnitDetail()
		{
			CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure(),
			UnitPrice = 2,
			BasisOfUnitPriceCode = "zp",
		};

		var actual = Map.MapObject<UIT_UnitDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("AA", true)]
	public void Validation_RequiredCompositeUnitOfMeasure(string compositeUnitOfMeasure, bool isValidExpected)
	{
		var subject = new UIT_UnitDetail();
        if (compositeUnitOfMeasure != "")
            subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure() { UnitOrBasisForMeasurementCode = compositeUnitOfMeasure };
        
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("", 2, true)]
	[InlineData("zp", 0, false)]
	public void Validation_ARequiresBBasisOfUnitPriceCode(string basisOfUnitPriceCode, decimal unitPrice, bool isValidExpected)
	{
		var subject = new UIT_UnitDetail();
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.BasisOfUnitPriceCode = basisOfUnitPriceCode;
		if (unitPrice > 0)
		subject.UnitPrice = unitPrice;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

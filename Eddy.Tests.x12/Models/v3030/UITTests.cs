using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class UITTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "UIT*ZN*6*yE";

		var expected = new UIT_UnitDetail()
		{
			UnitOrBasisForMeasurementCode = "ZN",
			UnitPrice = 6,
			BasisOfUnitPriceCode = "yE",
		};

		var actual = Map.MapObject<UIT_UnitDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ZN", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new UIT_UnitDetail();
		//Required fields
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("yE", 6, true)]
	[InlineData("yE", 0, false)]
	[InlineData("", 6, true)]
	public void Validation_ARequiresBBasisOfUnitPriceCode(string basisOfUnitPriceCode, decimal unitPrice, bool isValidExpected)
	{
		var subject = new UIT_UnitDetail();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "ZN";
		//Test Parameters
		subject.BasisOfUnitPriceCode = basisOfUnitPriceCode;
		if (unitPrice > 0) 
			subject.UnitPrice = unitPrice;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

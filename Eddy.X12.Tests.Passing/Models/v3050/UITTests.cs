using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class UITTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "UIT**4*LO";

		var expected = new UIT_UnitDetail()
		{
			CompositeUnitOfMeasure = null,
			UnitPrice = 4,
			BasisOfUnitPriceCode = "LO",
		};

		var actual = Map.MapObject<UIT_UnitDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("LO", 4, true)]
	[InlineData("LO", 0, false)]
	[InlineData("", 4, true)]
	public void Validation_ARequiresBBasisOfUnitPriceCode(string basisOfUnitPriceCode, decimal unitPrice, bool isValidExpected)
	{
		var subject = new UIT_UnitDetail();
		//Required fields
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		//Test Parameters
		subject.BasisOfUnitPriceCode = basisOfUnitPriceCode;
		if (unitPrice > 0) 
			subject.UnitPrice = unitPrice;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

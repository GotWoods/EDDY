using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class UITTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "UIT*Q6*3*sk";

		var expected = new UIT_UnitDetail()
		{
			UnitOfMeasurementCode = "Q6",
			UnitPrice = 3,
			BasisOfUnitPriceCode = "sk",
		};

		var actual = Map.MapObject<UIT_UnitDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q6", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new UIT_UnitDetail();
		//Required fields
		//Test Parameters
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("sk", 3, true)]
	[InlineData("sk", 0, false)]
	[InlineData("", 3, true)]
	public void Validation_ARequiresBBasisOfUnitPriceCode(string basisOfUnitPriceCode, decimal unitPrice, bool isValidExpected)
	{
		var subject = new UIT_UnitDetail();
		//Required fields
		subject.UnitOfMeasurementCode = "Q6";
		//Test Parameters
		subject.BasisOfUnitPriceCode = basisOfUnitPriceCode;
		if (unitPrice > 0) 
			subject.UnitPrice = unitPrice;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

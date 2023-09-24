using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class PO3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PO3*7T*ic2tGp*xIL*5*Ii*5*JZ*f";

		var expected = new PO3_AdditionalItemDetail()
		{
			ChangeReasonCode = "7T",
			Date = "ic2tGp",
			PriceQualifier = "xIL",
			UnitPrice = 5,
			BasisOfUnitPriceCode = "Ii",
			Quantity = 5,
			UnitOfMeasurementCode = "JZ",
			Description = "f",
		};

		var actual = Map.MapObject<PO3_AdditionalItemDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7T", true)]
	public void Validation_RequiredChangeReasonCode(string changeReasonCode, bool isValidExpected)
	{
		var subject = new PO3_AdditionalItemDetail();
		subject.Quantity = 5;
		subject.UnitOfMeasurementCode = "JZ";
		subject.ChangeReasonCode = changeReasonCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new PO3_AdditionalItemDetail();
		subject.ChangeReasonCode = "7T";
		subject.UnitOfMeasurementCode = "JZ";
		if (quantity > 0)
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("JZ", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new PO3_AdditionalItemDetail();
		subject.ChangeReasonCode = "7T";
		subject.Quantity = 5;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

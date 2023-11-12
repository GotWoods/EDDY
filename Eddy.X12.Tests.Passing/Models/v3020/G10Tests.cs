using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class G10Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G10*6*4*RH*3*Wb";

		var expected = new G10_TotalOrderInformation()
		{
			QuantityReceived = 6,
			NumberOfUnitsShipped = 4,
			UnitOfMeasurementCode = "RH",
			LadingQuantityReceived = 3,
			UnitOfMeasurementCode2 = "Wb",
		};

		var actual = Map.MapObject<G10_TotalOrderInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredQuantityReceived(decimal quantityReceived, bool isValidExpected)
	{
		var subject = new G10_TotalOrderInformation();
		subject.UnitOfMeasurementCode = "RH";
		if (quantityReceived > 0)
			subject.QuantityReceived = quantityReceived;
		//If one is filled, all are required
		if(subject.LadingQuantityReceived > 0 || subject.LadingQuantityReceived > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.LadingQuantityReceived = 3;
			subject.UnitOfMeasurementCode2 = "Wb";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("RH", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new G10_TotalOrderInformation();
		subject.QuantityReceived = 6;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		//If one is filled, all are required
		if(subject.LadingQuantityReceived > 0 || subject.LadingQuantityReceived > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.LadingQuantityReceived = 3;
			subject.UnitOfMeasurementCode2 = "Wb";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "Wb", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "Wb", false)]
	public void Validation_AllAreRequiredLadingQuantityReceived(int ladingQuantityReceived, string unitOfMeasurementCode2, bool isValidExpected)
	{
		var subject = new G10_TotalOrderInformation();
		subject.QuantityReceived = 6;
		subject.UnitOfMeasurementCode = "RH";
		if (ladingQuantityReceived > 0)
			subject.LadingQuantityReceived = ladingQuantityReceived;
		subject.UnitOfMeasurementCode2 = unitOfMeasurementCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

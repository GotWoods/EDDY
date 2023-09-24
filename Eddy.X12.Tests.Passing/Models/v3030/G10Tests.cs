using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class G10Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G10*2*9*JO*9*mG";

		var expected = new G10_TotalOrderInformation()
		{
			QuantityReceived = 2,
			NumberOfUnitsShipped = 9,
			UnitOrBasisForMeasurementCode = "JO",
			LadingQuantityReceived = 9,
			UnitOrBasisForMeasurementCode2 = "mG",
		};

		var actual = Map.MapObject<G10_TotalOrderInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredQuantityReceived(decimal quantityReceived, bool isValidExpected)
	{
		var subject = new G10_TotalOrderInformation();
		subject.UnitOrBasisForMeasurementCode = "JO";
		if (quantityReceived > 0)
			subject.QuantityReceived = quantityReceived;
		//If one is filled, all are required
		if(subject.LadingQuantityReceived > 0 || subject.LadingQuantityReceived > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.LadingQuantityReceived = 9;
			subject.UnitOrBasisForMeasurementCode2 = "mG";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("JO", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G10_TotalOrderInformation();
		subject.QuantityReceived = 2;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, all are required
		if(subject.LadingQuantityReceived > 0 || subject.LadingQuantityReceived > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.LadingQuantityReceived = 9;
			subject.UnitOrBasisForMeasurementCode2 = "mG";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "mG", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "mG", false)]
	public void Validation_AllAreRequiredLadingQuantityReceived(int ladingQuantityReceived, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new G10_TotalOrderInformation();
		subject.QuantityReceived = 2;
		subject.UnitOrBasisForMeasurementCode = "JO";
		if (ladingQuantityReceived > 0)
			subject.LadingQuantityReceived = ladingQuantityReceived;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

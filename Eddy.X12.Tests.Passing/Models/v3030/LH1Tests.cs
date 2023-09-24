using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class LH1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LH1*AH*8*7OTx0n*4*O*T9*1*A*M*U*0";

		var expected = new LH1_HazardousIdentificationInformation()
		{
			UnitOrBasisForMeasurementCode = "AH",
			LadingQuantity = 8,
			UNNAIdentificationCode = "7OTx0n",
			HazardousMaterialsPage = "4",
			CommodityCode = "O",
			UnitOrBasisForMeasurementCode2 = "T9",
			Quantity = 1,
			CompartmentIDCode = "A",
			ResidueIndicatorCode = "M",
			PackingGroupCode = "U",
			InterimHazardousMaterialRegulatoryNumber = "0",
		};

		var actual = Map.MapObject<LH1_HazardousIdentificationInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("AH", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new LH1_HazardousIdentificationInformation();
		subject.LadingQuantity = 8;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredLadingQuantity(int ladingQuantity, bool isValidExpected)
	{
		var subject = new LH1_HazardousIdentificationInformation();
		subject.UnitOrBasisForMeasurementCode = "AH";
		if (ladingQuantity > 0)
			subject.LadingQuantity = ladingQuantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

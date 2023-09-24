using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class LH1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LH1*qU*3*ATOkpE*e*L*TU*2*Z*I*T*A";

		var expected = new LH1_HazardousIdentificationInformation()
		{
			UnitOrBasisForMeasurementCode = "qU",
			LadingQuantity = 3,
			UNNAIdentificationCode = "ATOkpE",
			HazardousMaterialsPage = "e",
			CommodityCode = "L",
			UnitOrBasisForMeasurementCode2 = "TU",
			Quantity = 2,
			CompartmentIDCode = "Z",
			ResidueIndicatorCode = "I",
			PackingGroupCode = "T",
			InterimHazardousMaterialRegulatoryNumber = "A",
		};

		var actual = Map.MapObject<LH1_HazardousIdentificationInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qU", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new LH1_HazardousIdentificationInformation();
		subject.LadingQuantity = 3;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredLadingQuantity(int ladingQuantity, bool isValidExpected)
	{
		var subject = new LH1_HazardousIdentificationInformation();
		subject.UnitOrBasisForMeasurementCode = "qU";
		if (ladingQuantity > 0)
			subject.LadingQuantity = ladingQuantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

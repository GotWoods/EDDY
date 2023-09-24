using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6020;

namespace Eddy.x12.Tests.Models.v6020;

public class LH1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LH1*ub*6*Eh9clZ*7*J*mJ*9*S*6*d*j*h";

		var expected = new LH1_HazardousIdentificationInformation()
		{
			UnitOrBasisForMeasurementCode = "ub",
			LadingQuantity = 6,
			UNNAIdentificationCode = "Eh9clZ",
			HazardousMaterialsPage = "7",
			CommodityCode = "J",
			UnitOrBasisForMeasurementCode2 = "mJ",
			Quantity = 9,
			CompartmentIDCode = "S",
			ResidueIndicatorCode = "6",
			PackingGroupCode = "d",
			InterimHazardousMaterialRegulatoryNumber = "j",
			IndustryCode = "h",
		};

		var actual = Map.MapObject<LH1_HazardousIdentificationInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ub", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new LH1_HazardousIdentificationInformation();
		subject.LadingQuantity = 6;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "mJ";
			subject.Quantity = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredLadingQuantity(int ladingQuantity, bool isValidExpected)
	{
		var subject = new LH1_HazardousIdentificationInformation();
		subject.UnitOrBasisForMeasurementCode = "ub";
		if (ladingQuantity > 0)
			subject.LadingQuantity = ladingQuantity;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "mJ";
			subject.Quantity = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("mJ", 9, true)]
	[InlineData("mJ", 0, false)]
	[InlineData("", 9, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, decimal quantity, bool isValidExpected)
	{
		var subject = new LH1_HazardousIdentificationInformation();
		subject.UnitOrBasisForMeasurementCode = "ub";
		subject.LadingQuantity = 6;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		if (quantity > 0)
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

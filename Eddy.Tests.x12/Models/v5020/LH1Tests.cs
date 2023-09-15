using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5020;

namespace Eddy.x12.Tests.Models.v5020;

public class LH1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LH1*Ci*9*WZgtve*u*R*yJ*2*9*v*a*A*7";

		var expected = new LH1_HazardousIdentificationInformation()
		{
			UnitOrBasisForMeasurementCode = "Ci",
			LadingQuantity = 9,
			UNNAIdentificationCode = "WZgtve",
			HazardousMaterialsPage = "u",
			CommodityCode = "R",
			UnitOrBasisForMeasurementCode2 = "yJ",
			Quantity = 2,
			CompartmentIDCode = "9",
			ResidueIndicatorCode = "v",
			PackingGroupCode = "a",
			InterimHazardousMaterialRegulatoryNumber = "A",
			IndustryCode = "7",
		};

		var actual = Map.MapObject<LH1_HazardousIdentificationInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ci", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new LH1_HazardousIdentificationInformation();
		subject.LadingQuantity = 9;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredLadingQuantity(int ladingQuantity, bool isValidExpected)
	{
		var subject = new LH1_HazardousIdentificationInformation();
		subject.UnitOrBasisForMeasurementCode = "Ci";
		if (ladingQuantity > 0)
			subject.LadingQuantity = ladingQuantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

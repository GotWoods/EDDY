using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.Tests.Models.v4060;

public class LFHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LFH*cJz*I*T*S*OZ*3*2*Rj9f9UPn";

		var expected = new LFH_FreeFormHazardousMaterialInformation()
		{
			HazardousMaterialShipmentInformationQualifier = "cJz",
			HazardousMaterialShipmentInformation = "I",
			HazardousMaterialShipmentInformation2 = "T",
			HazardZoneCode = "S",
			UnitOrBasisForMeasurementCode = "OZ",
			Quantity = 3,
			Quantity2 = 2,
			Date = "Rj9f9UPn",
		};

		var actual = Map.MapObject<LFH_FreeFormHazardousMaterialInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("cJz", true)]
	public void Validation_RequiredHazardousMaterialShipmentInformationQualifier(string hazardousMaterialShipmentInformationQualifier, bool isValidExpected)
	{
		var subject = new LFH_FreeFormHazardousMaterialInformation();
		//Required fields
		subject.HazardousMaterialShipmentInformation = "I";
		//Test Parameters
		subject.HazardousMaterialShipmentInformationQualifier = hazardousMaterialShipmentInformationQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "OZ";
			subject.Quantity = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredHazardousMaterialShipmentInformation(string hazardousMaterialShipmentInformation, bool isValidExpected)
	{
		var subject = new LFH_FreeFormHazardousMaterialInformation();
		//Required fields
		subject.HazardousMaterialShipmentInformationQualifier = "cJz";
		//Test Parameters
		subject.HazardousMaterialShipmentInformation = hazardousMaterialShipmentInformation;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "OZ";
			subject.Quantity = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("OZ", 3, true)]
	[InlineData("OZ", 0, false)]
	[InlineData("", 3, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity, bool isValidExpected)
	{
		var subject = new LFH_FreeFormHazardousMaterialInformation();
		//Required fields
		subject.HazardousMaterialShipmentInformationQualifier = "cJz";
		subject.HazardousMaterialShipmentInformation = "I";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

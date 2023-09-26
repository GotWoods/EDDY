using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class LFHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LFH*sK9*M*y*F*lX*3*3";

		var expected = new LFH_FreeformHazardousMaterialInformation()
		{
			HazardousMaterialShipmentInformationQualifier = "sK9",
			HazardousMaterialShipmentInformation = "M",
			HazardousMaterialShipmentInformation2 = "y",
			HazardZoneCode = "F",
			UnitOrBasisForMeasurementCode = "lX",
			Quantity = 3,
			Quantity2 = 3,
		};

		var actual = Map.MapObject<LFH_FreeformHazardousMaterialInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("sK9", true)]
	public void Validation_RequiredHazardousMaterialShipmentInformationQualifier(string hazardousMaterialShipmentInformationQualifier, bool isValidExpected)
	{
		var subject = new LFH_FreeformHazardousMaterialInformation();
		//Required fields
		subject.HazardousMaterialShipmentInformation = "M";
		//Test Parameters
		subject.HazardousMaterialShipmentInformationQualifier = hazardousMaterialShipmentInformationQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "lX";
			subject.Quantity = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredHazardousMaterialShipmentInformation(string hazardousMaterialShipmentInformation, bool isValidExpected)
	{
		var subject = new LFH_FreeformHazardousMaterialInformation();
		//Required fields
		subject.HazardousMaterialShipmentInformationQualifier = "sK9";
		//Test Parameters
		subject.HazardousMaterialShipmentInformation = hazardousMaterialShipmentInformation;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "lX";
			subject.Quantity = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("lX", 3, true)]
	[InlineData("lX", 0, false)]
	[InlineData("", 3, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity, bool isValidExpected)
	{
		var subject = new LFH_FreeformHazardousMaterialInformation();
		//Required fields
		subject.HazardousMaterialShipmentInformationQualifier = "sK9";
		subject.HazardousMaterialShipmentInformation = "M";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

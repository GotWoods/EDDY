using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v6010.Composites;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class SV2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SV2*T**4*Dw*4*5*2*S*K*B";

		var expected = new SV2_InstitutionalService()
		{
			ProductServiceID = "T",
			CompositeMedicalProcedureIdentifier = null,
			MonetaryAmount = 4,
			UnitOrBasisForMeasurementCode = "Dw",
			Quantity = 4,
			UnitRate = 5,
			MonetaryAmount2 = 2,
			YesNoConditionOrResponseCode = "S",
			NursingHomeResidentialStatusCode = "K",
			LevelOfCareCode = "B",
		};

		var actual = Map.MapObject<SV2_InstitutionalService>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("T", "A", true)]
	[InlineData("T", "", true)]
	[InlineData("", "A", true)]
	public void Validation_AtLeastOneProductServiceID(string productServiceID, string compositeMedicalProcedureIdentifier, bool isValidExpected)
	{
		var subject = new SV2_InstitutionalService();
		//Required fields
		//Test Parameters
		subject.ProductServiceID = productServiceID;
		if (compositeMedicalProcedureIdentifier != "") 
			subject.CompositeMedicalProcedureIdentifier = new C003_CompositeMedicalProcedureIdentifier();
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "Dw";
			subject.Quantity = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Dw", 4, true)]
	[InlineData("Dw", 0, false)]
	[InlineData("", 4, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity, bool isValidExpected)
	{
		var subject = new SV2_InstitutionalService();
		//Required fields
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantity > 0) 
			subject.Quantity = quantity;
		//At Least one
		subject.ProductServiceID = "T";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

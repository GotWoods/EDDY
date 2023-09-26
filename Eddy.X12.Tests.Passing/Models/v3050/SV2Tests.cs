using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class SV2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SV2*n**8*Xa*4*3*5*c*I*P";

		var expected = new SV2_InstitutionalService()
		{
			ProductServiceID = "n",
			CompositeMedicalProcedureIdentifier = null,
			MonetaryAmount = 8,
			UnitOrBasisForMeasurementCode = "Xa",
			Quantity = 4,
			UnitRate = 3,
			MonetaryAmount2 = 5,
			YesNoConditionOrResponseCode = "c",
			NursingHomeResidentialStatusCode = "I",
			LevelOfCareCode = "P",
		};

		var actual = Map.MapObject<SV2_InstitutionalService>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("n", "A", true)]
	[InlineData("n", "", true)]
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
			subject.UnitOrBasisForMeasurementCode = "Xa";
			subject.Quantity = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Xa", 4, true)]
	[InlineData("Xa", 0, false)]
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
		subject.ProductServiceID = "n";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

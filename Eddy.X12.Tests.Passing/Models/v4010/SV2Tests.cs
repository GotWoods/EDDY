using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v4010.Composites;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class SV2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SV2*w**8*uu*5*4*7*K*l*9";

		var expected = new SV2_InstitutionalService()
		{
			ProductServiceID = "w",
			CompositeMedicalProcedureIdentifier = null,
			MonetaryAmount = 8,
			UnitOrBasisForMeasurementCode = "uu",
			Quantity = 5,
			UnitRate = 4,
			MonetaryAmount2 = 7,
			YesNoConditionOrResponseCode = "K",
			NursingHomeResidentialStatusCode = "l",
			LevelOfCareCode = "9",
		};

		var actual = Map.MapObject<SV2_InstitutionalService>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("w", "A", true)]
	[InlineData("w", "", true)]
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
			subject.UnitOrBasisForMeasurementCode = "uu";
			subject.Quantity = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("uu", 5, true)]
	[InlineData("uu", 0, false)]
	[InlineData("", 5, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity, bool isValidExpected)
	{
		var subject = new SV2_InstitutionalService();
		//Required fields
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantity > 0) 
			subject.Quantity = quantity;
		//At Least one
		subject.ProductServiceID = "w";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

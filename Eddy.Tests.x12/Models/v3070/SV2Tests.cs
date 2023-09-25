using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class SV2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SV2*1**6*X1*1*7*2*Y*D*W";

		var expected = new SV2_InstitutionalService()
		{
			ProductServiceID = "1",
			CompositeMedicalProcedureIdentifier = null,
			MonetaryAmount = 6,
			UnitOrBasisForMeasurementCode = "X1",
			Quantity = 1,
			UnitRate = 7,
			MonetaryAmount2 = 2,
			YesNoConditionOrResponseCode = "Y",
			NursingHomeResidentialStatusCode = "D",
			LevelOfCareCode = "W",
		};

		var actual = Map.MapObject<SV2_InstitutionalService>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("1", "A", true)]
	[InlineData("1", "", true)]
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
			subject.UnitOrBasisForMeasurementCode = "X1";
			subject.Quantity = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("X1", 1, true)]
	[InlineData("X1", 0, false)]
	[InlineData("", 1, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity, bool isValidExpected)
	{
		var subject = new SV2_InstitutionalService();
		//Required fields
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantity > 0) 
			subject.Quantity = quantity;
		//At Least one
		subject.ProductServiceID = "1";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

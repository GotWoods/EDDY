using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models;

public class SV2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SV2*G**1*hr*6*4*3*z*q*Y";

		var expected = new SV2_InstitutionalService()
		{
			ProductServiceID = "G",
			CompositeMedicalProcedureIdentifier = null,
			MonetaryAmount = 1,
			UnitOrBasisForMeasurementCode = "hr",
			Quantity = 6,
			UnitRate = 4,
			MonetaryAmount2 = 3,
			YesNoConditionOrResponseCode = "z",
			NursingHomeResidentialStatusCode = "q",
			LevelOfCareCode = "Y",
		};

		var actual = Map.MapObject<SV2_InstitutionalService>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("G","AA", true)]
	[InlineData("", "AA", true)]
	[InlineData("G", "", true)]
	public void Validation_AtLeastOneProductServiceID(string productServiceID, string compositeMedicalProcedureIdentifier, bool isValidExpected)
	{
		var subject = new SV2_InstitutionalService();
		subject.ProductServiceID = productServiceID;
        if (compositeMedicalProcedureIdentifier != "")
            subject.CompositeMedicalProcedureIdentifier = new C003_CompositeMedicalProcedureIdentifier();

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("hr", 6, true)]
	[InlineData("", 6, false)]
	[InlineData("hr", 0, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity, bool isValidExpected)
	{
		var subject = new SV2_InstitutionalService();
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantity > 0)
		subject.Quantity = quantity;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

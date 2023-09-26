using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class SV2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SV2*w*JB*P*3*du*6*AO*gC*zD*6*1*2*z*J*l";

		var expected = new SV2_InstitutionalService()
		{
			ProductServiceID = "w",
			ProductServiceIDQualifier = "JB",
			ProductServiceID2 = "P",
			MonetaryAmount = 3,
			UnitOrBasisForMeasurementCode = "du",
			Quantity = 6,
			ProcedureModifier = "AO",
			ProcedureModifier2 = "gC",
			ProcedureModifier3 = "zD",
			UnitRate = 6,
			Description = "1",
			MonetaryAmount2 = 2,
			YesNoConditionOrResponseCode = "z",
			NursingHomeResidentialStatusCode = "J",
			LevelOfCareCode = "l",
		};

		var actual = Map.MapObject<SV2_InstitutionalService>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("w", "P", true)]
	[InlineData("w", "", true)]
	[InlineData("", "P", true)]
	public void Validation_AtLeastOneProductServiceID(string productServiceID, string productServiceID2, bool isValidExpected)
	{
		var subject = new SV2_InstitutionalService();
		//Required fields
		//Test Parameters
		subject.ProductServiceID = productServiceID;
		subject.ProductServiceID2 = productServiceID2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier = "JB";
			subject.ProductServiceID2 = "P";
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "du";
			subject.Quantity = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("JB", "P", true)]
	[InlineData("JB", "", false)]
	[InlineData("", "P", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID2, bool isValidExpected)
	{
		var subject = new SV2_InstitutionalService();
		//Required fields
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID2 = productServiceID2;
		//At Least one
		subject.ProductServiceID = "w";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "du";
			subject.Quantity = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("du", 6, true)]
	[InlineData("du", 0, false)]
	[InlineData("", 6, false)]
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
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier = "JB";
			subject.ProductServiceID2 = "P";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

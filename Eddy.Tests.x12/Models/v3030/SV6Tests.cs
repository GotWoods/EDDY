using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class SV6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SV6*pZ*f*1*y*9*6*7*Jw*7*eR*i1*T";

		var expected = new SV6_AnesthesiaService()
		{
			ProductServiceIDQualifier = "pZ",
			ProductServiceID = "f",
			FacilityCodeQualifier = "1",
			FacilityCode = "y",
			MonetaryAmount = 9,
			DiagnosisCodePointer = 6,
			Quantity = 7,
			ProcedureModifier = "Jw",
			DiagnosisCodePointer2 = 7,
			ProcedureModifier2 = "eR",
			ProcedureModifier3 = "i1",
			YesNoConditionOrResponseCode = "T",
		};

		var actual = Map.MapObject<SV6_AnesthesiaService>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("pZ", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new SV6_AnesthesiaService();
		//Required fields
		subject.ProductServiceID = "f";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.FacilityCodeQualifier) || !string.IsNullOrEmpty(subject.FacilityCodeQualifier) || !string.IsNullOrEmpty(subject.FacilityCode))
		{
			subject.FacilityCodeQualifier = "1";
			subject.FacilityCode = "y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new SV6_AnesthesiaService();
		//Required fields
		subject.ProductServiceIDQualifier = "pZ";
		//Test Parameters
		subject.ProductServiceID = productServiceID;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.FacilityCodeQualifier) || !string.IsNullOrEmpty(subject.FacilityCodeQualifier) || !string.IsNullOrEmpty(subject.FacilityCode))
		{
			subject.FacilityCodeQualifier = "1";
			subject.FacilityCode = "y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("1", "y", true)]
	[InlineData("1", "", false)]
	[InlineData("", "y", false)]
	public void Validation_AllAreRequiredFacilityCodeQualifier(string facilityCodeQualifier, string facilityCode, bool isValidExpected)
	{
		var subject = new SV6_AnesthesiaService();
		//Required fields
		subject.ProductServiceIDQualifier = "pZ";
		subject.ProductServiceID = "f";
		//Test Parameters
		subject.FacilityCodeQualifier = facilityCodeQualifier;
		subject.FacilityCode = facilityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

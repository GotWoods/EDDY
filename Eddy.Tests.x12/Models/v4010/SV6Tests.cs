using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class SV6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SV6**T*4*8**7*v";

		var expected = new SV6_AnesthesiaService()
		{
			CompositeMedicalProcedureIdentifier = null,
			FacilityCodeQualifier = "T",
			FacilityCodeValue = "4",
			MonetaryAmount = 8,
			CompositeDiagnosisCodePointer = null,
			Quantity = 7,
			YesNoConditionOrResponseCode = "v",
		};

		var actual = Map.MapObject<SV6_AnesthesiaService>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredCompositeMedicalProcedureIdentifier(string compositeMedicalProcedureIdentifier, bool isValidExpected)
	{
		var subject = new SV6_AnesthesiaService();
		//Required fields
		//Test Parameters
		if (compositeMedicalProcedureIdentifier != "") 
			subject.CompositeMedicalProcedureIdentifier = new C003_CompositeMedicalProcedureIdentifier();
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.FacilityCodeQualifier) || !string.IsNullOrEmpty(subject.FacilityCodeQualifier) || !string.IsNullOrEmpty(subject.FacilityCodeValue))
		{
			subject.FacilityCodeQualifier = "T";
			subject.FacilityCodeValue = "4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("T", "4", true)]
	[InlineData("T", "", false)]
	[InlineData("", "4", false)]
	public void Validation_AllAreRequiredFacilityCodeQualifier(string facilityCodeQualifier, string facilityCodeValue, bool isValidExpected)
	{
		var subject = new SV6_AnesthesiaService();
		//Required fields
		subject.CompositeMedicalProcedureIdentifier = new C003_CompositeMedicalProcedureIdentifier();
		//Test Parameters
		subject.FacilityCodeQualifier = facilityCodeQualifier;
		subject.FacilityCodeValue = facilityCodeValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

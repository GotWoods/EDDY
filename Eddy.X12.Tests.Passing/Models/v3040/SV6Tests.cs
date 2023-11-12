using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3040.Composites;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class SV6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SV6**M*u*8**1*L";

		var expected = new SV6_AnesthesiaService()
		{
			CompositeMedicalProcedureIdentifier = null,
			FacilityCodeQualifier = "M",
			FacilityCodeValue = "u",
			MonetaryAmount = 8,
			CompositeDiagnosisCodePointer = null,
			Quantity = 1,
			YesNoConditionOrResponseCode = "L",
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
			subject.FacilityCodeQualifier = "M";
			subject.FacilityCodeValue = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("M", "u", true)]
	[InlineData("M", "", false)]
	[InlineData("", "u", false)]
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

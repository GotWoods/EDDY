using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models;

public class SV6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SV6**I*m*4*8*3*w";

		var expected = new SV6_AnesthesiaService()
		{
			CompositeMedicalProcedureIdentifier = null,
			FacilityCodeQualifier = "I",
			FacilityCodeValue = "m",
			MonetaryAmount = 4,
			DiagnosisCodePointer = 8,
			Quantity = 3,
			YesNoConditionOrResponseCode = "w",
		};

		var actual = Map.MapObject<SV6_AnesthesiaService>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("AB", true)]
	public void Validation_RequiredCompositeMedicalProcedureIdentifier(string compositeMedicalProcedureIdentifier, bool isValidExpected)
	{
		var subject = new SV6_AnesthesiaService();
		if (compositeMedicalProcedureIdentifier != "")
		    subject.CompositeMedicalProcedureIdentifier = new C003_CompositeMedicalProcedureIdentifier() {};
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("I", "m", true)]
	[InlineData("", "m", false)]
	[InlineData("I", "", false)]
	public void Validation_AllAreRequiredFacilityCodeQualifier(string facilityCodeQualifier, string facilityCodeValue, bool isValidExpected)
	{
		var subject = new SV6_AnesthesiaService();
		subject.CompositeMedicalProcedureIdentifier = new C003_CompositeMedicalProcedureIdentifier();
		subject.FacilityCodeQualifier = facilityCodeQualifier;
		subject.FacilityCodeValue = facilityCodeValue;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

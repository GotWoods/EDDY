using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class EMSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EMS*g*nI*2E4M*Yy*At*Z*I";

		var expected = new EMS_EmploymentPosition()
		{
			Description = "g",
			EmploymentClassCode = "nI",
			OccupationCode = "2E4M",
			EmploymentStatusCode = "Yy",
			ReferenceIdentificationQualifier = "At",
			ReferenceIdentification = "Z",
			ReferenceIdentification2 = "I",
		};

		var actual = Map.MapObject<EMS_EmploymentPosition>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("At", "Z", true)]
	[InlineData("At", "", false)]
	[InlineData("", "Z", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new EMS_EmploymentPosition();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

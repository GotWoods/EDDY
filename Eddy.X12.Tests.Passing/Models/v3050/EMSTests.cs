using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class EMSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EMS*r*Zw*D8sY*1l*WJ*Z*b";

		var expected = new EMS_EmploymentPosition()
		{
			Description = "r",
			EmploymentClassCode = "Zw",
			OccupationCode = "D8sY",
			EmploymentStatusCode = "1l",
			ReferenceNumberQualifier = "WJ",
			ReferenceNumber = "Z",
			ReferenceNumber2 = "b",
		};

		var actual = Map.MapObject<EMS_EmploymentPosition>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredDescription(string description, bool isValidExpected)
	{
		var subject = new EMS_EmploymentPosition();
		//Required fields
		//Test Parameters
		subject.Description = description;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "WJ";
			subject.ReferenceNumber = "Z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("WJ", "Z", true)]
	[InlineData("WJ", "", false)]
	[InlineData("", "Z", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new EMS_EmploymentPosition();
		//Required fields
		subject.Description = "r";
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

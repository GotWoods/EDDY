using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class EMSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EMS*2*03*fA4x*ri*9p*a";

		var expected = new EMS_EmploymentPosition()
		{
			Description = "2",
			EmploymentClassCode = "03",
			OccupationCode = "fA4x",
			EmploymentStatusCode = "ri",
			ReferenceNumberQualifier = "9p",
			ReferenceNumber = "a",
		};

		var actual = Map.MapObject<EMS_EmploymentPosition>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredDescription(string description, bool isValidExpected)
	{
		var subject = new EMS_EmploymentPosition();
		//Required fields
		subject.EmploymentClassCode = "03";
		//Test Parameters
		subject.Description = description;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "9p";
			subject.ReferenceNumber = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("03", true)]
	public void Validation_RequiredEmploymentClassCode(string employmentClassCode, bool isValidExpected)
	{
		var subject = new EMS_EmploymentPosition();
		//Required fields
		subject.Description = "2";
		//Test Parameters
		subject.EmploymentClassCode = employmentClassCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "9p";
			subject.ReferenceNumber = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("9p", "a", true)]
	[InlineData("9p", "", false)]
	[InlineData("", "a", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new EMS_EmploymentPosition();
		//Required fields
		subject.Description = "2";
		subject.EmploymentClassCode = "03";
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

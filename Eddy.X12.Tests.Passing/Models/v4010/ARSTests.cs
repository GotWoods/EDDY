using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class ARSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ARS*I*1*eO*7*m";

		var expected = new ARS_ApplicantResidenceSpecifics()
		{
			TypeOfResidenceCode = "I",
			PropertyOwnershipRightsCode = "1",
			RateValueQualifier = "eO",
			MonetaryAmount = 7,
			ReferenceIdentification = "m",
		};

		var actual = Map.MapObject<ARS_ApplicantResidenceSpecifics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredTypeOfResidenceCode(string typeOfResidenceCode, bool isValidExpected)
	{
		var subject = new ARS_ApplicantResidenceSpecifics();
		//Required fields
		subject.PropertyOwnershipRightsCode = "1";
		//Test Parameters
		subject.TypeOfResidenceCode = typeOfResidenceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredPropertyOwnershipRightsCode(string propertyOwnershipRightsCode, bool isValidExpected)
	{
		var subject = new ARS_ApplicantResidenceSpecifics();
		//Required fields
		subject.TypeOfResidenceCode = "I";
		//Test Parameters
		subject.PropertyOwnershipRightsCode = propertyOwnershipRightsCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

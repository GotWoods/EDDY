using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class ARSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ARS*q*m*Lo*5";

		var expected = new ARS_ApplicantResidenceSpecifics()
		{
			TypeOfResidenceCode = "q",
			PropertyOwnershipRightsCode = "m",
			RateValueQualifier = "Lo",
			MonetaryAmount = 5,
		};

		var actual = Map.MapObject<ARS_ApplicantResidenceSpecifics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredTypeOfResidenceCode(string typeOfResidenceCode, bool isValidExpected)
	{
		var subject = new ARS_ApplicantResidenceSpecifics();
		//Required fields
		subject.PropertyOwnershipRightsCode = "m";
		//Test Parameters
		subject.TypeOfResidenceCode = typeOfResidenceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredPropertyOwnershipRightsCode(string propertyOwnershipRightsCode, bool isValidExpected)
	{
		var subject = new ARS_ApplicantResidenceSpecifics();
		//Required fields
		subject.TypeOfResidenceCode = "q";
		//Test Parameters
		subject.PropertyOwnershipRightsCode = propertyOwnershipRightsCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

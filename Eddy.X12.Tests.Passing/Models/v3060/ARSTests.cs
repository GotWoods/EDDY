using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class ARSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ARS*H*H*Nj*1*z";

		var expected = new ARS_ApplicantResidenceSpecifics()
		{
			TypeOfResidenceCode = "H",
			PropertyOwnershipRightsCode = "H",
			RateValueQualifier = "Nj",
			MonetaryAmount = 1,
			ReferenceIdentification = "z",
		};

		var actual = Map.MapObject<ARS_ApplicantResidenceSpecifics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredTypeOfResidenceCode(string typeOfResidenceCode, bool isValidExpected)
	{
		var subject = new ARS_ApplicantResidenceSpecifics();
		//Required fields
		subject.PropertyOwnershipRightsCode = "H";
		//Test Parameters
		subject.TypeOfResidenceCode = typeOfResidenceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredPropertyOwnershipRightsCode(string propertyOwnershipRightsCode, bool isValidExpected)
	{
		var subject = new ARS_ApplicantResidenceSpecifics();
		//Required fields
		subject.TypeOfResidenceCode = "H";
		//Test Parameters
		subject.PropertyOwnershipRightsCode = propertyOwnershipRightsCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

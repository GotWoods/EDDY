using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class ARSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ARS*m*8*Bq*7*L";

		var expected = new ARS_ApplicantResidenceSpecifics()
		{
			TypeOfResidenceCode = "m",
			PropertyOwnershipRightsCode = "8",
			RateValueQualifier = "Bq",
			MonetaryAmount = 7,
			ReferenceIdentification = "L",
		};

		var actual = Map.MapObject<ARS_ApplicantResidenceSpecifics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredTypeOfResidenceCode(string typeOfResidenceCode, bool isValidExpected)
	{
		var subject = new ARS_ApplicantResidenceSpecifics();
		//Required fields
		subject.PropertyOwnershipRightsCode = "8";
		//Test Parameters
		subject.TypeOfResidenceCode = typeOfResidenceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredPropertyOwnershipRightsCode(string propertyOwnershipRightsCode, bool isValidExpected)
	{
		var subject = new ARS_ApplicantResidenceSpecifics();
		//Required fields
		subject.TypeOfResidenceCode = "m";
		//Test Parameters
		subject.PropertyOwnershipRightsCode = propertyOwnershipRightsCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

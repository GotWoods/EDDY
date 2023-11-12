using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class ARSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ARS*T*Y*d9*3*F";

		var expected = new ARS_ApplicantResidenceSpecifics()
		{
			TypeOfResidenceCode = "T",
			PropertyOwnershipRightsCode = "Y",
			RateValueQualifier = "d9",
			MonetaryAmount = 3,
			ReferenceNumber = "F",
		};

		var actual = Map.MapObject<ARS_ApplicantResidenceSpecifics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredTypeOfResidenceCode(string typeOfResidenceCode, bool isValidExpected)
	{
		var subject = new ARS_ApplicantResidenceSpecifics();
		//Required fields
		subject.PropertyOwnershipRightsCode = "Y";
		//Test Parameters
		subject.TypeOfResidenceCode = typeOfResidenceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredPropertyOwnershipRightsCode(string propertyOwnershipRightsCode, bool isValidExpected)
	{
		var subject = new ARS_ApplicantResidenceSpecifics();
		//Required fields
		subject.TypeOfResidenceCode = "T";
		//Test Parameters
		subject.PropertyOwnershipRightsCode = propertyOwnershipRightsCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

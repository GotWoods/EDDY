using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class VEHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VEH*4*E*4939*dk*y*D*1*3*D*B4*U*O*j*S*O*V";

		var expected = new VEH_VehicleInformation()
		{
			AssignedNumber = 4,
			VehicleIdentificationNumber = "E",
			Year = 4939,
			AgencyQualifierCode = "dk",
			ReferenceIdentification = "y",
			ReferenceIdentification2 = "D",
			ReferenceIdentification3 = "1",
			Length = 3,
			ReferenceIdentification4 = "D",
			StateOrProvinceCode = "B4",
			LocationIdentifier = "U",
			YesNoConditionOrResponseCode = "O",
			Amount = "j",
			YesNoConditionOrResponseCode2 = "S",
			Amount2 = "O",
			ActionCode = "V",
		};

		var actual = Map.MapObject<VEH_VehicleInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("dk", "y", "1", true)]
	[InlineData("dk", "", "", false)]
	[InlineData("", "y", "1", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_AgencyQualifierCode(string agencyQualifierCode, string referenceIdentification, string referenceIdentification3, bool isValidExpected)
	{
		var subject = new VEH_VehicleInformation();
		//Required fields
		//Test Parameters
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.ReferenceIdentification = referenceIdentification;
		subject.ReferenceIdentification3 = referenceIdentification3;
		//A Requires B
		if (referenceIdentification != "")
			subject.AgencyQualifierCode = "dk";
		if (referenceIdentification3 != "")
			subject.AgencyQualifierCode = "dk";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("y", "dk", true)]
	[InlineData("y", "", false)]
	[InlineData("", "dk", true)]
	public void Validation_ARequiresBReferenceIdentification(string referenceIdentification, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new VEH_VehicleInformation();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		subject.AgencyQualifierCode = agencyQualifierCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentification3 = "1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("1", "dk", true)]
	[InlineData("1", "", false)]
	[InlineData("", "dk", true)]
	public void Validation_ARequiresBReferenceIdentification3(string referenceIdentification3, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new VEH_VehicleInformation();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentification3 = referenceIdentification3;
		subject.AgencyQualifierCode = agencyQualifierCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentification = "y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

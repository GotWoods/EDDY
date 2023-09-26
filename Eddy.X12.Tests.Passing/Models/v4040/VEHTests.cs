using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class VEHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VEH*6*T*9539*nE*x*I*G*7*j*cI*w*h*W*v*H*R";

		var expected = new VEH_VehicleInformation()
		{
			AssignedNumber = 6,
			VehicleIdentificationNumber = "T",
			Year = 9539,
			AgencyQualifierCode = "nE",
			ReferenceIdentification = "x",
			ReferenceIdentification2 = "I",
			ReferenceIdentification3 = "G",
			Length = 7,
			ReferenceIdentification4 = "j",
			StateOrProvinceCode = "cI",
			LocationIdentifier = "w",
			YesNoConditionOrResponseCode = "h",
			Amount = "W",
			YesNoConditionOrResponseCode2 = "v",
			Amount2 = "H",
			ActionCode = "R",
		};

		var actual = Map.MapObject<VEH_VehicleInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("nE", "x", "G", true)]
	[InlineData("nE", "", "", false)]
	[InlineData("", "x", "G", true)]
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
			subject.AgencyQualifierCode = "nE";
		if (referenceIdentification3 != "")
			subject.AgencyQualifierCode = "nE";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("x", "nE", true)]
	[InlineData("x", "", false)]
	[InlineData("", "nE", true)]
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
			subject.ReferenceIdentification3 = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("G", "nE", true)]
	[InlineData("G", "", false)]
	[InlineData("", "nE", true)]
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
			subject.ReferenceIdentification = "x";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

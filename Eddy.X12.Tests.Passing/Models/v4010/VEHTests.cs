using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class VEHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VEH*1*9*5919*e6*q*s*j*6*S*2J*3*x*p*J*8*9";

		var expected = new VEH_VehicleInformation()
		{
			AssignedNumber = 1,
			VehicleIdentificationNumber = "9",
			Year = 5919,
			AgencyQualifierCode = "e6",
			ProductDescriptionCode = "q",
			ProductDescriptionCode2 = "s",
			ProductDescriptionCode3 = "j",
			Length = 6,
			ReferenceIdentification = "S",
			StateOrProvinceCode = "2J",
			LocationIdentifier = "3",
			YesNoConditionOrResponseCode = "x",
			Amount = "p",
			YesNoConditionOrResponseCode2 = "J",
			Amount2 = "8",
			ActionCode = "9",
		};

		var actual = Map.MapObject<VEH_VehicleInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("e6", "q", "j", true)]
	[InlineData("e6", "", "", false)]
	[InlineData("", "q", "j", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_AgencyQualifierCode(string agencyQualifierCode, string productDescriptionCode, string productDescriptionCode3, bool isValidExpected)
	{
		var subject = new VEH_VehicleInformation();
		//Required fields
		//Test Parameters
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.ProductDescriptionCode = productDescriptionCode;
		subject.ProductDescriptionCode3 = productDescriptionCode3;
		//A Requires B
		if (productDescriptionCode != "")
			subject.AgencyQualifierCode = "e6";
		if (productDescriptionCode3 != "")
			subject.AgencyQualifierCode = "e6";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("q", "e6", true)]
	[InlineData("q", "", false)]
	[InlineData("", "e6", true)]
	public void Validation_ARequiresBProductDescriptionCode(string productDescriptionCode, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new VEH_VehicleInformation();
		//Required fields
		//Test Parameters
		subject.ProductDescriptionCode = productDescriptionCode;
		subject.AgencyQualifierCode = agencyQualifierCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.ProductDescriptionCode3))
		{
			subject.ProductDescriptionCode3 = "j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("j", "e6", true)]
	[InlineData("j", "", false)]
	[InlineData("", "e6", true)]
	public void Validation_ARequiresBProductDescriptionCode3(string productDescriptionCode3, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new VEH_VehicleInformation();
		//Required fields
		//Test Parameters
		subject.ProductDescriptionCode3 = productDescriptionCode3;
		subject.AgencyQualifierCode = agencyQualifierCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.ProductDescriptionCode))
		{
			subject.ProductDescriptionCode = "q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

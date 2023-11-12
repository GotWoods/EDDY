using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class VEHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VEH*7*U*51*93*hg*1*Y*l*3*9*6B*P*3*E*I*h";

		var expected = new VEH_VehicleInformation()
		{
			AssignedNumber = 7,
			VehicleIdentificationNumber = "U",
			Century = 51,
			YearWithinCentury = 93,
			AgencyQualifierCode = "hg",
			ProductDescriptionCode = "1",
			ProductDescriptionCode2 = "Y",
			ProductDescriptionCode3 = "l",
			Length = 3,
			ReferenceNumber = "9",
			StateOrProvinceCode = "6B",
			LocationIdentifier = "P",
			YesNoConditionOrResponseCode = "3",
			Amount = "E",
			YesNoConditionOrResponseCode2 = "I",
			Amount2 = "h",
		};

		var actual = Map.MapObject<VEH_VehicleInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(51, 93, true)]
	[InlineData(51, 0, false)]
	[InlineData(0, 93, true)]
	public void Validation_ARequiresBCentury(int century, int yearWithinCentury, bool isValidExpected)
	{
		var subject = new VEH_VehicleInformation();
		//Required fields
		//Test Parameters
		if (century > 0) 
			subject.Century = century;
		if (yearWithinCentury > 0) 
			subject.YearWithinCentury = yearWithinCentury;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.ProductDescriptionCode) || !string.IsNullOrEmpty(subject.ProductDescriptionCode3))
		{
			subject.AgencyQualifierCode = "hg";
			subject.ProductDescriptionCode = "1";
			subject.ProductDescriptionCode3 = "l";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("hg", "1", "l", true)]
	[InlineData("hg", "", "", false)]
	[InlineData("", "1", "l", true)]
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
			subject.AgencyQualifierCode = "hg";
		if (productDescriptionCode3 != "")
			subject.AgencyQualifierCode = "hg";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("1", "hg", true)]
	[InlineData("1", "", false)]
	[InlineData("", "hg", true)]
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
			subject.ProductDescriptionCode3 = "l";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("l", "hg", true)]
	[InlineData("l", "", false)]
	[InlineData("", "hg", true)]
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
			subject.ProductDescriptionCode = "1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

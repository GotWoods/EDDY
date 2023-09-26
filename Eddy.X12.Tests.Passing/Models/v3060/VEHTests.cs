using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class VEHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VEH*7*L*24*38*FP*m*y*y*7*4*ll*H*H*Y*q*d";

		var expected = new VEH_VehicleInformation()
		{
			AssignedNumber = 7,
			VehicleIdentificationNumber = "L",
			Century = 24,
			YearWithinCentury = 38,
			AgencyQualifierCode = "FP",
			ProductDescriptionCode = "m",
			ProductDescriptionCode2 = "y",
			ProductDescriptionCode3 = "y",
			Length = 7,
			ReferenceIdentification = "4",
			StateOrProvinceCode = "ll",
			LocationIdentifier = "H",
			YesNoConditionOrResponseCode = "H",
			Amount = "Y",
			YesNoConditionOrResponseCode2 = "q",
			Amount2 = "d",
		};

		var actual = Map.MapObject<VEH_VehicleInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(24, 38, true)]
	[InlineData(24, 0, false)]
	[InlineData(0, 38, true)]
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
			subject.AgencyQualifierCode = "FP";
			subject.ProductDescriptionCode = "m";
			subject.ProductDescriptionCode3 = "y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("FP", "m", "y", true)]
	[InlineData("FP", "", "", false)]
	[InlineData("", "m", "y", true)]
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
			subject.AgencyQualifierCode = "FP";
		if (productDescriptionCode3 != "")
			subject.AgencyQualifierCode = "FP";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("m", "FP", true)]
	[InlineData("m", "", false)]
	[InlineData("", "FP", true)]
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
			subject.ProductDescriptionCode3 = "y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("y", "FP", true)]
	[InlineData("y", "", false)]
	[InlineData("", "FP", true)]
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
			subject.ProductDescriptionCode = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

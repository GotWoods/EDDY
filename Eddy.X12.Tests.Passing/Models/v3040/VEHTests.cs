using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class VEHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VEH*3*K*88*49*F3*h*i*K*1*w*gx*8*e*V*r*C";

		var expected = new VEH_VehicleInformation()
		{
			AssignedNumber = 3,
			VehicleIdentificationNumber = "K",
			Century = 88,
			YearWithinCentury = 49,
			AgencyQualifierCode = "F3",
			ProductDescriptionCode = "h",
			ProductDescriptionCode2 = "i",
			ProductDescriptionCode3 = "K",
			Length = 1,
			ReferenceNumber = "w",
			StateOrProvinceCode = "gx",
			LocationIdentifier = "8",
			YesNoConditionOrResponseCode = "e",
			Amount = "V",
			YesNoConditionOrResponseCode2 = "r",
			Amount2 = "C",
		};

		var actual = Map.MapObject<VEH_VehicleInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(88, 49, true)]
	[InlineData(88, 0, false)]
	[InlineData(0, 49, true)]
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
			subject.AgencyQualifierCode = "F3";
			subject.ProductDescriptionCode = "h";
			subject.ProductDescriptionCode3 = "K";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("F3", "h", "K", true)]
	[InlineData("F3", "", "", false)]
	[InlineData("", "h", "K", true)]
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
			subject.AgencyQualifierCode = "F3";
		if (productDescriptionCode3 != "")
			subject.AgencyQualifierCode = "F3";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("h", "F3", true)]
	[InlineData("h", "", false)]
	[InlineData("", "F3", true)]
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
			subject.ProductDescriptionCode3 = "K";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("K", "F3", true)]
	[InlineData("K", "", false)]
	[InlineData("", "F3", true)]
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
			subject.ProductDescriptionCode = "h";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

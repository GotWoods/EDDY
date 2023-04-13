using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class VEHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VEH*4*L*9881*hj*2*y*B*8*A*WR*P*L*g*T*S*Z*X4*a*p3*on*D*YO*t*Y*J*u";

		var expected = new VEH_VehicleInformation()
		{
			AssignedNumber = 4,
			VehicleIdentificationNumber = "L",
			Year = 9881,
			AgencyQualifierCode = "hj",
			ReferenceIdentification = "2",
			ReferenceIdentification2 = "y",
			ReferenceIdentification3 = "B",
			Length = 8,
			ReferenceIdentification4 = "A",
			StateOrProvinceCode = "WR",
			LocationIdentifier = "P",
			YesNoConditionOrResponseCode = "L",
			Amount = "g",
			YesNoConditionOrResponseCode2 = "T",
			Amount2 = "S",
			ActionCode = "Z",
			CountryCode = "X4",
			Name = "a",
			CountryCode2 = "p3",
			EquipmentDescriptionCode = "on",
			ReferenceIdentification5 = "D",
			ReferenceIdentificationQualifier = "YO",
			LoadEmptyStatusCode = "t",
			ReferenceIdentification6 = "Y",
			ReferenceIdentification7 = "J",
			CountrySubdivisionCode = "u",
		};

		var actual = Map.MapObject<VEH_VehicleInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("hj", "2", "", true)]
	[InlineData("", "2", "", true)]
	[InlineData("hj", "", "", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_AgencyQualifierCode(string agencyQualifierCode, string referenceIdentification, string referenceIdentification3, bool isValidExpected)
	{
		var subject = new VEH_VehicleInformation();
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.ReferenceIdentification = referenceIdentification;
		subject.ReferenceIdentification3 = referenceIdentification3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "hj", true)]
	[InlineData("2", "", false)]
	public void Validation_ARequiresBReferenceIdentification(string referenceIdentification, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new VEH_VehicleInformation();
		subject.ReferenceIdentification = referenceIdentification;
		subject.AgencyQualifierCode = agencyQualifierCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "hj", true)]
	[InlineData("B", "", false)]
	public void Validation_ARequiresBReferenceIdentification3(string referenceIdentification3, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new VEH_VehicleInformation();
		subject.ReferenceIdentification3 = referenceIdentification3;
		subject.AgencyQualifierCode = agencyQualifierCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "X4", true)]
	[InlineData("WR", "", false)]
	public void Validation_ARequiresBStateOrProvinceCode(string stateOrProvinceCode, string countryCode, bool isValidExpected)
	{
		var subject = new VEH_VehicleInformation();
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CountryCode = countryCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("WR", "u", false)]
	[InlineData("", "u", true)]
	[InlineData("WR", "", true)]
	public void Validation_OnlyOneOfStateOrProvinceCode(string stateOrProvinceCode, string countrySubdivisionCode, bool isValidExpected)
	{
		var subject = new VEH_VehicleInformation();
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CountrySubdivisionCode = countrySubdivisionCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("a", "p3", true)]
	[InlineData("", "p3", false)]
	[InlineData("a", "", false)]
	public void Validation_AllAreRequiredName(string name, string countryCode2, bool isValidExpected)
	{
		var subject = new VEH_VehicleInformation();
		subject.Name = name;
		subject.CountryCode2 = countryCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", "",true)]
	[InlineData("on", "L", "", true)]
	[InlineData("", "L", "", true)]
	[InlineData("on", "", "", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_EquipmentDescriptionCode(string equipmentDescriptionCode, string vehicleIdentificationNumber, string referenceIdentification5, bool isValidExpected)
	{
		var subject = new VEH_VehicleInformation();
		subject.EquipmentDescriptionCode = equipmentDescriptionCode;
		subject.VehicleIdentificationNumber = vehicleIdentificationNumber;
		subject.ReferenceIdentification5 = referenceIdentification5;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("D", "YO", true)]
	[InlineData("", "YO", false)]
	[InlineData("D", "", false)]
	public void Validation_AllAreRequiredReferenceIdentification5(string referenceIdentification5, string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new VEH_VehicleInformation();
		subject.ReferenceIdentification5 = referenceIdentification5;
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "X4", true)]
	[InlineData("u", "", false)]
	public void Validation_ARequiresBCountrySubdivisionCode(string countrySubdivisionCode, string countryCode, bool isValidExpected)
	{
		var subject = new VEH_VehicleInformation();
		subject.CountrySubdivisionCode = countrySubdivisionCode;
		subject.CountryCode = countryCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

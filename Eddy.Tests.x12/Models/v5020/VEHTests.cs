using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5020;

namespace Eddy.x12.Tests.Models.v5020;

public class VEHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VEH*6*Z*3483*cf*m*w*q*1*E*NG*0*y*Q*H*O*7*kf*s*Fh*A3*K";

		var expected = new VEH_VehicleInformation()
		{
			AssignedNumber = 6,
			VehicleIdentificationNumber = "Z",
			Year = 3483,
			AgencyQualifierCode = "cf",
			ReferenceIdentification = "m",
			ReferenceIdentification2 = "w",
			ReferenceIdentification3 = "q",
			Length = 1,
			ReferenceIdentification4 = "E",
			StateOrProvinceCode = "NG",
			LocationIdentifier = "0",
			YesNoConditionOrResponseCode = "y",
			Amount = "Q",
			YesNoConditionOrResponseCode2 = "H",
			Amount2 = "O",
			ActionCode = "7",
			CountryCode = "kf",
			Name = "s",
			CountryCode2 = "Fh",
			EquipmentDescriptionCode = "A3",
			ReferenceIdentification5 = "K",
		};

		var actual = Map.MapObject<VEH_VehicleInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("cf", "m", "q", true)]
	[InlineData("cf", "", "", false)]
	[InlineData("", "m", "q", true)]
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
			subject.AgencyQualifierCode = "cf";
		if (referenceIdentification3 != "")
			subject.AgencyQualifierCode = "cf";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Name) || !string.IsNullOrEmpty(subject.Name) || !string.IsNullOrEmpty(subject.CountryCode2))
		{
			subject.Name = "s";
			subject.CountryCode2 = "Fh";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.EquipmentDescriptionCode) || !string.IsNullOrEmpty(subject.EquipmentDescriptionCode) || !string.IsNullOrEmpty(subject.VehicleIdentificationNumber) || !string.IsNullOrEmpty(subject.ReferenceIdentification5))
		{
			subject.EquipmentDescriptionCode = "A3";
			subject.VehicleIdentificationNumber = "Z";
			subject.ReferenceIdentification5 = "K";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("m", "cf", true)]
	[InlineData("m", "", false)]
	[InlineData("", "cf", true)]
	public void Validation_ARequiresBReferenceIdentification(string referenceIdentification, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new VEH_VehicleInformation();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		subject.AgencyQualifierCode = agencyQualifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Name) || !string.IsNullOrEmpty(subject.Name) || !string.IsNullOrEmpty(subject.CountryCode2))
		{
			subject.Name = "s";
			subject.CountryCode2 = "Fh";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentification3 = "q";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentDescriptionCode) || !string.IsNullOrEmpty(subject.EquipmentDescriptionCode) || !string.IsNullOrEmpty(subject.VehicleIdentificationNumber) || !string.IsNullOrEmpty(subject.ReferenceIdentification5))
		{
			subject.EquipmentDescriptionCode = "A3";
			subject.VehicleIdentificationNumber = "Z";
			subject.ReferenceIdentification5 = "K";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("q", "cf", true)]
	[InlineData("q", "", false)]
	[InlineData("", "cf", true)]
	public void Validation_ARequiresBReferenceIdentification3(string referenceIdentification3, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new VEH_VehicleInformation();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentification3 = referenceIdentification3;
		subject.AgencyQualifierCode = agencyQualifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Name) || !string.IsNullOrEmpty(subject.Name) || !string.IsNullOrEmpty(subject.CountryCode2))
		{
			subject.Name = "s";
			subject.CountryCode2 = "Fh";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentification = "m";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentDescriptionCode) || !string.IsNullOrEmpty(subject.EquipmentDescriptionCode) || !string.IsNullOrEmpty(subject.VehicleIdentificationNumber) || !string.IsNullOrEmpty(subject.ReferenceIdentification5))
		{
			subject.EquipmentDescriptionCode = "A3";
			subject.VehicleIdentificationNumber = "Z";
			subject.ReferenceIdentification5 = "K";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("s", "Fh", true)]
	[InlineData("s", "", false)]
	[InlineData("", "Fh", false)]
	public void Validation_AllAreRequiredName(string name, string countryCode2, bool isValidExpected)
	{
		var subject = new VEH_VehicleInformation();
		//Required fields
		//Test Parameters
		subject.Name = name;
		subject.CountryCode2 = countryCode2;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.AgencyQualifierCode = "cf";
			subject.ReferenceIdentification = "m";
			subject.ReferenceIdentification3 = "q";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentDescriptionCode) || !string.IsNullOrEmpty(subject.EquipmentDescriptionCode) || !string.IsNullOrEmpty(subject.VehicleIdentificationNumber) || !string.IsNullOrEmpty(subject.ReferenceIdentification5))
		{
			subject.EquipmentDescriptionCode = "A3";
			subject.VehicleIdentificationNumber = "Z";
			subject.ReferenceIdentification5 = "K";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("A3", "Z", "K", true)]
	[InlineData("A3", "", "", false)]
	[InlineData("", "Z", "K", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_EquipmentDescriptionCode(string equipmentDescriptionCode, string vehicleIdentificationNumber, string referenceIdentification5, bool isValidExpected)
	{
		var subject = new VEH_VehicleInformation();
		//Required fields
		//Test Parameters
		subject.EquipmentDescriptionCode = equipmentDescriptionCode;
		subject.VehicleIdentificationNumber = vehicleIdentificationNumber;
		subject.ReferenceIdentification5 = referenceIdentification5;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Name) || !string.IsNullOrEmpty(subject.Name) || !string.IsNullOrEmpty(subject.CountryCode2))
		{
			subject.Name = "s";
			subject.CountryCode2 = "Fh";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.AgencyQualifierCode = "cf";
			subject.ReferenceIdentification = "m";
			subject.ReferenceIdentification3 = "q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}

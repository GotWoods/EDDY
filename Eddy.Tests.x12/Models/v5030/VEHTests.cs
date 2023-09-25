using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class VEHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VEH*1*h*2194*Ra*d*3*a*7*W*bN*p*c*3*G*K*M*Gz*B*Pw*RB*P*25*F*k*y*P";

		var expected = new VEH_VehicleInformation()
		{
			AssignedNumber = 1,
			VehicleIdentificationNumber = "h",
			Year = 2194,
			AgencyQualifierCode = "Ra",
			ReferenceIdentification = "d",
			ReferenceIdentification2 = "3",
			ReferenceIdentification3 = "a",
			Length = 7,
			ReferenceIdentification4 = "W",
			StateOrProvinceCode = "bN",
			LocationIdentifier = "p",
			YesNoConditionOrResponseCode = "c",
			Amount = "3",
			YesNoConditionOrResponseCode2 = "G",
			Amount2 = "K",
			ActionCode = "M",
			CountryCode = "Gz",
			Name = "B",
			CountryCode2 = "Pw",
			EquipmentDescriptionCode = "RB",
			ReferenceIdentification5 = "P",
			ReferenceIdentificationQualifier = "25",
			LoadEmptyStatusCode = "F",
			ReferenceIdentification6 = "k",
			ReferenceIdentification7 = "y",
			CountrySubdivisionCode = "P",
		};

		var actual = Map.MapObject<VEH_VehicleInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("Ra", "d", "a", true)]
	[InlineData("Ra", "", "", false)]
	[InlineData("", "d", "a", true)]
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
			subject.AgencyQualifierCode = "Ra";
		if (referenceIdentification3 != "")
			subject.AgencyQualifierCode = "Ra";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Name) || !string.IsNullOrEmpty(subject.Name) || !string.IsNullOrEmpty(subject.CountryCode2))
		{
			subject.Name = "B";
			subject.CountryCode2 = "Pw";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification5) || !string.IsNullOrEmpty(subject.ReferenceIdentification5) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier))
		{
			subject.ReferenceIdentification5 = "P";
			subject.ReferenceIdentificationQualifier = "25";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.EquipmentDescriptionCode) || !string.IsNullOrEmpty(subject.EquipmentDescriptionCode) || !string.IsNullOrEmpty(subject.VehicleIdentificationNumber) || !string.IsNullOrEmpty(subject.ReferenceIdentification5))
		{
			subject.EquipmentDescriptionCode = "RB";
			subject.VehicleIdentificationNumber = "h";
			subject.ReferenceIdentification5 = "P";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("d", "Ra", true)]
	[InlineData("d", "", false)]
	[InlineData("", "Ra", true)]
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
			subject.Name = "B";
			subject.CountryCode2 = "Pw";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification5) || !string.IsNullOrEmpty(subject.ReferenceIdentification5) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier))
		{
			subject.ReferenceIdentification5 = "P";
			subject.ReferenceIdentificationQualifier = "25";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentification3 = "a";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentDescriptionCode) || !string.IsNullOrEmpty(subject.EquipmentDescriptionCode) || !string.IsNullOrEmpty(subject.VehicleIdentificationNumber) || !string.IsNullOrEmpty(subject.ReferenceIdentification5))
		{
			subject.EquipmentDescriptionCode = "RB";
			subject.VehicleIdentificationNumber = "h";
			subject.ReferenceIdentification5 = "P";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("a", "Ra", true)]
	[InlineData("a", "", false)]
	[InlineData("", "Ra", true)]
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
			subject.Name = "B";
			subject.CountryCode2 = "Pw";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification5) || !string.IsNullOrEmpty(subject.ReferenceIdentification5) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier))
		{
			subject.ReferenceIdentification5 = "P";
			subject.ReferenceIdentificationQualifier = "25";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentification = "d";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentDescriptionCode) || !string.IsNullOrEmpty(subject.EquipmentDescriptionCode) || !string.IsNullOrEmpty(subject.VehicleIdentificationNumber) || !string.IsNullOrEmpty(subject.ReferenceIdentification5))
		{
			subject.EquipmentDescriptionCode = "RB";
			subject.VehicleIdentificationNumber = "h";
			subject.ReferenceIdentification5 = "P";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("bN", "Gz", true)]
	[InlineData("bN", "", false)]
	[InlineData("", "Gz", true)]
	public void Validation_ARequiresBStateOrProvinceCode(string stateOrProvinceCode, string countryCode, bool isValidExpected)
	{
		var subject = new VEH_VehicleInformation();
		//Required fields
		//Test Parameters
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CountryCode = countryCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Name) || !string.IsNullOrEmpty(subject.Name) || !string.IsNullOrEmpty(subject.CountryCode2))
		{
			subject.Name = "B";
			subject.CountryCode2 = "Pw";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification5) || !string.IsNullOrEmpty(subject.ReferenceIdentification5) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier))
		{
			subject.ReferenceIdentification5 = "P";
			subject.ReferenceIdentificationQualifier = "25";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.AgencyQualifierCode = "Ra";
			subject.ReferenceIdentification = "d";
			subject.ReferenceIdentification3 = "a";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentDescriptionCode) || !string.IsNullOrEmpty(subject.EquipmentDescriptionCode) || !string.IsNullOrEmpty(subject.VehicleIdentificationNumber) || !string.IsNullOrEmpty(subject.ReferenceIdentification5))
		{
			subject.EquipmentDescriptionCode = "RB";
			subject.VehicleIdentificationNumber = "h";
			subject.ReferenceIdentification5 = "P";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("bN", "P", false)]
	[InlineData("bN", "", true)]
	[InlineData("", "P", true)]
	public void Validation_OnlyOneOfStateOrProvinceCode(string stateOrProvinceCode, string countrySubdivisionCode, bool isValidExpected)
	{
		var subject = new VEH_VehicleInformation();
		//Required fields
		//Test Parameters
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CountrySubdivisionCode = countrySubdivisionCode;
		//A Requires B
		if (countrySubdivisionCode != "")
			subject.CountryCode = "Gz";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Name) || !string.IsNullOrEmpty(subject.Name) || !string.IsNullOrEmpty(subject.CountryCode2))
		{
			subject.Name = "B";
			subject.CountryCode2 = "Pw";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification5) || !string.IsNullOrEmpty(subject.ReferenceIdentification5) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier))
		{
			subject.ReferenceIdentification5 = "P";
			subject.ReferenceIdentificationQualifier = "25";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.AgencyQualifierCode = "Ra";
			subject.ReferenceIdentification = "d";
			subject.ReferenceIdentification3 = "a";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentDescriptionCode) || !string.IsNullOrEmpty(subject.EquipmentDescriptionCode) || !string.IsNullOrEmpty(subject.VehicleIdentificationNumber) || !string.IsNullOrEmpty(subject.ReferenceIdentification5))
		{
			subject.EquipmentDescriptionCode = "RB";
			subject.VehicleIdentificationNumber = "h";
			subject.ReferenceIdentification5 = "P";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("B", "Pw", true)]
	[InlineData("B", "", false)]
	[InlineData("", "Pw", false)]
	public void Validation_AllAreRequiredName(string name, string countryCode2, bool isValidExpected)
	{
		var subject = new VEH_VehicleInformation();
		//Required fields
		//Test Parameters
		subject.Name = name;
		subject.CountryCode2 = countryCode2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification5) || !string.IsNullOrEmpty(subject.ReferenceIdentification5) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier))
		{
			subject.ReferenceIdentification5 = "P";
			subject.ReferenceIdentificationQualifier = "25";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.AgencyQualifierCode = "Ra";
			subject.ReferenceIdentification = "d";
			subject.ReferenceIdentification3 = "a";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentDescriptionCode) || !string.IsNullOrEmpty(subject.EquipmentDescriptionCode) || !string.IsNullOrEmpty(subject.VehicleIdentificationNumber) || !string.IsNullOrEmpty(subject.ReferenceIdentification5))
		{
			subject.EquipmentDescriptionCode = "RB";
			subject.VehicleIdentificationNumber = "h";
			subject.ReferenceIdentification5 = "P";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("RB", "h", "P", true)]
	[InlineData("RB", "", "", false)]
	[InlineData("", "h", "P", true)]
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
			subject.Name = "B";
			subject.CountryCode2 = "Pw";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification5) || !string.IsNullOrEmpty(subject.ReferenceIdentification5) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier))
		{
			subject.ReferenceIdentification5 = "P";
			subject.ReferenceIdentificationQualifier = "25";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.AgencyQualifierCode = "Ra";
			subject.ReferenceIdentification = "d";
			subject.ReferenceIdentification3 = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("P", "25", true)]
	[InlineData("P", "", false)]
	[InlineData("", "25", false)]
	public void Validation_AllAreRequiredReferenceIdentification5(string referenceIdentification5, string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new VEH_VehicleInformation();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentification5 = referenceIdentification5;
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Name) || !string.IsNullOrEmpty(subject.Name) || !string.IsNullOrEmpty(subject.CountryCode2))
		{
			subject.Name = "B";
			subject.CountryCode2 = "Pw";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.AgencyQualifierCode = "Ra";
			subject.ReferenceIdentification = "d";
			subject.ReferenceIdentification3 = "a";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentDescriptionCode) || !string.IsNullOrEmpty(subject.EquipmentDescriptionCode) || !string.IsNullOrEmpty(subject.VehicleIdentificationNumber))
		{
			subject.EquipmentDescriptionCode = "RB";
			subject.VehicleIdentificationNumber = "h";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("P", "Gz", true)]
	[InlineData("P", "", false)]
	[InlineData("", "Gz", true)]
	public void Validation_ARequiresBCountrySubdivisionCode(string countrySubdivisionCode, string countryCode, bool isValidExpected)
	{
		var subject = new VEH_VehicleInformation();
		//Required fields
		//Test Parameters
		subject.CountrySubdivisionCode = countrySubdivisionCode;
		subject.CountryCode = countryCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Name) || !string.IsNullOrEmpty(subject.Name) || !string.IsNullOrEmpty(subject.CountryCode2))
		{
			subject.Name = "B";
			subject.CountryCode2 = "Pw";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification5) || !string.IsNullOrEmpty(subject.ReferenceIdentification5) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier))
		{
			subject.ReferenceIdentification5 = "P";
			subject.ReferenceIdentificationQualifier = "25";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.AgencyQualifierCode = "Ra";
			subject.ReferenceIdentification = "d";
			subject.ReferenceIdentification3 = "a";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentDescriptionCode) || !string.IsNullOrEmpty(subject.EquipmentDescriptionCode) || !string.IsNullOrEmpty(subject.VehicleIdentificationNumber) || !string.IsNullOrEmpty(subject.ReferenceIdentification5))
		{
			subject.EquipmentDescriptionCode = "RB";
			subject.VehicleIdentificationNumber = "h";
			subject.ReferenceIdentification5 = "P";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

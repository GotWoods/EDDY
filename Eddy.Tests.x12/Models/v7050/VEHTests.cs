using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7050;

namespace Eddy.x12.Tests.Models.v7050;

public class VEHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VEH*5*C*1328*21*L*W*i*7*D*9K*q*d*0*V*A*0*3g*n*iD*Rb*5*kz*N*Y*I*p";

		var expected = new VEH_VehicleInformation()
		{
			AssignedNumber = 5,
			VehicleIdentificationNumber = "C",
			Year = 1328,
			AgencyQualifierCode = "21",
			ReferenceIdentification = "L",
			ReferenceIdentification2 = "W",
			ReferenceIdentification3 = "i",
			Length = 7,
			ReferenceIdentification4 = "D",
			StateOrProvinceCode = "9K",
			LocationIdentifier = "q",
			YesNoConditionOrResponseCode = "d",
			Amount = "0",
			YesNoConditionOrResponseCode2 = "V",
			Amount2 = "A",
			ActionCode = "0",
			CountryCode = "3g",
			Name = "n",
			CountryCode2 = "iD",
			EquipmentDescriptionCode = "Rb",
			ReferenceIdentification5 = "5",
			ReferenceIdentificationQualifier = "kz",
			LoadEmptyStatusCode = "N",
			ReferenceIdentification6 = "Y",
			ReferenceIdentification7 = "I",
			CountrySubdivisionCode = "p",
		};

		var actual = Map.MapObject<VEH_VehicleInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("21", "L", "i", true)]
	[InlineData("21", "", "", false)]
	[InlineData("", "L", "i", true)]
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
			subject.AgencyQualifierCode = "21";
		if (referenceIdentification3 != "")
			subject.AgencyQualifierCode = "21";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Name) || !string.IsNullOrEmpty(subject.Name) || !string.IsNullOrEmpty(subject.CountryCode2))
		{
			subject.Name = "n";
			subject.CountryCode2 = "iD";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification5) || !string.IsNullOrEmpty(subject.ReferenceIdentification5) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier))
		{
			subject.ReferenceIdentification5 = "5";
			subject.ReferenceIdentificationQualifier = "kz";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.EquipmentDescriptionCode) || !string.IsNullOrEmpty(subject.EquipmentDescriptionCode) || !string.IsNullOrEmpty(subject.VehicleIdentificationNumber) || !string.IsNullOrEmpty(subject.ReferenceIdentification5))
		{
			subject.EquipmentDescriptionCode = "Rb";
			subject.VehicleIdentificationNumber = "C";
			subject.ReferenceIdentification5 = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("L", "21", true)]
	[InlineData("L", "", false)]
	[InlineData("", "21", true)]
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
			subject.Name = "n";
			subject.CountryCode2 = "iD";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification5) || !string.IsNullOrEmpty(subject.ReferenceIdentification5) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier))
		{
			subject.ReferenceIdentification5 = "5";
			subject.ReferenceIdentificationQualifier = "kz";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentification3 = "i";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentDescriptionCode) || !string.IsNullOrEmpty(subject.EquipmentDescriptionCode) || !string.IsNullOrEmpty(subject.VehicleIdentificationNumber) || !string.IsNullOrEmpty(subject.ReferenceIdentification5))
		{
			subject.EquipmentDescriptionCode = "Rb";
			subject.VehicleIdentificationNumber = "C";
			subject.ReferenceIdentification5 = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("i", "21", true)]
	[InlineData("i", "", false)]
	[InlineData("", "21", true)]
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
			subject.Name = "n";
			subject.CountryCode2 = "iD";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification5) || !string.IsNullOrEmpty(subject.ReferenceIdentification5) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier))
		{
			subject.ReferenceIdentification5 = "5";
			subject.ReferenceIdentificationQualifier = "kz";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentification = "L";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentDescriptionCode) || !string.IsNullOrEmpty(subject.EquipmentDescriptionCode) || !string.IsNullOrEmpty(subject.VehicleIdentificationNumber) || !string.IsNullOrEmpty(subject.ReferenceIdentification5))
		{
			subject.EquipmentDescriptionCode = "Rb";
			subject.VehicleIdentificationNumber = "C";
			subject.ReferenceIdentification5 = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("9K", "3g", true)]
	[InlineData("9K", "", false)]
	[InlineData("", "3g", true)]
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
			subject.Name = "n";
			subject.CountryCode2 = "iD";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification5) || !string.IsNullOrEmpty(subject.ReferenceIdentification5) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier))
		{
			subject.ReferenceIdentification5 = "5";
			subject.ReferenceIdentificationQualifier = "kz";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.AgencyQualifierCode = "21";
			subject.ReferenceIdentification = "L";
			subject.ReferenceIdentification3 = "i";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentDescriptionCode) || !string.IsNullOrEmpty(subject.EquipmentDescriptionCode) || !string.IsNullOrEmpty(subject.VehicleIdentificationNumber) || !string.IsNullOrEmpty(subject.ReferenceIdentification5))
		{
			subject.EquipmentDescriptionCode = "Rb";
			subject.VehicleIdentificationNumber = "C";
			subject.ReferenceIdentification5 = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("9K", "p", false)]
	[InlineData("", "p", true)]
	public void Validation_OnlyOneOfStateOrProvinceCode(string stateOrProvinceCode, string countrySubdivisionCode, bool isValidExpected)
	{
		var subject = new VEH_VehicleInformation();
		//Required fields
		//Test Parameters
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CountrySubdivisionCode = countrySubdivisionCode;
		//A Requires B
		if (countrySubdivisionCode != "")
			subject.CountryCode = "3g";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Name) || !string.IsNullOrEmpty(subject.Name) || !string.IsNullOrEmpty(subject.CountryCode2))
		{
			subject.Name = "n";
			subject.CountryCode2 = "iD";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification5) || !string.IsNullOrEmpty(subject.ReferenceIdentification5) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier))
		{
			subject.ReferenceIdentification5 = "5";
			subject.ReferenceIdentificationQualifier = "kz";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.AgencyQualifierCode = "21";
			subject.ReferenceIdentification = "L";
			subject.ReferenceIdentification3 = "i";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentDescriptionCode) || !string.IsNullOrEmpty(subject.EquipmentDescriptionCode) || !string.IsNullOrEmpty(subject.VehicleIdentificationNumber) || !string.IsNullOrEmpty(subject.ReferenceIdentification5))
		{
			subject.EquipmentDescriptionCode = "Rb";
			subject.VehicleIdentificationNumber = "C";
			subject.ReferenceIdentification5 = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("n", "iD", true)]
	[InlineData("n", "", false)]
	[InlineData("", "iD", false)]
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
			subject.ReferenceIdentification5 = "5";
			subject.ReferenceIdentificationQualifier = "kz";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.AgencyQualifierCode = "21";
			subject.ReferenceIdentification = "L";
			subject.ReferenceIdentification3 = "i";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentDescriptionCode) || !string.IsNullOrEmpty(subject.EquipmentDescriptionCode) || !string.IsNullOrEmpty(subject.VehicleIdentificationNumber) || !string.IsNullOrEmpty(subject.ReferenceIdentification5))
		{
			subject.EquipmentDescriptionCode = "Rb";
			subject.VehicleIdentificationNumber = "C";
			subject.ReferenceIdentification5 = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("Rb", "C", "5", true)]
	[InlineData("Rb", "", "", false)]
	[InlineData("", "C", "5", true)]
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
			subject.Name = "n";
			subject.CountryCode2 = "iD";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification5) || !string.IsNullOrEmpty(subject.ReferenceIdentification5) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier))
		{
			subject.ReferenceIdentification5 = "5";
			subject.ReferenceIdentificationQualifier = "kz";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.AgencyQualifierCode = "21";
			subject.ReferenceIdentification = "L";
			subject.ReferenceIdentification3 = "i";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("5", "kz", true)]
	[InlineData("5", "", false)]
	[InlineData("", "kz", false)]
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
			subject.Name = "n";
			subject.CountryCode2 = "iD";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.AgencyQualifierCode = "21";
			subject.ReferenceIdentification = "L";
			subject.ReferenceIdentification3 = "i";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentDescriptionCode) || !string.IsNullOrEmpty(subject.EquipmentDescriptionCode) || !string.IsNullOrEmpty(subject.VehicleIdentificationNumber))
		{
			subject.EquipmentDescriptionCode = "Rb";
			subject.VehicleIdentificationNumber = "C";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("p", "3g", true)]
	[InlineData("p", "", false)]
	[InlineData("", "3g", true)]
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
			subject.Name = "n";
			subject.CountryCode2 = "iD";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification5) || !string.IsNullOrEmpty(subject.ReferenceIdentification5) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier))
		{
			subject.ReferenceIdentification5 = "5";
			subject.ReferenceIdentificationQualifier = "kz";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.AgencyQualifierCode = "21";
			subject.ReferenceIdentification = "L";
			subject.ReferenceIdentification3 = "i";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentDescriptionCode) || !string.IsNullOrEmpty(subject.EquipmentDescriptionCode) || !string.IsNullOrEmpty(subject.VehicleIdentificationNumber) || !string.IsNullOrEmpty(subject.ReferenceIdentification5))
		{
			subject.EquipmentDescriptionCode = "Rb";
			subject.VehicleIdentificationNumber = "C";
			subject.ReferenceIdentification5 = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

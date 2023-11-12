using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class VIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VID*Kr*r*c*vs*Wl*1836*9*2*5viM*I*F4*D*dz*Q*XP*lG*r*H";

		var expected = new VID_ConveyanceIdentification()
		{
			EquipmentDescriptionCode = "Kr",
			EquipmentInitial = "r",
			EquipmentNumber = "c",
			SealNumber = "vs",
			SealNumber2 = "Wl",
			EquipmentLength = 1836,
			Height = 9,
			Width = 2,
			EquipmentType = "5viM",
			LoadEmptyStatusCode = "I",
			TypeOfServiceCode = "F4",
			LocationIdentifier = "D",
			StandardCarrierAlphaCode = "dz",
			ReferenceIdentification = "Q",
			StateOrProvinceCode = "XP",
			CountryCode = "lG",
			ReferenceIdentification2 = "r",
			CountrySubdivisionCode = "H",
		};

		var actual = Map.MapObject<VID_ConveyanceIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Kr", true)]
	public void Validation_RequiredEquipmentDescriptionCode(string equipmentDescriptionCode, bool isValidExpected)
	{
		var subject = new VID_ConveyanceIdentification();
		//Required fields
		subject.EquipmentNumber = "c";
		//Test Parameters
		subject.EquipmentDescriptionCode = equipmentDescriptionCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.StateOrProvinceCode) || !string.IsNullOrEmpty(subject.CountrySubdivisionCode))
		{
			subject.ReferenceIdentification = "Q";
			subject.StateOrProvinceCode = "XP";
			subject.CountrySubdivisionCode = "H";
		}
		if(!string.IsNullOrEmpty(subject.CountryCode) || !string.IsNullOrEmpty(subject.CountryCode) || !string.IsNullOrEmpty(subject.StateOrProvinceCode) || !string.IsNullOrEmpty(subject.CountrySubdivisionCode))
		{
			subject.CountryCode = "lG";
			subject.StateOrProvinceCode = "XP";
			subject.CountrySubdivisionCode = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new VID_ConveyanceIdentification();
		//Required fields
		subject.EquipmentDescriptionCode = "Kr";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.StateOrProvinceCode) || !string.IsNullOrEmpty(subject.CountrySubdivisionCode))
		{
			subject.ReferenceIdentification = "Q";
			subject.StateOrProvinceCode = "XP";
			subject.CountrySubdivisionCode = "H";
		}
		if(!string.IsNullOrEmpty(subject.CountryCode) || !string.IsNullOrEmpty(subject.CountryCode) || !string.IsNullOrEmpty(subject.StateOrProvinceCode) || !string.IsNullOrEmpty(subject.CountrySubdivisionCode))
		{
			subject.CountryCode = "lG";
			subject.StateOrProvinceCode = "XP";
			subject.CountrySubdivisionCode = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("Q", "", "", false)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_ReferenceIdentification(string referenceIdentification, string stateOrProvinceCode, string countrySubdivisionCode, bool isValidExpected)
	{
		var subject = new VID_ConveyanceIdentification();
		//Required fields
		subject.EquipmentDescriptionCode = "Kr";
		subject.EquipmentNumber = "c";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CountrySubdivisionCode = countrySubdivisionCode;
		//A Requires B
		if (stateOrProvinceCode != "")
			subject.CountryCode = "lG";
		if (countrySubdivisionCode != "")
			subject.CountryCode = "lG";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.CountryCode) || !string.IsNullOrEmpty(subject.CountryCode))
		{
			subject.CountryCode = "lG";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("XP", "", false)]
	[InlineData("", "lG", true)]
	public void Validation_ARequiresBStateOrProvinceCode(string stateOrProvinceCode, string countryCode, bool isValidExpected)
	{
		var subject = new VID_ConveyanceIdentification();
		//Required fields
		subject.EquipmentDescriptionCode = "Kr";
		subject.EquipmentNumber = "c";
		//Test Parameters
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CountryCode = countryCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.CountrySubdivisionCode))
		{
			subject.ReferenceIdentification = "Q";
			subject.CountrySubdivisionCode = "H";
		}
		if(!string.IsNullOrEmpty(subject.CountryCode) || !string.IsNullOrEmpty(subject.CountrySubdivisionCode))
		{
			subject.CountrySubdivisionCode = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("XP", "H", false)]
	[InlineData("", "H", true)]
	public void Validation_OnlyOneOfStateOrProvinceCode(string stateOrProvinceCode, string countrySubdivisionCode, bool isValidExpected)
	{
		var subject = new VID_ConveyanceIdentification();
		//Required fields
		subject.EquipmentDescriptionCode = "Kr";
		subject.EquipmentNumber = "c";
		//Test Parameters
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CountrySubdivisionCode = countrySubdivisionCode;
		//A Requires B
		if (countrySubdivisionCode != "")
			subject.CountryCode = "lG";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentification = "Q";
		}
		if(!string.IsNullOrEmpty(subject.CountryCode) || !string.IsNullOrEmpty(subject.CountryCode))
		{
			subject.CountryCode = "lG";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("lG", "", "", false)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_CountryCode(string countryCode, string stateOrProvinceCode, string countrySubdivisionCode, bool isValidExpected)
	{
		var subject = new VID_ConveyanceIdentification();
		//Required fields
		subject.EquipmentDescriptionCode = "Kr";
		subject.EquipmentNumber = "c";
		//Test Parameters
		subject.CountryCode = countryCode;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CountrySubdivisionCode = countrySubdivisionCode;
		//A Requires B
		if (stateOrProvinceCode != "")
			subject.CountryCode = "lG";
		if (countrySubdivisionCode != "")
			subject.CountryCode = "lG";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentification = "Q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("H", "lG", true)]
	public void Validation_ARequiresBCountrySubdivisionCode(string countrySubdivisionCode, string countryCode, bool isValidExpected)
	{
		var subject = new VID_ConveyanceIdentification();
		//Required fields
		subject.EquipmentDescriptionCode = "Kr";
		subject.EquipmentNumber = "c";
		//Test Parameters
		subject.CountrySubdivisionCode = countrySubdivisionCode;
		subject.CountryCode = countryCode;
		
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

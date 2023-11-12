using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class VIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VID*ed*E*l*lB*Lm*8996*1*5*tHWJ*t*VV*I*nF*r*oi*3x*S*2*L*9";

		var expected = new VID_ConveyanceIdentification()
		{
			EquipmentDescriptionCode = "ed",
			EquipmentInitial = "E",
			EquipmentNumber = "l",
			SealNumber = "lB",
			SealNumber2 = "Lm",
			EquipmentLength = 8996,
			Height = 1,
			Width = 5,
			EquipmentTypeCode = "tHWJ",
			LoadEmptyStatusCode = "t",
			TypeOfServiceCode = "VV",
			LocationIdentifier = "I",
			StandardCarrierAlphaCode = "nF",
			ReferenceIdentification = "r",
			StateOrProvinceCode = "oi",
			CountryCode = "3x",
			ReferenceIdentification2 = "S",
			CountrySubdivisionCode = "2",
			ImportExportCode = "L",
			EquipmentNumberCheckDigit = 9,
		};

		var actual = Map.MapObject<VID_ConveyanceIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ed", true)]
	public void Validation_RequiredEquipmentDescriptionCode(string equipmentDescriptionCode, bool isValidExpected)
	{
		var subject = new VID_ConveyanceIdentification();
		//Required fields
		subject.EquipmentNumber = "l";
		//Test Parameters
		subject.EquipmentDescriptionCode = equipmentDescriptionCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.StateOrProvinceCode) || !string.IsNullOrEmpty(subject.CountrySubdivisionCode))
		{
			subject.ReferenceIdentification = "r";
			subject.StateOrProvinceCode = "oi";
			subject.CountrySubdivisionCode = "2";
		}
		if(!string.IsNullOrEmpty(subject.CountryCode) || !string.IsNullOrEmpty(subject.CountryCode) || !string.IsNullOrEmpty(subject.StateOrProvinceCode) || !string.IsNullOrEmpty(subject.CountrySubdivisionCode))
		{
			subject.CountryCode = "3x";
			subject.StateOrProvinceCode = "oi";
			subject.CountrySubdivisionCode = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new VID_ConveyanceIdentification();
		//Required fields
		subject.EquipmentDescriptionCode = "ed";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.StateOrProvinceCode) || !string.IsNullOrEmpty(subject.CountrySubdivisionCode))
		{
			subject.ReferenceIdentification = "r";
			subject.StateOrProvinceCode = "oi";
			subject.CountrySubdivisionCode = "2";
		}
		if(!string.IsNullOrEmpty(subject.CountryCode) || !string.IsNullOrEmpty(subject.CountryCode) || !string.IsNullOrEmpty(subject.StateOrProvinceCode) || !string.IsNullOrEmpty(subject.CountrySubdivisionCode))
		{
			subject.CountryCode = "3x";
			subject.StateOrProvinceCode = "oi";
			subject.CountrySubdivisionCode = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("r", "", "", false)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_ReferenceIdentification(string referenceIdentification, string stateOrProvinceCode, string countrySubdivisionCode, bool isValidExpected)
	{
		var subject = new VID_ConveyanceIdentification();
		//Required fields
		subject.EquipmentDescriptionCode = "ed";
		subject.EquipmentNumber = "l";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CountrySubdivisionCode = countrySubdivisionCode;
		//A Requires B
		if (stateOrProvinceCode != "")
			subject.CountryCode = "3x";
		if (countrySubdivisionCode != "")
			subject.CountryCode = "3x";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.CountryCode) || !string.IsNullOrEmpty(subject.CountryCode))
		{
			subject.CountryCode = "3x";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("oi", "", false)]
	[InlineData("", "3x", true)]
	public void Validation_ARequiresBStateOrProvinceCode(string stateOrProvinceCode, string countryCode, bool isValidExpected)
	{
		var subject = new VID_ConveyanceIdentification();
		//Required fields
		subject.EquipmentDescriptionCode = "ed";
		subject.EquipmentNumber = "l";
		//Test Parameters
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CountryCode = countryCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.CountrySubdivisionCode))
		{
			subject.ReferenceIdentification = "r";
			subject.CountrySubdivisionCode = "2";
		}
		if(!string.IsNullOrEmpty(subject.CountryCode) || !string.IsNullOrEmpty(subject.CountrySubdivisionCode))
		{
			subject.CountrySubdivisionCode = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("oi", "2", false)]
	[InlineData("", "2", true)]
	public void Validation_OnlyOneOfStateOrProvinceCode(string stateOrProvinceCode, string countrySubdivisionCode, bool isValidExpected)
	{
		var subject = new VID_ConveyanceIdentification();
		//Required fields
		subject.EquipmentDescriptionCode = "ed";
		subject.EquipmentNumber = "l";
		//Test Parameters
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CountrySubdivisionCode = countrySubdivisionCode;
		//A Requires B
		if (countrySubdivisionCode != "")
			subject.CountryCode = "3x";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentification = "r";
		}
		if(!string.IsNullOrEmpty(subject.CountryCode) || !string.IsNullOrEmpty(subject.CountryCode))
		{
			subject.CountryCode = "3x";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("3x", "", "", false)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_CountryCode(string countryCode, string stateOrProvinceCode, string countrySubdivisionCode, bool isValidExpected)
	{
		var subject = new VID_ConveyanceIdentification();
		//Required fields
		subject.EquipmentDescriptionCode = "ed";
		subject.EquipmentNumber = "l";
		//Test Parameters
		subject.CountryCode = countryCode;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CountrySubdivisionCode = countrySubdivisionCode;
		//A Requires B
		if (stateOrProvinceCode != "")
			subject.CountryCode = "3x";
		if (countrySubdivisionCode != "")
			subject.CountryCode = "3x";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentification = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("2", "", false)]
	[InlineData("", "3x", true)]
	public void Validation_ARequiresBCountrySubdivisionCode(string countrySubdivisionCode, string countryCode, bool isValidExpected)
	{
		var subject = new VID_ConveyanceIdentification();
		//Required fields
		subject.EquipmentDescriptionCode = "ed";
		subject.EquipmentNumber = "l";
		//Test Parameters
		subject.CountrySubdivisionCode = countrySubdivisionCode;
		subject.CountryCode = countryCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.ReferenceIdentification = "r";
			subject.StateOrProvinceCode = "oi";
		}
		if(!string.IsNullOrEmpty(subject.CountryCode) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.StateOrProvinceCode = "oi";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

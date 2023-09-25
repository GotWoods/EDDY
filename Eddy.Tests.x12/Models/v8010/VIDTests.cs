using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.Tests.Models.v8010;

public class VIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VID*e6*B*q*I*K*9726*8*8*BITb*Y*FE*a*37*Y*4v*JF*T*g*z*7";

		var expected = new VID_ConveyanceIdentification()
		{
			EquipmentDescriptionCode = "e6",
			EquipmentInitial = "B",
			EquipmentNumber = "q",
			SealNumber = "I",
			SealNumber2 = "K",
			EquipmentLength = 9726,
			Height = 8,
			Width = 8,
			EquipmentTypeCode = "BITb",
			LoadEmptyStatusCode = "Y",
			TypeOfServiceCode = "FE",
			LocationIdentifier = "a",
			StandardCarrierAlphaCode = "37",
			ReferenceIdentification = "Y",
			StateOrProvinceCode = "4v",
			CountryCode = "JF",
			ReferenceIdentification2 = "T",
			CountrySubdivisionCode = "g",
			ImportExportCode = "z",
			EquipmentNumberCheckDigit = 7,
		};

		var actual = Map.MapObject<VID_ConveyanceIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e6", true)]
	public void Validation_RequiredEquipmentDescriptionCode(string equipmentDescriptionCode, bool isValidExpected)
	{
		var subject = new VID_ConveyanceIdentification();
		//Required fields
		subject.EquipmentNumber = "q";
		//Test Parameters
		subject.EquipmentDescriptionCode = equipmentDescriptionCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.StateOrProvinceCode) || !string.IsNullOrEmpty(subject.CountrySubdivisionCode))
		{
			subject.ReferenceIdentification = "Y";
			subject.StateOrProvinceCode = "4v";
			subject.CountrySubdivisionCode = "g";
		}
		if(!string.IsNullOrEmpty(subject.CountryCode) || !string.IsNullOrEmpty(subject.CountryCode) || !string.IsNullOrEmpty(subject.StateOrProvinceCode) || !string.IsNullOrEmpty(subject.CountrySubdivisionCode))
		{
			subject.CountryCode = "JF";
			subject.StateOrProvinceCode = "4v";
			subject.CountrySubdivisionCode = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new VID_ConveyanceIdentification();
		//Required fields
		subject.EquipmentDescriptionCode = "e6";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.StateOrProvinceCode) || !string.IsNullOrEmpty(subject.CountrySubdivisionCode))
		{
			subject.ReferenceIdentification = "Y";
			subject.StateOrProvinceCode = "4v";
			subject.CountrySubdivisionCode = "g";
		}
		if(!string.IsNullOrEmpty(subject.CountryCode) || !string.IsNullOrEmpty(subject.CountryCode) || !string.IsNullOrEmpty(subject.StateOrProvinceCode) || !string.IsNullOrEmpty(subject.CountrySubdivisionCode))
		{
			subject.CountryCode = "JF";
			subject.StateOrProvinceCode = "4v";
			subject.CountrySubdivisionCode = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("Y", "4v", "g", true)]
	[InlineData("Y", "", "", false)]
	[InlineData("", "4v", "g", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_ReferenceIdentification(string referenceIdentification, string stateOrProvinceCode, string countrySubdivisionCode, bool isValidExpected)
	{
		var subject = new VID_ConveyanceIdentification();
		//Required fields
		subject.EquipmentDescriptionCode = "e6";
		subject.EquipmentNumber = "q";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CountrySubdivisionCode = countrySubdivisionCode;
		//A Requires B
		if (stateOrProvinceCode != "")
			subject.CountryCode = "JF";
		if (countrySubdivisionCode != "")
			subject.CountryCode = "JF";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.CountryCode) || !string.IsNullOrEmpty(subject.CountryCode))
		{
			subject.CountryCode = "JF";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("4v", "", false)]
	[InlineData("", "JF", true)]
	public void Validation_ARequiresBStateOrProvinceCode(string stateOrProvinceCode, string countryCode, bool isValidExpected)
	{
		var subject = new VID_ConveyanceIdentification();
		//Required fields
		subject.EquipmentDescriptionCode = "e6";
		subject.EquipmentNumber = "q";
		//Test Parameters
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CountryCode = countryCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.CountrySubdivisionCode))
		{
			subject.ReferenceIdentification = "Y";
			subject.CountrySubdivisionCode = "g";
		}
		if(!string.IsNullOrEmpty(subject.CountryCode) || !string.IsNullOrEmpty(subject.CountrySubdivisionCode))
		{
			subject.CountrySubdivisionCode = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("4v", "g", false)]
	[InlineData("", "g", true)]
	public void Validation_OnlyOneOfStateOrProvinceCode(string stateOrProvinceCode, string countrySubdivisionCode, bool isValidExpected)
	{
		var subject = new VID_ConveyanceIdentification();
		//Required fields
		subject.EquipmentDescriptionCode = "e6";
		subject.EquipmentNumber = "q";
		//Test Parameters
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CountrySubdivisionCode = countrySubdivisionCode;
		//A Requires B
		if (countrySubdivisionCode != "")
			subject.CountryCode = "JF";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentification = "Y";
		}
		if(!string.IsNullOrEmpty(subject.CountryCode) || !string.IsNullOrEmpty(subject.CountryCode))
		{
			subject.CountryCode = "JF";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("JF", "4v", "g", true)]
	[InlineData("JF", "", "", false)]
	[InlineData("", "4v", "g", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_CountryCode(string countryCode, string stateOrProvinceCode, string countrySubdivisionCode, bool isValidExpected)
	{
		var subject = new VID_ConveyanceIdentification();
		//Required fields
		subject.EquipmentDescriptionCode = "e6";
		subject.EquipmentNumber = "q";
		//Test Parameters
		subject.CountryCode = countryCode;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CountrySubdivisionCode = countrySubdivisionCode;
		//A Requires B
		if (stateOrProvinceCode != "")
			subject.CountryCode = "JF";
		if (countrySubdivisionCode != "")
			subject.CountryCode = "JF";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentification = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("g", "", false)]
	[InlineData("", "JF", true)]
	public void Validation_ARequiresBCountrySubdivisionCode(string countrySubdivisionCode, string countryCode, bool isValidExpected)
	{
		var subject = new VID_ConveyanceIdentification();
		//Required fields
		subject.EquipmentDescriptionCode = "e6";
		subject.EquipmentNumber = "q";
		//Test Parameters
		subject.CountrySubdivisionCode = countrySubdivisionCode;
		subject.CountryCode = countryCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.ReferenceIdentification = "Y";
			subject.StateOrProvinceCode = "4v";
		}
		if(!string.IsNullOrEmpty(subject.CountryCode) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.StateOrProvinceCode = "4v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

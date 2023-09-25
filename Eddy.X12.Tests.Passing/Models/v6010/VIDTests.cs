using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class VIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VID*6D*Y*5*Vb*ca*4741*7*2*dX9D*h*xP*q*qj*2*bi*38*s*u*A*1";

		var expected = new VID_ConveyanceIdentification()
		{
			EquipmentDescriptionCode = "6D",
			EquipmentInitial = "Y",
			EquipmentNumber = "5",
			SealNumber = "Vb",
			SealNumber2 = "ca",
			EquipmentLength = 4741,
			Height = 7,
			Width = 2,
			EquipmentType = "dX9D",
			LoadEmptyStatusCode = "h",
			TypeOfServiceCode = "xP",
			LocationIdentifier = "q",
			StandardCarrierAlphaCode = "qj",
			ReferenceIdentification = "2",
			StateOrProvinceCode = "bi",
			CountryCode = "38",
			ReferenceIdentification2 = "s",
			CountrySubdivisionCode = "u",
			ImportExportCode = "A",
			EquipmentNumberCheckDigit = 1,
		};

		var actual = Map.MapObject<VID_ConveyanceIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6D", true)]
	public void Validation_RequiredEquipmentDescriptionCode(string equipmentDescriptionCode, bool isValidExpected)
	{
		var subject = new VID_ConveyanceIdentification();
		//Required fields
		subject.EquipmentNumber = "5";
		//Test Parameters
		subject.EquipmentDescriptionCode = equipmentDescriptionCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.StateOrProvinceCode) || !string.IsNullOrEmpty(subject.CountrySubdivisionCode))
		{
			subject.ReferenceIdentification = "2";
			subject.StateOrProvinceCode = "bi";
			subject.CountrySubdivisionCode = "u";
		}
		if(!string.IsNullOrEmpty(subject.CountryCode) || !string.IsNullOrEmpty(subject.CountryCode) || !string.IsNullOrEmpty(subject.StateOrProvinceCode) || !string.IsNullOrEmpty(subject.CountrySubdivisionCode))
		{
			subject.CountryCode = "38";
			subject.StateOrProvinceCode = "bi";
			subject.CountrySubdivisionCode = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new VID_ConveyanceIdentification();
		//Required fields
		subject.EquipmentDescriptionCode = "6D";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.StateOrProvinceCode) || !string.IsNullOrEmpty(subject.CountrySubdivisionCode))
		{
			subject.ReferenceIdentification = "2";
			subject.StateOrProvinceCode = "bi";
			subject.CountrySubdivisionCode = "u";
		}
		if(!string.IsNullOrEmpty(subject.CountryCode) || !string.IsNullOrEmpty(subject.CountryCode) || !string.IsNullOrEmpty(subject.StateOrProvinceCode) || !string.IsNullOrEmpty(subject.CountrySubdivisionCode))
		{
			subject.CountryCode = "38";
			subject.StateOrProvinceCode = "bi";
			subject.CountrySubdivisionCode = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("2", "", "", false)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_ReferenceIdentification(string referenceIdentification, string stateOrProvinceCode, string countrySubdivisionCode, bool isValidExpected)
	{
		var subject = new VID_ConveyanceIdentification();
		//Required fields
		subject.EquipmentDescriptionCode = "6D";
		subject.EquipmentNumber = "5";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CountrySubdivisionCode = countrySubdivisionCode;
		//A Requires B
		if (stateOrProvinceCode != "")
			subject.CountryCode = "38";
		if (countrySubdivisionCode != "")
			subject.CountryCode = "38";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.CountryCode) || !string.IsNullOrEmpty(subject.CountryCode))
		{
			subject.CountryCode = "38";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	
	[InlineData("bi", "", false)]
	[InlineData("", "38", true)]
	public void Validation_ARequiresBStateOrProvinceCode(string stateOrProvinceCode, string countryCode, bool isValidExpected)
	{
		var subject = new VID_ConveyanceIdentification();
		//Required fields
		subject.EquipmentDescriptionCode = "6D";
		subject.EquipmentNumber = "5";
		//Test Parameters
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CountryCode = countryCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.CountrySubdivisionCode))
		{
			subject.ReferenceIdentification = "2";
			subject.CountrySubdivisionCode = "u";
		}
		if(!string.IsNullOrEmpty(subject.CountryCode) || !string.IsNullOrEmpty(subject.CountrySubdivisionCode))
		{
			subject.CountrySubdivisionCode = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("bi", "u", false)]
	[InlineData("", "u", true)]
	public void Validation_OnlyOneOfStateOrProvinceCode(string stateOrProvinceCode, string countrySubdivisionCode, bool isValidExpected)
	{
		var subject = new VID_ConveyanceIdentification();
		//Required fields
		subject.EquipmentDescriptionCode = "6D";
		subject.EquipmentNumber = "5";
		//Test Parameters
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CountrySubdivisionCode = countrySubdivisionCode;
		//A Requires B
		if (countrySubdivisionCode != "")
			subject.CountryCode = "38";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentification = "2";
		}
		if(!string.IsNullOrEmpty(subject.CountryCode) || !string.IsNullOrEmpty(subject.CountryCode))
		{
			subject.CountryCode = "38";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("38", "", "", false)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_CountryCode(string countryCode, string stateOrProvinceCode, string countrySubdivisionCode, bool isValidExpected)
	{
		var subject = new VID_ConveyanceIdentification();
		//Required fields
		subject.EquipmentDescriptionCode = "6D";
		subject.EquipmentNumber = "5";
		//Test Parameters
		subject.CountryCode = countryCode;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CountrySubdivisionCode = countrySubdivisionCode;
		//A Requires B
		if (stateOrProvinceCode != "")
			subject.CountryCode = "38";
		if (countrySubdivisionCode != "")
			subject.CountryCode = "38";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentification = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("u", "", false)]
	[InlineData("", "38", true)]
	public void Validation_ARequiresBCountrySubdivisionCode(string countrySubdivisionCode, string countryCode, bool isValidExpected)
	{
		var subject = new VID_ConveyanceIdentification();
		//Required fields
		subject.EquipmentDescriptionCode = "6D";
		subject.EquipmentNumber = "5";
		//Test Parameters
		subject.CountrySubdivisionCode = countrySubdivisionCode;
		subject.CountryCode = countryCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.ReferenceIdentification = "2";
			subject.StateOrProvinceCode = "bi";
		}
		if(!string.IsNullOrEmpty(subject.CountryCode) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.StateOrProvinceCode = "bi";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

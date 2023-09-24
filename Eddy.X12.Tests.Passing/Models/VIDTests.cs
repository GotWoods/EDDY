using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class VIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VID*lK*K*Z*o*2*7431*2*5*Tec4*9*Pd*A*Og*P*Ou*3h*Z*Q*v*5";

		var expected = new VID_ConveyanceIdentification()
		{
			EquipmentDescriptionCode = "lK",
			EquipmentInitial = "K",
			EquipmentNumber = "Z",
			SealNumber = "o",
			SealNumber2 = "2",
			EquipmentLength = 7431,
			Height = 2,
			Width = 5,
			EquipmentTypeCode = "Tec4",
			LoadEmptyStatusCode = "9",
			TypeOfServiceCode = "Pd",
			LocationIdentifier = "A",
			StandardCarrierAlphaCode = "Og",
			ReferenceIdentification = "P",
			StateOrProvinceCode = "Ou",
			CountryCode = "3h",
			ReferenceIdentification2 = "Z",
			CountrySubdivisionCode = "Q",
			ImportExportCode = "v",
			EquipmentNumberCheckDigit = 5,
		};

		var actual = Map.MapObject<VID_ConveyanceIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lK", true)]
	public void Validation_RequiredEquipmentDescriptionCode(string equipmentDescriptionCode, bool isValidExpected)
	{
		var subject = new VID_ConveyanceIdentification();
		subject.EquipmentNumber = "Z";
		subject.EquipmentDescriptionCode = equipmentDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new VID_ConveyanceIdentification();
		subject.EquipmentDescriptionCode = "lK";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("P", "Ou", "", true)]
	[InlineData("", "Ou", "", true)]
	[InlineData("P", "", "", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_ReferenceIdentification(string referenceIdentification, string stateOrProvinceCode, string countrySubdivisionCode, bool isValidExpected)
	{
		var subject = new VID_ConveyanceIdentification();
		subject.EquipmentDescriptionCode = "lK";
		subject.EquipmentNumber = "Z";
		subject.ReferenceIdentification = referenceIdentification;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CountrySubdivisionCode = countrySubdivisionCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "3h", true)]
	[InlineData("Ou", "", false)]
	public void Validation_ARequiresBStateOrProvinceCode(string stateOrProvinceCode, string countryCode, bool isValidExpected)
	{
		var subject = new VID_ConveyanceIdentification();
		subject.EquipmentDescriptionCode = "lK";
		subject.EquipmentNumber = "Z";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CountryCode = countryCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ou", "Q", false)]
	[InlineData("", "Q", true)]
	[InlineData("Ou", "", true)]
	public void Validation_OnlyOneOfStateOrProvinceCode(string stateOrProvinceCode, string countrySubdivisionCode, bool isValidExpected)
	{
		var subject = new VID_ConveyanceIdentification();
		subject.EquipmentDescriptionCode = "lK";
		subject.EquipmentNumber = "Z";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CountrySubdivisionCode = countrySubdivisionCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("3h", "Ou", "", true)]
	[InlineData("", "Ou", "", true)]
	[InlineData("3h", "", "", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_CountryCode(string countryCode, string stateOrProvinceCode, string countrySubdivisionCode, bool isValidExpected)
	{
		var subject = new VID_ConveyanceIdentification();
		subject.EquipmentDescriptionCode = "lK";
		subject.EquipmentNumber = "Z";
		subject.CountryCode = countryCode;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CountrySubdivisionCode = countrySubdivisionCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "3h", true)]
	[InlineData("Q", "", false)]
	public void Validation_ARequiresBCountrySubdivisionCode(string countrySubdivisionCode, string countryCode, bool isValidExpected)
	{
		var subject = new VID_ConveyanceIdentification();
		subject.EquipmentDescriptionCode = "lK";
		subject.EquipmentNumber = "Z";
		subject.CountrySubdivisionCode = countrySubdivisionCode;
		subject.CountryCode = countryCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

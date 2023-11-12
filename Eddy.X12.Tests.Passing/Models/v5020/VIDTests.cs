using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5020;

namespace Eddy.x12.Tests.Models.v5020;

public class VIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VID*j7*F*K*sN*jv*8535*5*6*3nEq*N*Fv*S*Dd*i*MJ*vB*Y";

		var expected = new VID_ConveyanceIdentification()
		{
			EquipmentDescriptionCode = "j7",
			EquipmentInitial = "F",
			EquipmentNumber = "K",
			SealNumber = "sN",
			SealNumber2 = "jv",
			EquipmentLength = 8535,
			Height = 5,
			Width = 6,
			EquipmentType = "3nEq",
			LoadEmptyStatusCode = "N",
			TypeOfServiceCode = "Fv",
			LocationIdentifier = "S",
			StandardCarrierAlphaCode = "Dd",
			ReferenceIdentification = "i",
			StateOrProvinceCode = "MJ",
			CountryCode = "vB",
			ReferenceIdentification2 = "Y",
		};

		var actual = Map.MapObject<VID_ConveyanceIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j7", true)]
	public void Validation_RequiredEquipmentDescriptionCode(string equipmentDescriptionCode, bool isValidExpected)
	{
		var subject = new VID_ConveyanceIdentification();
		//Required fields
		subject.EquipmentNumber = "K";
		//Test Parameters
		subject.EquipmentDescriptionCode = equipmentDescriptionCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.ReferenceIdentification = "i";
			subject.StateOrProvinceCode = "MJ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new VID_ConveyanceIdentification();
		//Required fields
		subject.EquipmentDescriptionCode = "j7";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.ReferenceIdentification = "i";
			subject.StateOrProvinceCode = "MJ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("i", "MJ", true)]
	[InlineData("i", "", false)]
	[InlineData("", "MJ", false)]
	public void Validation_AllAreRequiredReferenceIdentification(string referenceIdentification, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new VID_ConveyanceIdentification();
		//Required fields
		subject.EquipmentDescriptionCode = "j7";
		subject.EquipmentNumber = "K";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("vB", "MJ", true)]
	[InlineData("vB", "", false)]
	[InlineData("", "MJ", true)]
	public void Validation_ARequiresBCountryCode(string countryCode, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new VID_ConveyanceIdentification();
		//Required fields
		subject.EquipmentDescriptionCode = "j7";
		subject.EquipmentNumber = "K";
		//Test Parameters
		subject.CountryCode = countryCode;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.ReferenceIdentification = "i";
			subject.StateOrProvinceCode = "MJ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class GR4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GR4*c*s6*j*M*4*1*p*f*g9*O9*fd";

		var expected = new GR4_LoadingCluster()
		{
			ConfigurationTypeCode = "c",
			EquipmentDescriptionCode = "s6",
			EquipmentUseCode = "j",
			ReferenceIdentification = "M",
			EquipmentInitial = "4",
			EquipmentNumber = "1",
			LocationQualifier = "p",
			LocationIdentifier = "f",
			CityName = "g9",
			StateOrProvinceCode = "O9",
			CountryCode = "fd",
		};

		var actual = Map.MapObject<GR4_LoadingCluster>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredConfigurationTypeCode(string configurationTypeCode, bool isValidExpected)
	{
		var subject = new GR4_LoadingCluster();
		subject.EquipmentDescriptionCode = "s6";
		subject.EquipmentUseCode = "j";
		subject.ConfigurationTypeCode = configurationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s6", true)]
	public void Validation_RequiredEquipmentDescriptionCode(string equipmentDescriptionCode, bool isValidExpected)
	{
		var subject = new GR4_LoadingCluster();
		subject.ConfigurationTypeCode = "c";
		subject.EquipmentUseCode = "j";
		subject.EquipmentDescriptionCode = equipmentDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredEquipmentUseCode(string equipmentUseCode, bool isValidExpected)
	{
		var subject = new GR4_LoadingCluster();
		subject.ConfigurationTypeCode = "c";
		subject.EquipmentDescriptionCode = "s6";
		subject.EquipmentUseCode = equipmentUseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("M","4", true)]
	[InlineData("", "4", true)]
	[InlineData("M", "", true)]
	public void Validation_AtLeastOneReferenceIdentification(string referenceIdentification, string equipmentInitial, bool isValidExpected)
	{
		var subject = new GR4_LoadingCluster();
		subject.ConfigurationTypeCode = "c";
		subject.EquipmentDescriptionCode = "s6";
		subject.EquipmentUseCode = "j";
		subject.ReferenceIdentification = referenceIdentification;
		subject.EquipmentInitial = equipmentInitial;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("4", "1", true)]
	[InlineData("", "1", false)]
	[InlineData("4", "", false)]
	public void Validation_AllAreRequiredEquipmentInitial(string equipmentInitial, string equipmentNumber, bool isValidExpected)
	{
		var subject = new GR4_LoadingCluster();
		subject.ConfigurationTypeCode = "c";
		subject.EquipmentDescriptionCode = "s6";
		subject.EquipmentUseCode = "j";
		subject.EquipmentInitial = equipmentInitial;
		subject.EquipmentNumber = equipmentNumber;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("p", "f", true)]
	[InlineData("", "f", false)]
	[InlineData("p", "", false)]
	public void Validation_AllAreRequiredLocationQualifier(string locationQualifier, string locationIdentifier, bool isValidExpected)
	{
		var subject = new GR4_LoadingCluster();
		subject.ConfigurationTypeCode = "c";
		subject.EquipmentDescriptionCode = "s6";
		subject.EquipmentUseCode = "j";
		subject.LocationQualifier = locationQualifier;
		subject.LocationIdentifier = locationIdentifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("f","g9", true)]
	[InlineData("", "g9", true)]
	[InlineData("f", "", true)]
	public void Validation_AtLeastOneLocationIdentifier(string locationIdentifier, string cityName, bool isValidExpected)
	{
		var subject = new GR4_LoadingCluster();
		subject.ConfigurationTypeCode = "c";
		subject.EquipmentDescriptionCode = "s6";
		subject.EquipmentUseCode = "j";
		subject.LocationIdentifier = locationIdentifier;
		subject.CityName = cityName;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("g9", "O9", true)]
	[InlineData("", "O9", false)]
	[InlineData("g9", "", false)]
	public void Validation_AllAreRequiredCityName(string cityName, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new GR4_LoadingCluster();
		subject.ConfigurationTypeCode = "c";
		subject.EquipmentDescriptionCode = "s6";
		subject.EquipmentUseCode = "j";
		subject.CityName = cityName;
		subject.StateOrProvinceCode = stateOrProvinceCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "O9", true)]
	[InlineData("fd", "", false)]
	public void Validation_ARequiresBCountryCode(string countryCode, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new GR4_LoadingCluster();
		subject.ConfigurationTypeCode = "c";
		subject.EquipmentDescriptionCode = "s6";
		subject.EquipmentUseCode = "j";
		subject.CountryCode = countryCode;
		subject.StateOrProvinceCode = stateOrProvinceCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

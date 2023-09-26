using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class GR4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GR4*c*Hk*3*L*5*5*D*u*5h*5s*mQ";

		var expected = new GR4_LoadingCluster()
		{
			ConfigurationTypeCode = "c",
			EquipmentDescriptionCode = "Hk",
			EquipmentUseCode = "3",
			ReferenceIdentification = "L",
			EquipmentInitial = "5",
			EquipmentNumber = "5",
			LocationQualifier = "D",
			LocationIdentifier = "u",
			CityName = "5h",
			StateOrProvinceCode = "5s",
			CountryCode = "mQ",
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
		//Required fields
		subject.EquipmentDescriptionCode = "Hk";
		subject.EquipmentUseCode = "3";
		//Test Parameters
		subject.ConfigurationTypeCode = configurationTypeCode;
		//At Least one
		subject.ReferenceIdentification = "L";
		subject.LocationIdentifier = "u";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.EquipmentInitial = "5";
			subject.EquipmentNumber = "5";
		}
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "D";
			subject.LocationIdentifier = "u";
		}
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "5h";
			subject.StateOrProvinceCode = "5s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Hk", true)]
	public void Validation_RequiredEquipmentDescriptionCode(string equipmentDescriptionCode, bool isValidExpected)
	{
		var subject = new GR4_LoadingCluster();
		//Required fields
		subject.ConfigurationTypeCode = "c";
		subject.EquipmentUseCode = "3";
		//Test Parameters
		subject.EquipmentDescriptionCode = equipmentDescriptionCode;
		//At Least one
		subject.ReferenceIdentification = "L";
		subject.LocationIdentifier = "u";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.EquipmentInitial = "5";
			subject.EquipmentNumber = "5";
		}
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "D";
			subject.LocationIdentifier = "u";
		}
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "5h";
			subject.StateOrProvinceCode = "5s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredEquipmentUseCode(string equipmentUseCode, bool isValidExpected)
	{
		var subject = new GR4_LoadingCluster();
		//Required fields
		subject.ConfigurationTypeCode = "c";
		subject.EquipmentDescriptionCode = "Hk";
		//Test Parameters
		subject.EquipmentUseCode = equipmentUseCode;
		//At Least one
		subject.ReferenceIdentification = "L";
		subject.LocationIdentifier = "u";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.EquipmentInitial = "5";
			subject.EquipmentNumber = "5";
		}
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "D";
			subject.LocationIdentifier = "u";
		}
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "5h";
			subject.StateOrProvinceCode = "5s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("L", "5", true)]
	[InlineData("L", "", true)]
	[InlineData("", "5", true)]
	public void Validation_AtLeastOneReferenceIdentification(string referenceIdentification, string equipmentInitial, bool isValidExpected)
	{
		var subject = new GR4_LoadingCluster();
		//Required fields
		subject.ConfigurationTypeCode = "c";
		subject.EquipmentDescriptionCode = "Hk";
		subject.EquipmentUseCode = "3";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		subject.EquipmentInitial = equipmentInitial;
		//At Least one
		subject.LocationIdentifier = "u";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.EquipmentInitial = "5";
			subject.EquipmentNumber = "5";
		}
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "D";
			subject.LocationIdentifier = "u";
		}
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "5h";
			subject.StateOrProvinceCode = "5s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("5", "5", true)]
	[InlineData("5", "", false)]
	[InlineData("", "5", false)]
	public void Validation_AllAreRequiredEquipmentInitial(string equipmentInitial, string equipmentNumber, bool isValidExpected)
	{
		var subject = new GR4_LoadingCluster();
		//Required fields
		subject.ConfigurationTypeCode = "c";
		subject.EquipmentDescriptionCode = "Hk";
		subject.EquipmentUseCode = "3";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		subject.EquipmentNumber = equipmentNumber;
		//At Least one
		subject.ReferenceIdentification = "L";
		subject.LocationIdentifier = "u";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "D";
			subject.LocationIdentifier = "u";
		}
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "5h";
			subject.StateOrProvinceCode = "5s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("D", "u", true)]
	[InlineData("D", "", false)]
	[InlineData("", "u", false)]
	public void Validation_AllAreRequiredLocationQualifier(string locationQualifier, string locationIdentifier, bool isValidExpected)
	{
		var subject = new GR4_LoadingCluster();
		//Required fields
		subject.ConfigurationTypeCode = "c";
		subject.EquipmentDescriptionCode = "Hk";
		subject.EquipmentUseCode = "3";
		//Test Parameters
		subject.LocationQualifier = locationQualifier;
		subject.LocationIdentifier = locationIdentifier;
		//At Least one
		subject.ReferenceIdentification = "L";
		subject.CityName = "5h";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.EquipmentInitial = "5";
			subject.EquipmentNumber = "5";
		}
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "5h";
			subject.StateOrProvinceCode = "5s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("u", "5h", true)]
	[InlineData("u", "", true)]
	[InlineData("", "5h", true)]
	public void Validation_AtLeastOneLocationIdentifier(string locationIdentifier, string cityName, bool isValidExpected)
	{
		var subject = new GR4_LoadingCluster();
		//Required fields
		subject.ConfigurationTypeCode = "c";
		subject.EquipmentDescriptionCode = "Hk";
		subject.EquipmentUseCode = "3";
		//Test Parameters
		subject.LocationIdentifier = locationIdentifier;
		subject.CityName = cityName;
		//At Least one
		subject.ReferenceIdentification = "L";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.EquipmentInitial = "5";
			subject.EquipmentNumber = "5";
		}
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "D";
			subject.LocationIdentifier = "u";
		}
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "5h";
			subject.StateOrProvinceCode = "5s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("5h", "5s", true)]
	[InlineData("5h", "", false)]
	[InlineData("", "5s", false)]
	public void Validation_AllAreRequiredCityName(string cityName, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new GR4_LoadingCluster();
		//Required fields
		subject.ConfigurationTypeCode = "c";
		subject.EquipmentDescriptionCode = "Hk";
		subject.EquipmentUseCode = "3";
		//Test Parameters
		subject.CityName = cityName;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		//At Least one
		subject.ReferenceIdentification = "L";
		subject.LocationIdentifier = "u";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.EquipmentInitial = "5";
			subject.EquipmentNumber = "5";
		}
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "D";
			subject.LocationIdentifier = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("mQ", "5s", true)]
	[InlineData("mQ", "", false)]
	[InlineData("", "5s", true)]
	public void Validation_ARequiresBCountryCode(string countryCode, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new GR4_LoadingCluster();
		//Required fields
		subject.ConfigurationTypeCode = "c";
		subject.EquipmentDescriptionCode = "Hk";
		subject.EquipmentUseCode = "3";
		//Test Parameters
		subject.CountryCode = countryCode;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		//At Least one
		subject.ReferenceIdentification = "L";
		subject.LocationIdentifier = "u";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.EquipmentInitial = "5";
			subject.EquipmentNumber = "5";
		}
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "D";
			subject.LocationIdentifier = "u";
		}
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "5h";
			subject.StateOrProvinceCode = "5s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

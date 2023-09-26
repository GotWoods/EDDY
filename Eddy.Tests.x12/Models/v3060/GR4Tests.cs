using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class GR4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GR4*s*Wb*s*P*U*M*2*t*br*BK*Ue";

		var expected = new GR4_LoadingCluster()
		{
			ConfigurationTypeCode = "s",
			EquipmentDescriptionCode = "Wb",
			EquipmentUseCode = "s",
			ReferenceIdentification = "P",
			EquipmentInitial = "U",
			EquipmentNumber = "M",
			LocationQualifier = "2",
			LocationIdentifier = "t",
			CityName = "br",
			StateOrProvinceCode = "BK",
			CountryCode = "Ue",
		};

		var actual = Map.MapObject<GR4_LoadingCluster>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredConfigurationTypeCode(string configurationTypeCode, bool isValidExpected)
	{
		var subject = new GR4_LoadingCluster();
		//Required fields
		subject.EquipmentDescriptionCode = "Wb";
		subject.EquipmentUseCode = "s";
		//Test Parameters
		subject.ConfigurationTypeCode = configurationTypeCode;
		//At Least one
		subject.ReferenceIdentification = "P";
		subject.LocationIdentifier = "t";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.EquipmentInitial = "U";
			subject.EquipmentNumber = "M";
		}
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "2";
			subject.LocationIdentifier = "t";
		}
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "br";
			subject.StateOrProvinceCode = "BK";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Wb", true)]
	public void Validation_RequiredEquipmentDescriptionCode(string equipmentDescriptionCode, bool isValidExpected)
	{
		var subject = new GR4_LoadingCluster();
		//Required fields
		subject.ConfigurationTypeCode = "s";
		subject.EquipmentUseCode = "s";
		//Test Parameters
		subject.EquipmentDescriptionCode = equipmentDescriptionCode;
		//At Least one
		subject.ReferenceIdentification = "P";
		subject.LocationIdentifier = "t";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.EquipmentInitial = "U";
			subject.EquipmentNumber = "M";
		}
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "2";
			subject.LocationIdentifier = "t";
		}
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "br";
			subject.StateOrProvinceCode = "BK";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredEquipmentUseCode(string equipmentUseCode, bool isValidExpected)
	{
		var subject = new GR4_LoadingCluster();
		//Required fields
		subject.ConfigurationTypeCode = "s";
		subject.EquipmentDescriptionCode = "Wb";
		//Test Parameters
		subject.EquipmentUseCode = equipmentUseCode;
		//At Least one
		subject.ReferenceIdentification = "P";
		subject.LocationIdentifier = "t";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.EquipmentInitial = "U";
			subject.EquipmentNumber = "M";
		}
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "2";
			subject.LocationIdentifier = "t";
		}
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "br";
			subject.StateOrProvinceCode = "BK";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("P", "U", true)]
	[InlineData("P", "", true)]
	[InlineData("", "U", true)]
	public void Validation_AtLeastOneReferenceIdentification(string referenceIdentification, string equipmentInitial, bool isValidExpected)
	{
		var subject = new GR4_LoadingCluster();
		//Required fields
		subject.ConfigurationTypeCode = "s";
		subject.EquipmentDescriptionCode = "Wb";
		subject.EquipmentUseCode = "s";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		subject.EquipmentInitial = equipmentInitial;
		//At Least one
		subject.LocationIdentifier = "t";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.EquipmentInitial = "U";
			subject.EquipmentNumber = "M";
		}
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "2";
			subject.LocationIdentifier = "t";
		}
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "br";
			subject.StateOrProvinceCode = "BK";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("U", "M", true)]
	[InlineData("U", "", false)]
	[InlineData("", "M", false)]
	public void Validation_AllAreRequiredEquipmentInitial(string equipmentInitial, string equipmentNumber, bool isValidExpected)
	{
		var subject = new GR4_LoadingCluster();
		//Required fields
		subject.ConfigurationTypeCode = "s";
		subject.EquipmentDescriptionCode = "Wb";
		subject.EquipmentUseCode = "s";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		subject.EquipmentNumber = equipmentNumber;
		//At Least one
		subject.ReferenceIdentification = "P";
		subject.LocationIdentifier = "t";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "2";
			subject.LocationIdentifier = "t";
		}
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "br";
			subject.StateOrProvinceCode = "BK";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("2", "t", true)]
	[InlineData("2", "", false)]
	[InlineData("", "t", false)]
	public void Validation_AllAreRequiredLocationQualifier(string locationQualifier, string locationIdentifier, bool isValidExpected)
	{
		var subject = new GR4_LoadingCluster();
		//Required fields
		subject.ConfigurationTypeCode = "s";
		subject.EquipmentDescriptionCode = "Wb";
		subject.EquipmentUseCode = "s";
		//Test Parameters
		subject.LocationQualifier = locationQualifier;
		subject.LocationIdentifier = locationIdentifier;
		//At Least one
		subject.ReferenceIdentification = "P";
		subject.CityName = "br";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.EquipmentInitial = "U";
			subject.EquipmentNumber = "M";
		}
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "br";
			subject.StateOrProvinceCode = "BK";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("t", "br", true)]
	[InlineData("t", "", true)]
	[InlineData("", "br", true)]
	public void Validation_AtLeastOneLocationIdentifier(string locationIdentifier, string cityName, bool isValidExpected)
	{
		var subject = new GR4_LoadingCluster();
		//Required fields
		subject.ConfigurationTypeCode = "s";
		subject.EquipmentDescriptionCode = "Wb";
		subject.EquipmentUseCode = "s";
		//Test Parameters
		subject.LocationIdentifier = locationIdentifier;
		subject.CityName = cityName;
		//At Least one
		subject.ReferenceIdentification = "P";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.EquipmentInitial = "U";
			subject.EquipmentNumber = "M";
		}
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "2";
			subject.LocationIdentifier = "t";
		}
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "br";
			subject.StateOrProvinceCode = "BK";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("br", "BK", true)]
	[InlineData("br", "", false)]
	[InlineData("", "BK", false)]
	public void Validation_AllAreRequiredCityName(string cityName, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new GR4_LoadingCluster();
		//Required fields
		subject.ConfigurationTypeCode = "s";
		subject.EquipmentDescriptionCode = "Wb";
		subject.EquipmentUseCode = "s";
		//Test Parameters
		subject.CityName = cityName;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		//At Least one
		subject.ReferenceIdentification = "P";
		subject.LocationIdentifier = "t";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.EquipmentInitial = "U";
			subject.EquipmentNumber = "M";
		}
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "2";
			subject.LocationIdentifier = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ue", "BK", true)]
	[InlineData("Ue", "", false)]
	[InlineData("", "BK", true)]
	public void Validation_ARequiresBCountryCode(string countryCode, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new GR4_LoadingCluster();
		//Required fields
		subject.ConfigurationTypeCode = "s";
		subject.EquipmentDescriptionCode = "Wb";
		subject.EquipmentUseCode = "s";
		//Test Parameters
		subject.CountryCode = countryCode;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		//At Least one
		subject.ReferenceIdentification = "P";
		subject.LocationIdentifier = "t";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.EquipmentInitial = "U";
			subject.EquipmentNumber = "M";
		}
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "2";
			subject.LocationIdentifier = "t";
		}
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "br";
			subject.StateOrProvinceCode = "BK";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

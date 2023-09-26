using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class GR4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GR4*r*0G*u*L*0*S*z*O*ST*te*DT";

		var expected = new GR4_LoadingCluster()
		{
			ConfigurationTypeCode = "r",
			EquipmentDescriptionCode = "0G",
			EquipmentUseCode = "u",
			ReferenceIdentification = "L",
			EquipmentInitial = "0",
			EquipmentNumber = "S",
			LocationQualifier = "z",
			LocationIdentifier = "O",
			CityName = "ST",
			StateOrProvinceCode = "te",
			CountryCode = "DT",
		};

		var actual = Map.MapObject<GR4_LoadingCluster>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredConfigurationTypeCode(string configurationTypeCode, bool isValidExpected)
	{
		var subject = new GR4_LoadingCluster();
		//Required fields
		subject.EquipmentDescriptionCode = "0G";
		subject.EquipmentUseCode = "u";
		//Test Parameters
		subject.ConfigurationTypeCode = configurationTypeCode;
		//At Least one
		subject.ReferenceIdentification = "L";
		subject.LocationIdentifier = "O";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.EquipmentInitial = "0";
			subject.EquipmentNumber = "S";
		}
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "z";
			subject.LocationIdentifier = "O";
		}
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "ST";
			subject.StateOrProvinceCode = "te";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0G", true)]
	public void Validation_RequiredEquipmentDescriptionCode(string equipmentDescriptionCode, bool isValidExpected)
	{
		var subject = new GR4_LoadingCluster();
		//Required fields
		subject.ConfigurationTypeCode = "r";
		subject.EquipmentUseCode = "u";
		//Test Parameters
		subject.EquipmentDescriptionCode = equipmentDescriptionCode;
		//At Least one
		subject.ReferenceIdentification = "L";
		subject.LocationIdentifier = "O";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.EquipmentInitial = "0";
			subject.EquipmentNumber = "S";
		}
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "z";
			subject.LocationIdentifier = "O";
		}
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "ST";
			subject.StateOrProvinceCode = "te";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredEquipmentUseCode(string equipmentUseCode, bool isValidExpected)
	{
		var subject = new GR4_LoadingCluster();
		//Required fields
		subject.ConfigurationTypeCode = "r";
		subject.EquipmentDescriptionCode = "0G";
		//Test Parameters
		subject.EquipmentUseCode = equipmentUseCode;
		//At Least one
		subject.ReferenceIdentification = "L";
		subject.LocationIdentifier = "O";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.EquipmentInitial = "0";
			subject.EquipmentNumber = "S";
		}
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "z";
			subject.LocationIdentifier = "O";
		}
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "ST";
			subject.StateOrProvinceCode = "te";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("L", "0", true)]
	[InlineData("L", "", true)]
	[InlineData("", "0", true)]
	public void Validation_AtLeastOneReferenceIdentification(string referenceIdentification, string equipmentInitial, bool isValidExpected)
	{
		var subject = new GR4_LoadingCluster();
		//Required fields
		subject.ConfigurationTypeCode = "r";
		subject.EquipmentDescriptionCode = "0G";
		subject.EquipmentUseCode = "u";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		subject.EquipmentInitial = equipmentInitial;
		//At Least one
		subject.LocationIdentifier = "O";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.EquipmentInitial = "0";
			subject.EquipmentNumber = "S";
		}
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "z";
			subject.LocationIdentifier = "O";
		}
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "ST";
			subject.StateOrProvinceCode = "te";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("0", "S", true)]
	[InlineData("0", "", false)]
	[InlineData("", "S", false)]
	public void Validation_AllAreRequiredEquipmentInitial(string equipmentInitial, string equipmentNumber, bool isValidExpected)
	{
		var subject = new GR4_LoadingCluster();
		//Required fields
		subject.ConfigurationTypeCode = "r";
		subject.EquipmentDescriptionCode = "0G";
		subject.EquipmentUseCode = "u";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		subject.EquipmentNumber = equipmentNumber;
		//At Least one
		subject.ReferenceIdentification = "L";
		subject.LocationIdentifier = "O";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "z";
			subject.LocationIdentifier = "O";
		}
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "ST";
			subject.StateOrProvinceCode = "te";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("z", "O", true)]
	[InlineData("z", "", false)]
	[InlineData("", "O", false)]
	public void Validation_AllAreRequiredLocationQualifier(string locationQualifier, string locationIdentifier, bool isValidExpected)
	{
		var subject = new GR4_LoadingCluster();
		//Required fields
		subject.ConfigurationTypeCode = "r";
		subject.EquipmentDescriptionCode = "0G";
		subject.EquipmentUseCode = "u";
		//Test Parameters
		subject.LocationQualifier = locationQualifier;
		subject.LocationIdentifier = locationIdentifier;
		//At Least one
		subject.ReferenceIdentification = "L";
		subject.CityName = "ST";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.EquipmentInitial = "0";
			subject.EquipmentNumber = "S";
		}
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "ST";
			subject.StateOrProvinceCode = "te";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("O", "ST", true)]
	[InlineData("O", "", true)]
	[InlineData("", "ST", true)]
	public void Validation_AtLeastOneLocationIdentifier(string locationIdentifier, string cityName, bool isValidExpected)
	{
		var subject = new GR4_LoadingCluster();
		//Required fields
		subject.ConfigurationTypeCode = "r";
		subject.EquipmentDescriptionCode = "0G";
		subject.EquipmentUseCode = "u";
		//Test Parameters
		subject.LocationIdentifier = locationIdentifier;
		subject.CityName = cityName;
		//At Least one
		subject.ReferenceIdentification = "L";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.EquipmentInitial = "0";
			subject.EquipmentNumber = "S";
		}
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "z";
			subject.LocationIdentifier = "O";
		}
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "ST";
			subject.StateOrProvinceCode = "te";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ST", "te", true)]
	[InlineData("ST", "", false)]
	[InlineData("", "te", false)]
	public void Validation_AllAreRequiredCityName(string cityName, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new GR4_LoadingCluster();
		//Required fields
		subject.ConfigurationTypeCode = "r";
		subject.EquipmentDescriptionCode = "0G";
		subject.EquipmentUseCode = "u";
		//Test Parameters
		subject.CityName = cityName;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		//At Least one
		subject.ReferenceIdentification = "L";
		subject.LocationIdentifier = "O";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.EquipmentInitial = "0";
			subject.EquipmentNumber = "S";
		}
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "z";
			subject.LocationIdentifier = "O";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("DT", "te", true)]
	[InlineData("DT", "", false)]
	[InlineData("", "te", true)]
	public void Validation_ARequiresBCountryCode(string countryCode, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new GR4_LoadingCluster();
		//Required fields
		subject.ConfigurationTypeCode = "r";
		subject.EquipmentDescriptionCode = "0G";
		subject.EquipmentUseCode = "u";
		//Test Parameters
		subject.CountryCode = countryCode;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		//At Least one
		subject.ReferenceIdentification = "L";
		subject.LocationIdentifier = "O";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.EquipmentInitial = "0";
			subject.EquipmentNumber = "S";
		}
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "z";
			subject.LocationIdentifier = "O";
		}
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "ST";
			subject.StateOrProvinceCode = "te";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

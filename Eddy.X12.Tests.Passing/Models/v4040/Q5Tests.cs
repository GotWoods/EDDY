using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class Q5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Q5*E*WVjkObto*acoN*HS*BIR*EZ*Wp*dj*J*U*qN*v*Q*5P*7*d*7*c";

		var expected = new Q5_StatusDetails()
		{
			ShipmentStatusCode = "E",
			Date = "WVjkObto",
			Time = "acoN",
			TimeCode = "HS",
			StatusReasonCode = "BIR",
			CityName = "EZ",
			StateOrProvinceCode = "Wp",
			CountryCode = "dj",
			EquipmentInitial = "J",
			EquipmentNumber = "U",
			ReferenceIdentificationQualifier = "qN",
			ReferenceIdentification = "v",
			DirectionIdentifierCode = "Q",
			ReferenceIdentificationQualifier2 = "5P",
			ReferenceIdentification2 = "7",
			DirectionIdentifierCode2 = "d",
			Percent = 7,
			PickUpOrDeliveryCode = "c",
		};

		var actual = Map.MapObject<Q5_StatusDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("acoN", "HS", true)]
	[InlineData("acoN", "", false)]
	[InlineData("", "HS", false)]
	public void Validation_AllAreRequiredTime(string time, string timeCode, bool isValidExpected)
	{
		var subject = new Q5_StatusDetails();
		subject.Time = time;
		subject.TimeCode = timeCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "qN";
			subject.ReferenceIdentification = "v";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "5P";
			subject.ReferenceIdentification2 = "7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Wp", "EZ", true)]
	[InlineData("Wp", "", false)]
	[InlineData("", "EZ", true)]
	public void Validation_ARequiresBStateOrProvinceCode(string stateOrProvinceCode, string cityName, bool isValidExpected)
	{
		var subject = new Q5_StatusDetails();
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CityName = cityName;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Time) || !string.IsNullOrEmpty(subject.Time) || !string.IsNullOrEmpty(subject.TimeCode))
		{
			subject.Time = "acoN";
			subject.TimeCode = "HS";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "qN";
			subject.ReferenceIdentification = "v";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "5P";
			subject.ReferenceIdentification2 = "7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("qN", "v", true)]
	[InlineData("qN", "", false)]
	[InlineData("", "v", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new Q5_StatusDetails();
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Time) || !string.IsNullOrEmpty(subject.Time) || !string.IsNullOrEmpty(subject.TimeCode))
		{
			subject.Time = "acoN";
			subject.TimeCode = "HS";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "5P";
			subject.ReferenceIdentification2 = "7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Q", "v", true)]
	[InlineData("Q", "", false)]
	[InlineData("", "v", true)]
	public void Validation_ARequiresBDirectionIdentifierCode(string directionIdentifierCode, string referenceIdentification, bool isValidExpected)
	{
		var subject = new Q5_StatusDetails();
		subject.DirectionIdentifierCode = directionIdentifierCode;
		subject.ReferenceIdentification = referenceIdentification;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Time) || !string.IsNullOrEmpty(subject.Time) || !string.IsNullOrEmpty(subject.TimeCode))
		{
			subject.Time = "acoN";
			subject.TimeCode = "HS";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "qN";
			subject.ReferenceIdentification = "v";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "5P";
			subject.ReferenceIdentification2 = "7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("5P", "7", true)]
	[InlineData("5P", "", false)]
	[InlineData("", "7", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier2(string referenceIdentificationQualifier2, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new Q5_StatusDetails();
		subject.ReferenceIdentificationQualifier2 = referenceIdentificationQualifier2;
		subject.ReferenceIdentification2 = referenceIdentification2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Time) || !string.IsNullOrEmpty(subject.Time) || !string.IsNullOrEmpty(subject.TimeCode))
		{
			subject.Time = "acoN";
			subject.TimeCode = "HS";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "qN";
			subject.ReferenceIdentification = "v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("d", "7", true)]
	[InlineData("d", "", false)]
	[InlineData("", "7", true)]
	public void Validation_ARequiresBDirectionIdentifierCode2(string directionIdentifierCode2, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new Q5_StatusDetails();
		subject.DirectionIdentifierCode2 = directionIdentifierCode2;
		subject.ReferenceIdentification2 = referenceIdentification2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Time) || !string.IsNullOrEmpty(subject.Time) || !string.IsNullOrEmpty(subject.TimeCode))
		{
			subject.Time = "acoN";
			subject.TimeCode = "HS";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "qN";
			subject.ReferenceIdentification = "v";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "5P";
			subject.ReferenceIdentification2 = "7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

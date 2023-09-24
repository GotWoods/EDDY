using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class Q5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Q5*N*VXJExwck*Bvla*Yf*uHx*fi*Bc*jz*H*F*L9*3*v*Ui*v*8*7*R";

		var expected = new Q5_StatusDetails()
		{
			ShipmentStatusCode = "N",
			Date = "VXJExwck",
			Time = "Bvla",
			TimeCode = "Yf",
			StatusReasonCode = "uHx",
			CityName = "fi",
			StateOrProvinceCode = "Bc",
			CountryCode = "jz",
			EquipmentInitial = "H",
			EquipmentNumber = "F",
			ReferenceIdentificationQualifier = "L9",
			ReferenceIdentification = "3",
			DirectionIdentifierCode = "v",
			ReferenceIdentificationQualifier2 = "Ui",
			ReferenceIdentification2 = "v",
			DirectionIdentifierCode2 = "8",
			PercentageAsDecimal = 7,
			PickupOrDeliveryCode = "R",
		};

		var actual = Map.MapObject<Q5_StatusDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Bvla", "Yf", true)]
	[InlineData("Bvla", "", false)]
	[InlineData("", "Yf", false)]
	public void Validation_AllAreRequiredTime(string time, string timeCode, bool isValidExpected)
	{
		var subject = new Q5_StatusDetails();
		subject.Time = time;
		subject.TimeCode = timeCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "L9";
			subject.ReferenceIdentification = "3";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "Ui";
			subject.ReferenceIdentification2 = "v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Bc", "fi", true)]
	[InlineData("Bc", "", false)]
	[InlineData("", "fi", true)]
	public void Validation_ARequiresBStateOrProvinceCode(string stateOrProvinceCode, string cityName, bool isValidExpected)
	{
		var subject = new Q5_StatusDetails();
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CityName = cityName;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Time) || !string.IsNullOrEmpty(subject.Time) || !string.IsNullOrEmpty(subject.TimeCode))
		{
			subject.Time = "Bvla";
			subject.TimeCode = "Yf";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "L9";
			subject.ReferenceIdentification = "3";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "Ui";
			subject.ReferenceIdentification2 = "v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("L9", "3", true)]
	[InlineData("L9", "", false)]
	[InlineData("", "3", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new Q5_StatusDetails();
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Time) || !string.IsNullOrEmpty(subject.Time) || !string.IsNullOrEmpty(subject.TimeCode))
		{
			subject.Time = "Bvla";
			subject.TimeCode = "Yf";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "Ui";
			subject.ReferenceIdentification2 = "v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("v", "3", true)]
	[InlineData("v", "", false)]
	[InlineData("", "3", true)]
	public void Validation_ARequiresBDirectionIdentifierCode(string directionIdentifierCode, string referenceIdentification, bool isValidExpected)
	{
		var subject = new Q5_StatusDetails();
		subject.DirectionIdentifierCode = directionIdentifierCode;
		subject.ReferenceIdentification = referenceIdentification;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Time) || !string.IsNullOrEmpty(subject.Time) || !string.IsNullOrEmpty(subject.TimeCode))
		{
			subject.Time = "Bvla";
			subject.TimeCode = "Yf";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "L9";
			subject.ReferenceIdentification = "3";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "Ui";
			subject.ReferenceIdentification2 = "v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ui", "v", true)]
	[InlineData("Ui", "", false)]
	[InlineData("", "v", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier2(string referenceIdentificationQualifier2, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new Q5_StatusDetails();
		subject.ReferenceIdentificationQualifier2 = referenceIdentificationQualifier2;
		subject.ReferenceIdentification2 = referenceIdentification2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Time) || !string.IsNullOrEmpty(subject.Time) || !string.IsNullOrEmpty(subject.TimeCode))
		{
			subject.Time = "Bvla";
			subject.TimeCode = "Yf";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "L9";
			subject.ReferenceIdentification = "3";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("8", "v", true)]
	[InlineData("8", "", false)]
	[InlineData("", "v", true)]
	public void Validation_ARequiresBDirectionIdentifierCode2(string directionIdentifierCode2, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new Q5_StatusDetails();
		subject.DirectionIdentifierCode2 = directionIdentifierCode2;
		subject.ReferenceIdentification2 = referenceIdentification2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Time) || !string.IsNullOrEmpty(subject.Time) || !string.IsNullOrEmpty(subject.TimeCode))
		{
			subject.Time = "Bvla";
			subject.TimeCode = "Yf";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "L9";
			subject.ReferenceIdentification = "3";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "Ui";
			subject.ReferenceIdentification2 = "v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

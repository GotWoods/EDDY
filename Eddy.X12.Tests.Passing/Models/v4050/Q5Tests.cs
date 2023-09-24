using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class Q5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Q5*m*LLwwq5rR*Ap6X*8y*uj1*Vh*OE*Y5*d*S*pG*O*c*Hn*A*8*4*W";

		var expected = new Q5_StatusDetails()
		{
			ShipmentStatusCode = "m",
			Date = "LLwwq5rR",
			Time = "Ap6X",
			TimeCode = "8y",
			StatusReasonCode = "uj1",
			CityName = "Vh",
			StateOrProvinceCode = "OE",
			CountryCode = "Y5",
			EquipmentInitial = "d",
			EquipmentNumber = "S",
			ReferenceIdentificationQualifier = "pG",
			ReferenceIdentification = "O",
			DirectionIdentifierCode = "c",
			ReferenceIdentificationQualifier2 = "Hn",
			ReferenceIdentification2 = "A",
			DirectionIdentifierCode2 = "8",
			PercentageAsDecimal = 4,
			PickUpOrDeliveryCode = "W",
		};

		var actual = Map.MapObject<Q5_StatusDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ap6X", "8y", true)]
	[InlineData("Ap6X", "", false)]
	[InlineData("", "8y", false)]
	public void Validation_AllAreRequiredTime(string time, string timeCode, bool isValidExpected)
	{
		var subject = new Q5_StatusDetails();
		subject.Time = time;
		subject.TimeCode = timeCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "pG";
			subject.ReferenceIdentification = "O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "Hn";
			subject.ReferenceIdentification2 = "A";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("OE", "Vh", true)]
	[InlineData("OE", "", false)]
	[InlineData("", "Vh", true)]
	public void Validation_ARequiresBStateOrProvinceCode(string stateOrProvinceCode, string cityName, bool isValidExpected)
	{
		var subject = new Q5_StatusDetails();
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CityName = cityName;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Time) || !string.IsNullOrEmpty(subject.Time) || !string.IsNullOrEmpty(subject.TimeCode))
		{
			subject.Time = "Ap6X";
			subject.TimeCode = "8y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "pG";
			subject.ReferenceIdentification = "O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "Hn";
			subject.ReferenceIdentification2 = "A";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("pG", "O", true)]
	[InlineData("pG", "", false)]
	[InlineData("", "O", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new Q5_StatusDetails();
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Time) || !string.IsNullOrEmpty(subject.Time) || !string.IsNullOrEmpty(subject.TimeCode))
		{
			subject.Time = "Ap6X";
			subject.TimeCode = "8y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "Hn";
			subject.ReferenceIdentification2 = "A";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("c", "O", true)]
	[InlineData("c", "", false)]
	[InlineData("", "O", true)]
	public void Validation_ARequiresBDirectionIdentifierCode(string directionIdentifierCode, string referenceIdentification, bool isValidExpected)
	{
		var subject = new Q5_StatusDetails();
		subject.DirectionIdentifierCode = directionIdentifierCode;
		subject.ReferenceIdentification = referenceIdentification;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Time) || !string.IsNullOrEmpty(subject.Time) || !string.IsNullOrEmpty(subject.TimeCode))
		{
			subject.Time = "Ap6X";
			subject.TimeCode = "8y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "pG";
			subject.ReferenceIdentification = "O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "Hn";
			subject.ReferenceIdentification2 = "A";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Hn", "A", true)]
	[InlineData("Hn", "", false)]
	[InlineData("", "A", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier2(string referenceIdentificationQualifier2, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new Q5_StatusDetails();
		subject.ReferenceIdentificationQualifier2 = referenceIdentificationQualifier2;
		subject.ReferenceIdentification2 = referenceIdentification2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Time) || !string.IsNullOrEmpty(subject.Time) || !string.IsNullOrEmpty(subject.TimeCode))
		{
			subject.Time = "Ap6X";
			subject.TimeCode = "8y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "pG";
			subject.ReferenceIdentification = "O";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("8", "A", true)]
	[InlineData("8", "", false)]
	[InlineData("", "A", true)]
	public void Validation_ARequiresBDirectionIdentifierCode2(string directionIdentifierCode2, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new Q5_StatusDetails();
		subject.DirectionIdentifierCode2 = directionIdentifierCode2;
		subject.ReferenceIdentification2 = referenceIdentification2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Time) || !string.IsNullOrEmpty(subject.Time) || !string.IsNullOrEmpty(subject.TimeCode))
		{
			subject.Time = "Ap6X";
			subject.TimeCode = "8y";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "pG";
			subject.ReferenceIdentification = "O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "Hn";
			subject.ReferenceIdentification2 = "A";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

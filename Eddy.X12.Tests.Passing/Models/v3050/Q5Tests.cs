using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class Q5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Q5*4*44r0OG*hKre*QF*gf1*P5*0X*FP*3*v*z8*0*a*BX*1*c*2*Q";

		var expected = new Q5_StatusDetails()
		{
			StatusCode = "4",
			Date = "44r0OG",
			Time = "hKre",
			TimeCode = "QF",
			StatusReasonCode = "gf1",
			CityName = "P5",
			StateOrProvinceCode = "0X",
			CountryCode = "FP",
			EquipmentInitial = "3",
			EquipmentNumber = "v",
			ReferenceNumberQualifier = "z8",
			ReferenceNumber = "0",
			DirectionIdentifierCode = "a",
			ReferenceNumberQualifier2 = "BX",
			ReferenceNumber2 = "1",
			DirectionIdentifierCode2 = "c",
			Percent = 2,
			PickUpOrDeliveryCode = "Q",
		};

		var actual = Map.MapObject<Q5_StatusDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("0X", "P5", true)]
	[InlineData("0X", "", false)]
	[InlineData("", "P5", true)]
	public void Validation_ARequiresBStateOrProvinceCode(string stateOrProvinceCode, string cityName, bool isValidExpected)
	{
		var subject = new Q5_StatusDetails();
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CityName = cityName;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "z8";
			subject.ReferenceNumber = "0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "BX";
			subject.ReferenceNumber2 = "1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("z8", "0", true)]
	[InlineData("z8", "", false)]
	[InlineData("", "0", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new Q5_StatusDetails();
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "BX";
			subject.ReferenceNumber2 = "1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("a", "0", true)]
	[InlineData("a", "", false)]
	[InlineData("", "0", true)]
	public void Validation_ARequiresBDirectionIdentifierCode(string directionIdentifierCode, string referenceNumber, bool isValidExpected)
	{
		var subject = new Q5_StatusDetails();
		subject.DirectionIdentifierCode = directionIdentifierCode;
		subject.ReferenceNumber = referenceNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "z8";
			subject.ReferenceNumber = "0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "BX";
			subject.ReferenceNumber2 = "1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("BX", "1", true)]
	[InlineData("BX", "", false)]
	[InlineData("", "1", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier2(string referenceNumberQualifier2, string referenceNumber2, bool isValidExpected)
	{
		var subject = new Q5_StatusDetails();
		subject.ReferenceNumberQualifier2 = referenceNumberQualifier2;
		subject.ReferenceNumber2 = referenceNumber2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "z8";
			subject.ReferenceNumber = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("c", "1", true)]
	[InlineData("c", "", false)]
	[InlineData("", "1", true)]
	public void Validation_ARequiresBDirectionIdentifierCode2(string directionIdentifierCode2, string referenceNumber2, bool isValidExpected)
	{
		var subject = new Q5_StatusDetails();
		subject.DirectionIdentifierCode2 = directionIdentifierCode2;
		subject.ReferenceNumber2 = referenceNumber2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "z8";
			subject.ReferenceNumber = "0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "BX";
			subject.ReferenceNumber2 = "1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

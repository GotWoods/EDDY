using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class M15Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M15*S*Z*018udU*t*SR*iZuR*Tr";

		var expected = new M15_MasterInBondArrivalDetails()
		{
			StatusCode = "S",
			ReferenceNumber = "Z",
			Date = "018udU",
			LocationIdentifier = "t",
			StandardCarrierAlphaCode = "SR",
			Time = "iZuR",
			SealNumber = "Tr",
		};

		var actual = Map.MapObject<M15_MasterInBondArrivalDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredStatusCode(string statusCode, bool isValidExpected)
	{
		var subject = new M15_MasterInBondArrivalDetails();
		subject.ReferenceNumber = "Z";
		subject.Date = "018udU";
		subject.LocationIdentifier = "t";
		subject.Time = "iZuR";
		subject.StatusCode = statusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new M15_MasterInBondArrivalDetails();
		subject.StatusCode = "S";
		subject.Date = "018udU";
		subject.LocationIdentifier = "t";
		subject.Time = "iZuR";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("018udU", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new M15_MasterInBondArrivalDetails();
		subject.StatusCode = "S";
		subject.ReferenceNumber = "Z";
		subject.LocationIdentifier = "t";
		subject.Time = "iZuR";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new M15_MasterInBondArrivalDetails();
		subject.StatusCode = "S";
		subject.ReferenceNumber = "Z";
		subject.Date = "018udU";
		subject.Time = "iZuR";
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("iZuR", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new M15_MasterInBondArrivalDetails();
		subject.StatusCode = "S";
		subject.ReferenceNumber = "Z";
		subject.Date = "018udU";
		subject.LocationIdentifier = "t";
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

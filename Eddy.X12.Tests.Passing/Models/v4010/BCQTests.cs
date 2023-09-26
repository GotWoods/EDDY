using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class BCQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCQ*kG*NCQTFMhw*03Tz*WD*T*AT";

		var expected = new BCQ_BeginningSegmentForShippersCarOrder()
		{
			TransactionSetPurposeCode = "kG",
			Date = "NCQTFMhw",
			Time = "03Tz",
			ReferenceIdentificationQualifier = "WD",
			ReferenceIdentification = "T",
			StandardCarrierAlphaCode = "AT",
		};

		var actual = Map.MapObject<BCQ_BeginningSegmentForShippersCarOrder>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kG", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BCQ_BeginningSegmentForShippersCarOrder();
		//Required fields
		subject.Date = "NCQTFMhw";
		subject.Time = "03Tz";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "WD";
			subject.ReferenceIdentification = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("NCQTFMhw", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BCQ_BeginningSegmentForShippersCarOrder();
		//Required fields
		subject.TransactionSetPurposeCode = "kG";
		subject.Time = "03Tz";
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "WD";
			subject.ReferenceIdentification = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("03Tz", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new BCQ_BeginningSegmentForShippersCarOrder();
		//Required fields
		subject.TransactionSetPurposeCode = "kG";
		subject.Date = "NCQTFMhw";
		//Test Parameters
		subject.Time = time;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "WD";
			subject.ReferenceIdentification = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("WD", "T", true)]
	[InlineData("WD", "", false)]
	[InlineData("", "T", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new BCQ_BeginningSegmentForShippersCarOrder();
		//Required fields
		subject.TransactionSetPurposeCode = "kG";
		subject.Date = "NCQTFMhw";
		subject.Time = "03Tz";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

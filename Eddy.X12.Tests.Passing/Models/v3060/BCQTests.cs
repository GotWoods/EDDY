using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class BCQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCQ*bs*pD4vip*21Ws*SM*D*s1";

		var expected = new BCQ_BeginningSegmentForShippersCarOrder()
		{
			TransactionSetPurposeCode = "bs",
			Date = "pD4vip",
			Time = "21Ws",
			ReferenceIdentificationQualifier = "SM",
			ReferenceIdentification = "D",
			StandardCarrierAlphaCode = "s1",
		};

		var actual = Map.MapObject<BCQ_BeginningSegmentForShippersCarOrder>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bs", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BCQ_BeginningSegmentForShippersCarOrder();
		//Required fields
		subject.Date = "pD4vip";
		subject.Time = "21Ws";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "SM";
			subject.ReferenceIdentification = "D";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("pD4vip", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BCQ_BeginningSegmentForShippersCarOrder();
		//Required fields
		subject.TransactionSetPurposeCode = "bs";
		subject.Time = "21Ws";
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "SM";
			subject.ReferenceIdentification = "D";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("21Ws", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new BCQ_BeginningSegmentForShippersCarOrder();
		//Required fields
		subject.TransactionSetPurposeCode = "bs";
		subject.Date = "pD4vip";
		//Test Parameters
		subject.Time = time;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "SM";
			subject.ReferenceIdentification = "D";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("SM", "D", true)]
	[InlineData("SM", "", false)]
	[InlineData("", "D", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new BCQ_BeginningSegmentForShippersCarOrder();
		//Required fields
		subject.TransactionSetPurposeCode = "bs";
		subject.Date = "pD4vip";
		subject.Time = "21Ws";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

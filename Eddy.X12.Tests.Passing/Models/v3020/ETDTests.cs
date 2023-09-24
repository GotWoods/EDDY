using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class ETDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ETD*S*K*GO*2*f";

		var expected = new ETD_ExcessTransportationDetail()
		{
			ExcessTransportationReasonCode = "S",
			ExcessTransportationResponsibilityCode = "K",
			ReferenceNumberQualifier = "GO",
			ReferenceNumber = "2",
			ReturnableContainerFreightPaymentResponsibilityCode = "f",
		};

		var actual = Map.MapObject<ETD_ExcessTransportationDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredExcessTransportationReasonCode(string excessTransportationReasonCode, bool isValidExpected)
	{
		var subject = new ETD_ExcessTransportationDetail();
		subject.ExcessTransportationResponsibilityCode = "K";
		subject.ExcessTransportationReasonCode = excessTransportationReasonCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "GO";
			subject.ReferenceNumber = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredExcessTransportationResponsibilityCode(string excessTransportationResponsibilityCode, bool isValidExpected)
	{
		var subject = new ETD_ExcessTransportationDetail();
		subject.ExcessTransportationReasonCode = "S";
		subject.ExcessTransportationResponsibilityCode = excessTransportationResponsibilityCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "GO";
			subject.ReferenceNumber = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("GO", "2", true)]
	[InlineData("GO", "", false)]
	[InlineData("", "2", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new ETD_ExcessTransportationDetail();
		subject.ExcessTransportationReasonCode = "S";
		subject.ExcessTransportationResponsibilityCode = "K";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

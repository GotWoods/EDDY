using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class ETDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ETD*1*t*Bx*T*V";

		var expected = new ETD_ExcessTransportationDetail()
		{
			ExcessTransportationReasonCode = "1",
			ExcessTransportationResponsibilityCode = "t",
			ReferenceIdentificationQualifier = "Bx",
			ReferenceIdentification = "T",
			ReturnableContainerFreightPaymentResponsibilityCode = "V",
		};

		var actual = Map.MapObject<ETD_ExcessTransportationDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredExcessTransportationReasonCode(string excessTransportationReasonCode, bool isValidExpected)
	{
		var subject = new ETD_ExcessTransportationDetail();
		subject.ExcessTransportationResponsibilityCode = "t";
		subject.ExcessTransportationReasonCode = excessTransportationReasonCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "Bx";
			subject.ReferenceIdentification = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredExcessTransportationResponsibilityCode(string excessTransportationResponsibilityCode, bool isValidExpected)
	{
		var subject = new ETD_ExcessTransportationDetail();
		subject.ExcessTransportationReasonCode = "1";
		subject.ExcessTransportationResponsibilityCode = excessTransportationResponsibilityCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "Bx";
			subject.ReferenceIdentification = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Bx", "T", true)]
	[InlineData("Bx", "", false)]
	[InlineData("", "T", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new ETD_ExcessTransportationDetail();
		subject.ExcessTransportationReasonCode = "1";
		subject.ExcessTransportationResponsibilityCode = "t";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

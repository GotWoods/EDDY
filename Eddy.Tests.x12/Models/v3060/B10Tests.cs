using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class B10Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B10*g*m*EC*4*LM*m";

		var expected = new B10_BeginningSegmentForStatusDiscrepancyAndAppointmentSchedule()
		{
			InvoiceNumber = "g",
			ShipmentIdentificationNumber = "m",
			StandardCarrierAlphaCode = "EC",
			InquiryRequestNumber = 4,
			ReferenceIdentificationQualifier = "LM",
			ReferenceIdentification = "m",
		};

		var actual = Map.MapObject<B10_BeginningSegmentForStatusDiscrepancyAndAppointmentSchedule>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("g", "EC", true)]
	[InlineData("g", "", false)]
	public void Validation_ARequiresBInvoiceNumber(string invoiceNumber, string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new B10_BeginningSegmentForStatusDiscrepancyAndAppointmentSchedule();
		subject.InvoiceNumber = invoiceNumber;
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "LM";
			subject.ReferenceIdentification = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("LM", "m", true)]
	[InlineData("LM", "", false)]
	[InlineData("", "m", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new B10_BeginningSegmentForStatusDiscrepancyAndAppointmentSchedule();
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
        subject.InvoiceNumber = "g";
        subject.StandardCarrierAlphaCode = "ABCD";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

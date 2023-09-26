using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class ATATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ATA*80*c*30zZy0gB";

		var expected = new ATA_BeginningSegmentForMotorCarrierDeliveryTrailerManifest()
		{
			StandardCarrierAlphaCode = "80",
			ReferenceIdentification = "c",
			Date = "30zZy0gB",
		};

		var actual = Map.MapObject<ATA_BeginningSegmentForMotorCarrierDeliveryTrailerManifest>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("80", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new ATA_BeginningSegmentForMotorCarrierDeliveryTrailerManifest();
		//Required fields
		subject.ReferenceIdentification = "c";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new ATA_BeginningSegmentForMotorCarrierDeliveryTrailerManifest();
		//Required fields
		subject.StandardCarrierAlphaCode = "80";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

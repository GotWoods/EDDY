using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class ATATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ATA*lJ*o*7Hvq6x";

		var expected = new ATA_BeginningSegmentForMotorCarrierDeliveryTrailerManifest()
		{
			StandardCarrierAlphaCode = "lJ",
			ReferenceIdentification = "o",
			Date = "7Hvq6x",
		};

		var actual = Map.MapObject<ATA_BeginningSegmentForMotorCarrierDeliveryTrailerManifest>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lJ", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new ATA_BeginningSegmentForMotorCarrierDeliveryTrailerManifest();
		//Required fields
		subject.ReferenceIdentification = "o";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new ATA_BeginningSegmentForMotorCarrierDeliveryTrailerManifest();
		//Required fields
		subject.StandardCarrierAlphaCode = "lJ";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

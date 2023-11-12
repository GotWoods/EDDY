using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class ATATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ATA*fz*U*OCxPnlbP";

		var expected = new ATA_BeginningSegmentForMotorCarrierDeliveryTrailerManifest()
		{
			StandardCarrierAlphaCode = "fz",
			ReferenceIdentification = "U",
			Date = "OCxPnlbP",
		};

		var actual = Map.MapObject<ATA_BeginningSegmentForMotorCarrierDeliveryTrailerManifest>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fz", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new ATA_BeginningSegmentForMotorCarrierDeliveryTrailerManifest();
		//Required fields
		subject.ReferenceIdentification = "U";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new ATA_BeginningSegmentForMotorCarrierDeliveryTrailerManifest();
		//Required fields
		subject.StandardCarrierAlphaCode = "fz";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

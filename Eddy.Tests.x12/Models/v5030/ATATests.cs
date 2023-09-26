using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class ATATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ATA*q1*n*pne5RU0i";

		var expected = new ATA_BeginningSegmentForMotorCarrierDeliveryTrailerManifest()
		{
			StandardCarrierAlphaCode = "q1",
			ReferenceIdentification = "n",
			Date = "pne5RU0i",
		};

		var actual = Map.MapObject<ATA_BeginningSegmentForMotorCarrierDeliveryTrailerManifest>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q1", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new ATA_BeginningSegmentForMotorCarrierDeliveryTrailerManifest();
		//Required fields
		subject.ReferenceIdentification = "n";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new ATA_BeginningSegmentForMotorCarrierDeliveryTrailerManifest();
		//Required fields
		subject.StandardCarrierAlphaCode = "q1";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

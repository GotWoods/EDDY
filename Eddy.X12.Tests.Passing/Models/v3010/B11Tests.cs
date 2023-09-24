using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class B11Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B11*O*tv*kAXBHY*DI*4*O*9*X*c";

		var expected = new B11_BeginningSegmentForShipmentStatusInquiry()
		{
			IdentificationCodeQualifier = "O",
			IdentificationCode = "tv",
			Date = "kAXBHY",
			UnitOfMeasurementCode = "DI",
			Quantity = 4,
			AmountQualifierCode = "O",
			MonetaryAmount = 9,
			ItemDescriptionType = "X",
			Description = "c",
		};

		var actual = Map.MapObject<B11_BeginningSegmentForShipmentStatusInquiry>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new B11_BeginningSegmentForShipmentStatusInquiry();
		subject.IdentificationCode = "tv";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tv", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new B11_BeginningSegmentForShipmentStatusInquiry();
		subject.IdentificationCodeQualifier = "O";
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

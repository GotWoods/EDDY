using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class B11Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B11*p*sq*AqfH4O*fE*9*g*1*C*d";

		var expected = new B11_BeginningSegmentForShipmentStatusInquiry()
		{
			IdentificationCodeQualifier = "p",
			IdentificationCode = "sq",
			Date = "AqfH4O",
			UnitOfMeasurementCode = "fE",
			Quantity = 9,
			AmountQualifierCode = "g",
			MonetaryAmount = 1,
			ItemDescriptionType = "C",
			Description = "d",
		};

		var actual = Map.MapObject<B11_BeginningSegmentForShipmentStatusInquiry>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new B11_BeginningSegmentForShipmentStatusInquiry();
		subject.IdentificationCode = "sq";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("sq", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new B11_BeginningSegmentForShipmentStatusInquiry();
		subject.IdentificationCodeQualifier = "p";
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

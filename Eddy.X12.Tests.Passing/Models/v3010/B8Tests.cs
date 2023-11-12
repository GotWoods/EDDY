using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class B8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B8*UNA*2e*R*klNaPm*z";

		var expected = new B8_BeginningSegment()
		{
			TransactionSetIdentifierCode = "UNA",
			ReferenceNumberQualifier = "2e",
			ReferenceNumber = "R",
			ReferenceDate = "klNaPm",
			WeightUnitQualifier = "z",
		};

		var actual = Map.MapObject<B8_BeginningSegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2e", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new B8_BeginningSegment();
		subject.ReferenceNumber = "R";
		subject.ReferenceDate = "klNaPm";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new B8_BeginningSegment();
		subject.ReferenceNumberQualifier = "2e";
		subject.ReferenceDate = "klNaPm";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("klNaPm", true)]
	public void Validation_RequiredReferenceDate(string referenceDate, bool isValidExpected)
	{
		var subject = new B8_BeginningSegment();
		subject.ReferenceNumberQualifier = "2e";
		subject.ReferenceNumber = "R";
		subject.ReferenceDate = referenceDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

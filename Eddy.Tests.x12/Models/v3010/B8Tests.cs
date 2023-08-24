using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class B8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B8*eVU*HP*B*LbCoB3*0";

		var expected = new B8_BeginningSegment()
		{
			TransactionSetIdentifierCode = "eVU",
			ReferenceNumberQualifier = "HP",
			ReferenceNumber = "B",
			ReferenceDate = "LbCoB3",
			WeightUnitQualifier = "0",
		};

		var actual = Map.MapObject<B8_BeginningSegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("HP", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new B8_BeginningSegment();
		subject.ReferenceNumber = "B";
		subject.ReferenceDate = "LbCoB3";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new B8_BeginningSegment();
		subject.ReferenceNumberQualifier = "HP";
		subject.ReferenceDate = "LbCoB3";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("LbCoB3", true)]
	public void Validation_RequiredReferenceDate(string referenceDate, bool isValidExpected)
	{
		var subject = new B8_BeginningSegment();
		subject.ReferenceNumberQualifier = "HP";
		subject.ReferenceNumber = "B";
		subject.ReferenceDate = referenceDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

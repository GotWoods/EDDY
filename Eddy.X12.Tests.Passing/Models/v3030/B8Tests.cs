using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class B8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B8*50b*k8*V*FnA213*I";

		var expected = new B8_BeginningSegment()
		{
			TransactionSetIdentifierCode = "50b",
			ReferenceNumberQualifier = "k8",
			ReferenceNumber = "V",
			ReferenceDate = "FnA213",
			WeightUnitCode = "I",
		};

		var actual = Map.MapObject<B8_BeginningSegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k8", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new B8_BeginningSegment();
		subject.ReferenceNumber = "V";
		subject.ReferenceDate = "FnA213";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new B8_BeginningSegment();
		subject.ReferenceNumberQualifier = "k8";
		subject.ReferenceDate = "FnA213";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("FnA213", true)]
	public void Validation_RequiredReferenceDate(string referenceDate, bool isValidExpected)
	{
		var subject = new B8_BeginningSegment();
		subject.ReferenceNumberQualifier = "k8";
		subject.ReferenceNumber = "V";
		subject.ReferenceDate = referenceDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

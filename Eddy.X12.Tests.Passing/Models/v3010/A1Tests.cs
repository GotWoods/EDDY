using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class A1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "A1*HL3L*0CRB*b*m";

		var expected = new A1_Rejection()
		{
			RejectedSetIdentifier = "HL3L",
			ReferenceDesignator = "0CRB",
			ErrorFieldData = "b",
			ErrorConditionCode = "m",
		};

		var actual = Map.MapObject<A1_Rejection>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("HL3L", true)]
	public void Validation_RequiredRejectedSetIdentifier(string rejectedSetIdentifier, bool isValidExpected)
	{
		var subject = new A1_Rejection();
		subject.RejectedSetIdentifier = "HL3L";
		subject.ReferenceDesignator = "0CRB";
		subject.ErrorConditionCode = "m";
		subject.RejectedSetIdentifier = rejectedSetIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0CRB", true)]
	public void Validation_RequiredReferenceDesignator(string referenceDesignator, bool isValidExpected)
	{
		var subject = new A1_Rejection();
		subject.RejectedSetIdentifier = "HL3L";
		subject.ReferenceDesignator = "0CRB";
		subject.ErrorConditionCode = "m";
		subject.ReferenceDesignator = referenceDesignator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredErrorConditionCode(string errorConditionCode, bool isValidExpected)
	{
		var subject = new A1_Rejection();
		subject.RejectedSetIdentifier = "HL3L";
		subject.ReferenceDesignator = "0CRB";
		subject.ErrorConditionCode = "m";
		subject.ErrorConditionCode = errorConditionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

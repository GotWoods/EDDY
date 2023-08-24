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
		string x12Line = "A1*qHDM*g1rl*7*O";

		var expected = new A1_Rejection()
		{
			RejectedSetIdentifier = "qHDM",
			ReferenceDesignator = "g1rl",
			ErrorFieldData = "7",
			ErrorConditionCode = "O",
		};

		var actual = Map.MapObject<A1_Rejection>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qHDM", true)]
	public void Validation_RequiredRejectedSetIdentifier(string rejectedSetIdentifier, bool isValidExpected)
	{
		var subject = new A1_Rejection();
		subject.ReferenceDesignator = "g1rl";
		subject.ErrorConditionCode = "O";
		subject.RejectedSetIdentifier = rejectedSetIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g1rl", true)]
	public void Validation_RequiredReferenceDesignator(string referenceDesignator, bool isValidExpected)
	{
		var subject = new A1_Rejection();
		subject.RejectedSetIdentifier = "qHDM";
		subject.ErrorConditionCode = "O";
		subject.ReferenceDesignator = referenceDesignator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredErrorConditionCode(string errorConditionCode, bool isValidExpected)
	{
		var subject = new A1_Rejection();
		subject.RejectedSetIdentifier = "qHDM";
		subject.ReferenceDesignator = "g1rl";
		subject.ErrorConditionCode = errorConditionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

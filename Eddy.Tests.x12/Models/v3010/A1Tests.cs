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
		string x12Line = "A1*buQ1*n52b*8*k";

		var expected = new A1_Rejection()
		{
			RejectedSetIdentifier = "buQ1",
			ReferenceDesignator = "n52b",
			ErrorFieldData = "8",
			ErrorConditionCode = "k",
		};

		var actual = Map.MapObject<A1_Rejection>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("buQ1", true)]
	public void Validation_RequiredRejectedSetIdentifier(string rejectedSetIdentifier, bool isValidExpected)
	{
		var subject = new A1_Rejection();
		subject.ReferenceDesignator = "n52b";
		subject.ErrorConditionCode = "k";
		subject.RejectedSetIdentifier = rejectedSetIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n52b", true)]
	public void Validation_RequiredReferenceDesignator(string referenceDesignator, bool isValidExpected)
	{
		var subject = new A1_Rejection();
		subject.RejectedSetIdentifier = "buQ1";
		subject.ErrorConditionCode = "k";
		subject.ReferenceDesignator = referenceDesignator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredErrorConditionCode(string errorConditionCode, bool isValidExpected)
	{
		var subject = new A1_Rejection();
		subject.RejectedSetIdentifier = "buQ1";
		subject.ReferenceDesignator = "n52b";
		subject.ErrorConditionCode = errorConditionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

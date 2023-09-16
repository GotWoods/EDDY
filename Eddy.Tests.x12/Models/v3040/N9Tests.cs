using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class N9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N9*5w*x*Z*ggdtIz*7pj7*E0";

		var expected = new N9_ReferenceNumber()
		{
			ReferenceNumberQualifier = "5w",
			ReferenceNumber = "x",
			FreeFormDescription = "Z",
			Date = "ggdtIz",
			Time = "7pj7",
			TimeCode = "E0",
		};

		var actual = Map.MapObject<N9_ReferenceNumber>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5w", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new N9_ReferenceNumber();
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
			subject.ReferenceNumber = "x";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("x", "Z", true)]
	[InlineData("x", "", true)]
	[InlineData("", "Z", true)]
	public void Validation_AtLeastOneReferenceNumber(string referenceNumber, string freeFormDescription, bool isValidExpected)
	{
		var subject = new N9_ReferenceNumber();
		subject.ReferenceNumberQualifier = "5w";
		subject.ReferenceNumber = referenceNumber;
		subject.FreeFormDescription = freeFormDescription;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("E0", "7pj7", true)]
	[InlineData("E0", "", false)]
	[InlineData("", "7pj7", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new N9_ReferenceNumber();
		subject.ReferenceNumberQualifier = "5w";
		subject.TimeCode = timeCode;
		subject.Time = time;
			subject.ReferenceNumber = "x";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

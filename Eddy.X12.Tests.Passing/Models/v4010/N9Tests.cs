using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class N9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N9*n2*L*v*fjogZMOP*oTLb*tb*";

		var expected = new N9_ReferenceIdentification()
		{
			ReferenceIdentificationQualifier = "n2",
			ReferenceIdentification = "L",
			FreeFormDescription = "v",
			Date = "fjogZMOP",
			Time = "oTLb",
			TimeCode = "tb",
			ReferenceIdentifier = null,
		};

		var actual = Map.MapObject<N9_ReferenceIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n2", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new N9_ReferenceIdentification();
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
			subject.ReferenceIdentification = "L";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("L", "v", true)]
	[InlineData("L", "", true)]
	[InlineData("", "v", true)]
	public void Validation_AtLeastOneReferenceIdentification(string referenceIdentification, string freeFormDescription, bool isValidExpected)
	{
		var subject = new N9_ReferenceIdentification();
		subject.ReferenceIdentificationQualifier = "n2";
		subject.ReferenceIdentification = referenceIdentification;
		subject.FreeFormDescription = freeFormDescription;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("tb", "oTLb", true)]
	[InlineData("tb", "", false)]
	[InlineData("", "oTLb", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new N9_ReferenceIdentification();
		subject.ReferenceIdentificationQualifier = "n2";
		subject.TimeCode = timeCode;
		subject.Time = time;
			subject.ReferenceIdentification = "L";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class N9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N9*q0*R*P*FGgmkk*IyzL*A0*";

		var expected = new N9_ReferenceIdentification()
		{
			ReferenceIdentificationQualifier = "q0",
			ReferenceIdentification = "R",
			FreeFormDescription = "P",
			Date = "FGgmkk",
			Time = "IyzL",
			TimeCode = "A0",
			ReferenceIdentifier = null,
		};

		var actual = Map.MapObject<N9_ReferenceIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q0", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new N9_ReferenceIdentification();
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
			subject.ReferenceIdentification = "R";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("R", "P", true)]
	[InlineData("R", "", true)]
	[InlineData("", "P", true)]
	public void Validation_AtLeastOneReferenceIdentification(string referenceIdentification, string freeFormDescription, bool isValidExpected)
	{
		var subject = new N9_ReferenceIdentification();
		subject.ReferenceIdentificationQualifier = "q0";
		subject.ReferenceIdentification = referenceIdentification;
		subject.FreeFormDescription = freeFormDescription;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("A0", "IyzL", true)]
	[InlineData("A0", "", false)]
	[InlineData("", "IyzL", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new N9_ReferenceIdentification();
		subject.ReferenceIdentificationQualifier = "q0";
		subject.TimeCode = timeCode;
		subject.Time = time;
			subject.ReferenceIdentification = "R";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

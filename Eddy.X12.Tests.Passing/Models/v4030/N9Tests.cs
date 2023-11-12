using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class N9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N9*wp*f*p*kgy2h3nt*vz3I*GR*";

		var expected = new N9_ReferenceIdentification()
		{
			ReferenceIdentificationQualifier = "wp",
			ReferenceIdentification = "f",
			FreeFormDescription = "p",
			Date = "kgy2h3nt",
			Time = "vz3I",
			TimeCode = "GR",
			ReferenceIdentifier = null,
		};

		var actual = Map.MapObject<N9_ReferenceIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wp", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new N9_ReferenceIdentification();
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
			subject.ReferenceIdentification = "f";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("f", "p", true)]
	[InlineData("f", "", true)]
	[InlineData("", "p", true)]
	public void Validation_AtLeastOneReferenceIdentification(string referenceIdentification, string freeFormDescription, bool isValidExpected)
	{
		var subject = new N9_ReferenceIdentification();
		subject.ReferenceIdentificationQualifier = "wp";
		subject.ReferenceIdentification = referenceIdentification;
		subject.FreeFormDescription = freeFormDescription;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("GR", "vz3I", true)]
	[InlineData("GR", "", false)]
	[InlineData("", "vz3I", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new N9_ReferenceIdentification();
		subject.ReferenceIdentificationQualifier = "wp";
		subject.TimeCode = timeCode;
		subject.Time = time;
			subject.ReferenceIdentification = "f";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

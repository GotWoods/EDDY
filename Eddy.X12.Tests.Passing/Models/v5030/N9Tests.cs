using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class N9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N9*W5*S*8*V99ZjxWx*JmZW*9M*";

		var expected = new N9_ExtendedReferenceInformation()
		{
			ReferenceIdentificationQualifier = "W5",
			ReferenceIdentification = "S",
			FreeFormDescription = "8",
			Date = "V99ZjxWx",
			Time = "JmZW",
			TimeCode = "9M",
			ReferenceIdentifier = null,
		};

		var actual = Map.MapObject<N9_ExtendedReferenceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W5", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new N9_ExtendedReferenceInformation();
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
			subject.ReferenceIdentification = "S";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("S", "8", true)]
	[InlineData("S", "", true)]
	[InlineData("", "8", true)]
	public void Validation_AtLeastOneReferenceIdentification(string referenceIdentification, string freeFormDescription, bool isValidExpected)
	{
		var subject = new N9_ExtendedReferenceInformation();
		subject.ReferenceIdentificationQualifier = "W5";
		subject.ReferenceIdentification = referenceIdentification;
		subject.FreeFormDescription = freeFormDescription;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("9M", "JmZW", true)]
	[InlineData("9M", "", false)]
	[InlineData("", "JmZW", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new N9_ExtendedReferenceInformation();
		subject.ReferenceIdentificationQualifier = "W5";
		subject.TimeCode = timeCode;
		subject.Time = time;
			subject.ReferenceIdentification = "S";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

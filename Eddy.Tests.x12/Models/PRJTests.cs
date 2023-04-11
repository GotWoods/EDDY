using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PRJTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PRJ*k*h0*V*BbjtKZ5c";

		var expected = new PRJ_MultifamilyHousingProject()
		{
			Name = "k",
			ReferenceIdentificationQualifier = "h0",
			ReferenceIdentification = "V",
			Date = "BbjtKZ5c",
		};

		var actual = Map.MapObject<PRJ_MultifamilyHousingProject>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new PRJ_MultifamilyHousingProject();
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("h0", "V", true)]
	[InlineData("", "V", false)]
	[InlineData("h0", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new PRJ_MultifamilyHousingProject();
		subject.Name = "k";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

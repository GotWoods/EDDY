using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class PRJTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PRJ*O*Xy*Q*OfDEfL";

		var expected = new PRJ_MultifamilyHousingProject()
		{
			Name = "O",
			ReferenceNumberQualifier = "Xy",
			ReferenceNumber = "Q",
			Date = "OfDEfL",
		};

		var actual = Map.MapObject<PRJ_MultifamilyHousingProject>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new PRJ_MultifamilyHousingProject();
		//Required fields
		//Test Parameters
		subject.Name = name;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "Xy";
			subject.ReferenceNumber = "Q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Xy", "Q", true)]
	[InlineData("Xy", "", false)]
	[InlineData("", "Q", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new PRJ_MultifamilyHousingProject();
		//Required fields
		subject.Name = "O";
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

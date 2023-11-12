using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class REFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "REF*Uk*k*5";

		var expected = new REF_ReferenceNumbers()
		{
			ReferenceNumberQualifier = "Uk",
			ReferenceNumber = "k",
			Description = "5",
		};

		var actual = Map.MapObject<REF_ReferenceNumbers>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Uk", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new REF_ReferenceNumbers();
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
			subject.ReferenceNumber = "k";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("k", "5", true)]
	[InlineData("k", "", true)]
	[InlineData("", "5", true)]
	public void Validation_AtLeastOneReferenceNumber(string referenceNumber, string description, bool isValidExpected)
	{
		var subject = new REF_ReferenceNumbers();
		subject.ReferenceNumberQualifier = "Uk";
		subject.ReferenceNumber = referenceNumber;
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}

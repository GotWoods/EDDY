using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class N9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N9*yN*n*m*drHCEn*rpQK";

		var expected = new N9_ReferenceNumber()
		{
			ReferenceNumberQualifier = "yN",
			ReferenceNumber = "n",
			FreeFormDescription = "m",
			Date = "drHCEn",
			Time = "rpQK",
		};

		var actual = Map.MapObject<N9_ReferenceNumber>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yN", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new N9_ReferenceNumber();
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
			subject.ReferenceNumber = "n";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("n", "m", true)]
	[InlineData("n", "", true)]
	[InlineData("", "m", true)]
	public void Validation_AtLeastOneReferenceNumber(string referenceNumber, string freeFormDescription, bool isValidExpected)
	{
		var subject = new N9_ReferenceNumber();
		subject.ReferenceNumberQualifier = "yN";
		subject.ReferenceNumber = referenceNumber;
		subject.FreeFormDescription = freeFormDescription;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}

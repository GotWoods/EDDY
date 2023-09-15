using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class BGFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BGF*U3F*8j*c";

		var expected = new BGF_BeginningSegmentForFileTransferInformation()
		{
			TransactionSetIdentifierCode = "U3F",
			ReferenceIdentificationQualifier = "8j",
			ReferenceIdentification = "c",
		};

		var actual = Map.MapObject<BGF_BeginningSegmentForFileTransferInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8j", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new BGF_BeginningSegmentForFileTransferInformation();
		subject.ReferenceIdentification = "c";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BGF_BeginningSegmentForFileTransferInformation();
		subject.ReferenceIdentificationQualifier = "8j";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

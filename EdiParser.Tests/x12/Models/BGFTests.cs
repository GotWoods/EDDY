using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class BGFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BGF*0gw*1T*f";

		var expected = new BGF_BeginningSegmentForFileTransferInformation()
		{
			TransactionSetIdentifierCode = "0gw",
			ReferenceIdentificationQualifier = "1T",
			ReferenceIdentification = "f",
		};

		var actual = Map.MapObject<BGF_BeginningSegmentForFileTransferInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		try
		{
			Assert.Equivalent(expected, actual);
		}
		catch
		{
			Assert.Fail(actual.ValidationResult.ToString());
		}
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1T", true)]
	public void Validatation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new BGF_BeginningSegmentForFileTransferInformation();
		subject.ReferenceIdentification = "f";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validatation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BGF_BeginningSegmentForFileTransferInformation();
		subject.ReferenceIdentificationQualifier = "1T";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

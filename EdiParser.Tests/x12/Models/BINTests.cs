using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class BINTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BIN*2*c";

		var expected = new BIN_BinaryDataSegment()
		{
			LengthOfBinaryData = 2,
			BinaryData = "c",
		};

		var actual = Map.MapObject<BIN_BinaryDataSegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
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
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validatation_RequiredLengthOfBinaryData(int lengthOfBinaryData, bool isValidExpected)
	{
		var subject = new BIN_BinaryDataSegment();
		subject.BinaryData = "c";
		if (lengthOfBinaryData > 0)
		subject.LengthOfBinaryData = lengthOfBinaryData;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validatation_RequiredBinaryData(string binaryData, bool isValidExpected)
	{
		var subject = new BIN_BinaryDataSegment();
		subject.LengthOfBinaryData = 2;
		subject.BinaryData = binaryData;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

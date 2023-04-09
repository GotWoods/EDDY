using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class BDSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BDS*j1p*6*u";

		var expected = new BDS_BinaryDataStructure()
		{
			FilterIDCode = "j1p",
			LengthOfBinaryData = 6,
			BinaryData = "u",
		};

		var actual = Map.MapObject<BDS_BinaryDataStructure>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
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
	[InlineData("j1p", true)]
	public void Validatation_RequiredFilterIDCode(string filterIDCode, bool isValidExpected)
	{
		var subject = new BDS_BinaryDataStructure();
		subject.LengthOfBinaryData = 6;
		subject.BinaryData = "u";
		subject.FilterIDCode = filterIDCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validatation_RequiredLengthOfBinaryData(int lengthOfBinaryData, bool isValidExpected)
	{
		var subject = new BDS_BinaryDataStructure();
		subject.FilterIDCode = "j1p";
		subject.BinaryData = "u";
		if (lengthOfBinaryData > 0)
		subject.LengthOfBinaryData = lengthOfBinaryData;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validatation_RequiredBinaryData(string binaryData, bool isValidExpected)
	{
		var subject = new BDS_BinaryDataStructure();
		subject.FilterIDCode = "j1p";
		subject.LengthOfBinaryData = 6;
		subject.BinaryData = binaryData;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

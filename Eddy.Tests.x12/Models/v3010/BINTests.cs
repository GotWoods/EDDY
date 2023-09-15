using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BINTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BIN*8*r";

		var expected = new BIN_BinaryData()
		{
			LengthOfBinaryData = 8,
			BinaryData = "r",
		};

		var actual = Map.MapObject<BIN_BinaryData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredLengthOfBinaryData(int lengthOfBinaryData, bool isValidExpected)
	{
		var subject = new BIN_BinaryData();
		subject.BinaryData = "r";
		if (lengthOfBinaryData > 0)
			subject.LengthOfBinaryData = lengthOfBinaryData;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredBinaryData(string binaryData, bool isValidExpected)
	{
		var subject = new BIN_BinaryData();
		subject.LengthOfBinaryData = 8;
		subject.BinaryData = binaryData;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

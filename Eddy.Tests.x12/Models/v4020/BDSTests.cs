using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class BDSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BDS*kgf*8*X";

		var expected = new BDS_BinaryDataStructure()
		{
			FilterIDCode = "kgf",
			LengthOfBinaryData = 8,
			BinaryData = "X",
		};

		var actual = Map.MapObject<BDS_BinaryDataStructure>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kgf", true)]
	public void Validation_RequiredFilterIDCode(string filterIDCode, bool isValidExpected)
	{
		var subject = new BDS_BinaryDataStructure();
		//Required fields
		subject.LengthOfBinaryData = 8;
		subject.BinaryData = "X";
		//Test Parameters
		subject.FilterIDCode = filterIDCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredLengthOfBinaryData(int lengthOfBinaryData, bool isValidExpected)
	{
		var subject = new BDS_BinaryDataStructure();
		//Required fields
		subject.FilterIDCode = "kgf";
		subject.BinaryData = "X";
		//Test Parameters
		if (lengthOfBinaryData > 0) 
			subject.LengthOfBinaryData = lengthOfBinaryData;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredBinaryData(string binaryData, bool isValidExpected)
	{
		var subject = new BDS_BinaryDataStructure();
		//Required fields
		subject.FilterIDCode = "kgf";
		subject.LengthOfBinaryData = 8;
		//Test Parameters
		subject.BinaryData = binaryData;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

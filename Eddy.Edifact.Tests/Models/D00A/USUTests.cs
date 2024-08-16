using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class USUTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "USU+W+p";

		var expected = new USU_DataEncryptionTrailer()
		{
			LengthOfDataInOctetsOfBits = "W",
			EncryptionReferenceNumber = "p",
		};

		var actual = Map.MapObject<USU_DataEncryptionTrailer>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredLengthOfDataInOctetsOfBits(string lengthOfDataInOctetsOfBits, bool isValidExpected)
	{
		var subject = new USU_DataEncryptionTrailer();
		//Required fields
		//Test Parameters
		subject.LengthOfDataInOctetsOfBits = lengthOfDataInOctetsOfBits;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

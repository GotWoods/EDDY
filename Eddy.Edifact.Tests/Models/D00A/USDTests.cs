using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class USDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "USD+W+Z+w";

		var expected = new USD_DataEncryptionHeader()
		{
			LengthOfDataInOctetsOfBits = "W",
			EncryptionReferenceNumber = "Z",
			NumberOfPaddingBytes = "w",
		};

		var actual = Map.MapObject<USD_DataEncryptionHeader>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredLengthOfDataInOctetsOfBits(string lengthOfDataInOctetsOfBits, bool isValidExpected)
	{
		var subject = new USD_DataEncryptionHeader();
		//Required fields
		//Test Parameters
		subject.LengthOfDataInOctetsOfBits = lengthOfDataInOctetsOfBits;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

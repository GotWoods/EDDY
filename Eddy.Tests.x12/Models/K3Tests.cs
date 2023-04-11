using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class K3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "K3*8*E*";

		var expected = new K3_FileInformation()
		{
			FixedFormatInformation = "8",
			RecordFormatCode = "E",
			CompositeUnitOfMeasure = "",
		};

		var actual = Map.MapObject<K3_FileInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredFixedFormatInformation(string fixedFormatInformation, bool isValidExpected)
	{
		var subject = new K3_FileInformation();
		subject.FixedFormatInformation = fixedFormatInformation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

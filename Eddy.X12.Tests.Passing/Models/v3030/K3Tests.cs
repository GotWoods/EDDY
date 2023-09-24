using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class K3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "K3*T*f";

		var expected = new K3_FileInformation()
		{
			FixedFormatInformation = "T",
			RecordFormatCode = "f",
		};

		var actual = Map.MapObject<K3_FileInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredFixedFormatInformation(string fixedFormatInformation, bool isValidExpected)
	{
		var subject = new K3_FileInformation();
		subject.FixedFormatInformation = fixedFormatInformation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

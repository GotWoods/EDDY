using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3060;
using Eddy.x12.Models.v3060.Composites;

namespace Eddy.x12.Tests.Models.v3060.Composites;

public class C031Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "0*UVP*F*y*X";

		var expected = new C031_EncryptionKeyInformation()
		{
			EncryptionKeyName = "0",
			ProtocolID = "UVP",
			LookUpValue = "F",
			KeyingMaterial = "y",
			OneTimeEncryptionKey = "X",
		};

		var actual = Map.MapObject<C031_EncryptionKeyInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredEncryptionKeyName(string encryptionKeyName, bool isValidExpected)
	{
		var subject = new C031_EncryptionKeyInformation();
		//Required fields
		//Test Parameters
		subject.EncryptionKeyName = encryptionKeyName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

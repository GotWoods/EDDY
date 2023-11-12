using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v6030;
using Eddy.x12.Models.v6030.Composites;

namespace Eddy.x12.Tests.Models.v6030.Composites;

public class C031Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "k*J6r*d*5";

		var expected = new C031_EncryptionKeyInformation()
		{
			EncryptionKeyName = "k",
			ProtocolIDCode = "J6r",
			KeyingMaterial = "d",
			OneTimeEncryptionKey = "5",
		};

		var actual = Map.MapObject<C031_EncryptionKeyInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredEncryptionKeyName(string encryptionKeyName, bool isValidExpected)
	{
		var subject = new C031_EncryptionKeyInformation();
		//Required fields
		//Test Parameters
		subject.EncryptionKeyName = encryptionKeyName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

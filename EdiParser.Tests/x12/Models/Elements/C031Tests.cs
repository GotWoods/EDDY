using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models.Elements;

namespace EdiParser.Tests.x12.Models.Elements;

public class C031Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "F*wDB*Y*e";

        var expected = new C031_EncryptionKeyInformation()
        {
            EncryptionKeyName = "F",
            ProtocolIDCode = "wDB",
            KeyingMaterial = "Y",
            OneTimeEncryptionKey = "e",
        };

        var actual = Map.MapObject<C031_EncryptionKeyInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("F", true)]
    public void Validatation_RequiredEncryptionKeyName(string encryptionKeyName, bool isValidExpected)
    {
        var subject = new C031_EncryptionKeyInformation();
        subject.EncryptionKeyName = encryptionKeyName;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

}
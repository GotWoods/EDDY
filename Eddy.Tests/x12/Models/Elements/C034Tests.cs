using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models.Elements;

public class C034Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "NsB*1Rk";

        var expected = new C034_ComputationMethods()
        {
            AssuranceAlgorithmCode = "NsB",
            HashingAlgorithmCode = "1Rk",
        };

        var actual = Map.MapObject<C034_ComputationMethods>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("NsB", true)]
    public void Validatation_RequiredAssuranceAlgorithmCode(string assuranceAlgorithmCode, bool isValidExpected)
    {
        var subject = new C034_ComputationMethods();
        subject.HashingAlgorithmCode = "1Rk";
        subject.AssuranceAlgorithmCode = assuranceAlgorithmCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("1Rk", true)]
    public void Validatation_RequiredHashingAlgorithmCode(string hashingAlgorithmCode, bool isValidExpected)
    {
        var subject = new C034_ComputationMethods();
        subject.AssuranceAlgorithmCode = "NsB";
        subject.HashingAlgorithmCode = hashingAlgorithmCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

}
using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class M7Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M7*2v*DC*Hf*kS*ZG";

		var expected = new M7_SealNumbers()
		{
			SealNumber = "2v",
			SealNumber2 = "DC",
			SealNumber3 = "Hf",
			SealNumber4 = "kS",
			EntityIdentifierCode = "ZG",
		};

		var actual = Map.MapObject<M7_SealNumbers>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2v", true)]
	public void Validation_RequiredSealNumber(string sealNumber, bool isValidExpected)
	{
		var subject = new M7_SealNumbers();
		subject.SealNumber = sealNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.Tests.Models.v8010;

public class M7Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M7*2*5*P*u*Ky";

		var expected = new M7_SealNumbers()
		{
			SealNumber = "2",
			SealNumber2 = "5",
			SealNumber3 = "P",
			SealNumber4 = "u",
			EntityIdentifierCode = "Ky",
		};

		var actual = Map.MapObject<M7_SealNumbers>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredSealNumber(string sealNumber, bool isValidExpected)
	{
		var subject = new M7_SealNumbers();
		subject.SealNumber = sealNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

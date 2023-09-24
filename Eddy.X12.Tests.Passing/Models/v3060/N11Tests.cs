using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class N11Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N11*j*3*I";

		var expected = new N11_StoreNumber()
		{
			StoreNumber = "j",
			LocationIdentifier = "3",
			ReferenceIdentification = "I",
		};

		var actual = Map.MapObject<N11_StoreNumber>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredStoreNumber(string storeNumber, bool isValidExpected)
	{
		var subject = new N11_StoreNumber();
		subject.StoreNumber = storeNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class N11Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N11*J*9*f";

		var expected = new N11_StoreNumber()
		{
			StoreNumber = "J",
			LocationIdentifier = "9",
			ReferenceIdentification = "f",
		};

		var actual = Map.MapObject<N11_StoreNumber>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredStoreNumber(string storeNumber, bool isValidExpected)
	{
		var subject = new N11_StoreNumber();
		subject.StoreNumber = storeNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

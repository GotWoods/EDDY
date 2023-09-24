using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class N11Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N11*l*6*o";

		var expected = new N11_StoreLocation()
		{
			StoreNumber = "l",
			LocationIdentifier = "6",
			ReferenceIdentification = "o",
		};

		var actual = Map.MapObject<N11_StoreLocation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredStoreNumber(string storeNumber, bool isValidExpected)
	{
		var subject = new N11_StoreLocation();
		subject.StoreNumber = storeNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

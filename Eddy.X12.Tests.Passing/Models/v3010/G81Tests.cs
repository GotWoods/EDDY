using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G81Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G81*r*5";

		var expected = new G81_QuantityOrderedByLocation()
		{
			StoreNumber = "r",
			QuantityOrdered = 5,
		};

		var actual = Map.MapObject<G81_QuantityOrderedByLocation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredStoreNumber(string storeNumber, bool isValidExpected)
	{
		var subject = new G81_QuantityOrderedByLocation();
		subject.QuantityOrdered = 5;
		subject.StoreNumber = storeNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredQuantityOrdered(decimal quantityOrdered, bool isValidExpected)
	{
		var subject = new G81_QuantityOrderedByLocation();
		subject.StoreNumber = "r";
		if (quantityOrdered > 0)
			subject.QuantityOrdered = quantityOrdered;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

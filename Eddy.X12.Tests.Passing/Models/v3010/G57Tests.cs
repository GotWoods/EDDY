using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G57Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G57*d*5";

		var expected = new G57_QuantityInvoicedByLocation()
		{
			StoreNumber = "d",
			QuantityInvoiced = 5,
		};

		var actual = Map.MapObject<G57_QuantityInvoicedByLocation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredStoreNumber(string storeNumber, bool isValidExpected)
	{
		var subject = new G57_QuantityInvoicedByLocation();
		subject.QuantityInvoiced = 5;
		subject.StoreNumber = storeNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredQuantityInvoiced(decimal quantityInvoiced, bool isValidExpected)
	{
		var subject = new G57_QuantityInvoicedByLocation();
		subject.StoreNumber = "d";
		if (quantityInvoiced > 0)
			subject.QuantityInvoiced = quantityInvoiced;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

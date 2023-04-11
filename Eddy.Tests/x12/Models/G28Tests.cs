using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G28Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G28*83HQrAFZ8ckE*DzQPQqq6PmX8*Ah*l*8U*n";

		var expected = new G28_LineItemNumbers()
		{
			UPCCaseCode = "83HQrAFZ8ckE",
			UPCEANConsumerPackageCode = "DzQPQqq6PmX8",
			ProductServiceIDQualifier = "Ah",
			ProductServiceID = "l",
			ProductServiceIDQualifier2 = "8U",
			ProductServiceID2 = "n",
		};

		var actual = Map.MapObject<G28_LineItemNumbers>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Ah", "l", true)]
	[InlineData("", "l", false)]
	[InlineData("Ah", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G28_LineItemNumbers();
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("8U", "n", true)]
	[InlineData("", "n", false)]
	[InlineData("8U", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new G28_LineItemNumbers();
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

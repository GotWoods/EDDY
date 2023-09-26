using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class DLVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DLV*7*Jp*F*jy*F";

		var expected = new DLV_DeliverableInformation()
		{
			QuantityOrdered = 7,
			ProductServiceIDQualifier = "Jp",
			ProductServiceID = "F",
			ProgramTypeCode = "jy",
			Description = "F",
		};

		var actual = Map.MapObject<DLV_DeliverableInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredQuantityOrdered(decimal quantityOrdered, bool isValidExpected)
	{
		var subject = new DLV_DeliverableInformation();
		//Required fields
		//Test Parameters
		if (quantityOrdered > 0) 
			subject.QuantityOrdered = quantityOrdered;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Jp";
			subject.ProductServiceID = "F";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Jp", "F", true)]
	[InlineData("Jp", "", false)]
	[InlineData("", "F", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new DLV_DeliverableInformation();
		//Required fields
		subject.QuantityOrdered = 7;
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

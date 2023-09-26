using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class DLVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DLV*3*sK*T*3y*6";

		var expected = new DLV_DeliverableInformation()
		{
			QuantityOrdered = 3,
			ProductServiceIDQualifier = "sK",
			ProductServiceID = "T",
			ProgramTypeCode = "3y",
			Description = "6",
		};

		var actual = Map.MapObject<DLV_DeliverableInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
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
			subject.ProductServiceIDQualifier = "sK";
			subject.ProductServiceID = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("sK", "T", true)]
	[InlineData("sK", "", false)]
	[InlineData("", "T", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new DLV_DeliverableInformation();
		//Required fields
		subject.QuantityOrdered = 3;
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class JIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "JID*EN*I*2**yc*9";

		var expected = new JID_EquipmentDetail()
		{
			ProductServiceIDQualifier = "EN",
			ProductServiceID = "I",
			Quantity = 2,
			CompositeUnitOfMeasure = "",
			ProductServiceConditionCode = "yc",
			MonetaryAmount = 9,
		};

		var actual = Map.MapObject<JID_EquipmentDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("EN", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new JID_EquipmentDetail();
		subject.ProductServiceID = "I";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new JID_EquipmentDetail();
		subject.ProductServiceIDQualifier = "EN";
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

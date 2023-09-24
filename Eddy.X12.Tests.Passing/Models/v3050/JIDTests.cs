using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class JIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "JID*DM*C*5*JV*Xy*3";

		var expected = new JID_EquipmentDetail()
		{
			ProductServiceIDQualifier = "DM",
			ProductServiceID = "C",
			Quantity = 5,
			UnitOrBasisForMeasurementCode = "JV",
			ProductServiceConditionCode = "Xy",
			MonetaryAmount = 3,
		};

		var actual = Map.MapObject<JID_EquipmentDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("DM", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new JID_EquipmentDetail();
		subject.ProductServiceID = "C";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new JID_EquipmentDetail();
		subject.ProductServiceIDQualifier = "DM";
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("JV", 5, true)]
	[InlineData("JV", 0, false)]
	[InlineData("", 5, true)]
	public void Validation_ARequiresBUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity, bool isValidExpected)
	{
		var subject = new JID_EquipmentDetail();
		subject.ProductServiceIDQualifier = "DM";
		subject.ProductServiceID = "C";
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantity > 0)
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

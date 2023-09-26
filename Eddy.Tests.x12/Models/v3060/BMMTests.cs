using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class BMMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BMM*6f*K5BvQi*3*8*pXffop*6*x*L*I*eF";

		var expected = new BMM_BeginningSegmentForMultilevelRailcarLoadDetailsTransaction()
		{
			StandardCarrierAlphaCode = "6f",
			StandardPointLocationCode = "K5BvQi",
			Quantity = 3,
			WaybillNumber = 8,
			StandardPointLocationCode2 = "pXffop",
			ShipmentIdentificationNumber = "6",
			VehicleStatus = "x",
			AccountNumber = "L",
			ReferenceIdentification = "I",
			TransactionSetPurposeCode = "eF",
		};

		var actual = Map.MapObject<BMM_BeginningSegmentForMultilevelRailcarLoadDetailsTransaction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6f", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BMM_BeginningSegmentForMultilevelRailcarLoadDetailsTransaction();
		//Required fields
		subject.StandardPointLocationCode = "K5BvQi";
		subject.Quantity = 3;
		subject.WaybillNumber = 8;
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K5BvQi", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new BMM_BeginningSegmentForMultilevelRailcarLoadDetailsTransaction();
		//Required fields
		subject.StandardCarrierAlphaCode = "6f";
		subject.Quantity = 3;
		subject.WaybillNumber = 8;
		//Test Parameters
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new BMM_BeginningSegmentForMultilevelRailcarLoadDetailsTransaction();
		//Required fields
		subject.StandardCarrierAlphaCode = "6f";
		subject.StandardPointLocationCode = "K5BvQi";
		subject.WaybillNumber = 8;
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredWaybillNumber(int waybillNumber, bool isValidExpected)
	{
		var subject = new BMM_BeginningSegmentForMultilevelRailcarLoadDetailsTransaction();
		//Required fields
		subject.StandardCarrierAlphaCode = "6f";
		subject.StandardPointLocationCode = "K5BvQi";
		subject.Quantity = 3;
		//Test Parameters
		if (waybillNumber > 0) 
			subject.WaybillNumber = waybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

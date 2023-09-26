using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class BMMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BMM*xE*9Tf06G*6*9*HDR02m*p*f*1*r*lh";

		var expected = new BMM_BeginningSegmentForMultilevelRailcarLoadDetailsTransaction()
		{
			StandardCarrierAlphaCode = "xE",
			StandardPointLocationCode = "9Tf06G",
			Quantity = 6,
			WaybillNumber = 9,
			StandardPointLocationCode2 = "HDR02m",
			ShipmentIdentificationNumber = "p",
			VehicleStatus = "f",
			AccountNumber = "1",
			ReferenceIdentification = "r",
			TransactionSetPurposeCode = "lh",
		};

		var actual = Map.MapObject<BMM_BeginningSegmentForMultilevelRailcarLoadDetailsTransaction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xE", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BMM_BeginningSegmentForMultilevelRailcarLoadDetailsTransaction();
		//Required fields
		subject.StandardPointLocationCode = "9Tf06G";
		subject.Quantity = 6;
		subject.WaybillNumber = 9;
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9Tf06G", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new BMM_BeginningSegmentForMultilevelRailcarLoadDetailsTransaction();
		//Required fields
		subject.StandardCarrierAlphaCode = "xE";
		subject.Quantity = 6;
		subject.WaybillNumber = 9;
		//Test Parameters
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new BMM_BeginningSegmentForMultilevelRailcarLoadDetailsTransaction();
		//Required fields
		subject.StandardCarrierAlphaCode = "xE";
		subject.StandardPointLocationCode = "9Tf06G";
		subject.WaybillNumber = 9;
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredWaybillNumber(int waybillNumber, bool isValidExpected)
	{
		var subject = new BMM_BeginningSegmentForMultilevelRailcarLoadDetailsTransaction();
		//Required fields
		subject.StandardCarrierAlphaCode = "xE";
		subject.StandardPointLocationCode = "9Tf06G";
		subject.Quantity = 6;
		//Test Parameters
		if (waybillNumber > 0) 
			subject.WaybillNumber = waybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

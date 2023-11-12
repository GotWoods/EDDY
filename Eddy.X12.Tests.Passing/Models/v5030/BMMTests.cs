using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class BMMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BMM*cB*fWY58O*4*1*nIw78E*L*a*w*w*5z";

		var expected = new BMM_BeginningSegmentForMultilevelRailcarLoadDetailsTransaction()
		{
			StandardCarrierAlphaCode = "cB",
			StandardPointLocationCode = "fWY58O",
			Quantity = 4,
			WaybillNumber = 1,
			StandardPointLocationCode2 = "nIw78E",
			ShipmentIdentificationNumber = "L",
			VehicleStatus = "a",
			AccountNumber = "w",
			ReferenceIdentification = "w",
			TransactionSetPurposeCode = "5z",
		};

		var actual = Map.MapObject<BMM_BeginningSegmentForMultilevelRailcarLoadDetailsTransaction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("cB", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BMM_BeginningSegmentForMultilevelRailcarLoadDetailsTransaction();
		//Required fields
		subject.StandardPointLocationCode = "fWY58O";
		subject.Quantity = 4;
		subject.WaybillNumber = 1;
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fWY58O", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new BMM_BeginningSegmentForMultilevelRailcarLoadDetailsTransaction();
		//Required fields
		subject.StandardCarrierAlphaCode = "cB";
		subject.Quantity = 4;
		subject.WaybillNumber = 1;
		//Test Parameters
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new BMM_BeginningSegmentForMultilevelRailcarLoadDetailsTransaction();
		//Required fields
		subject.StandardCarrierAlphaCode = "cB";
		subject.StandardPointLocationCode = "fWY58O";
		subject.WaybillNumber = 1;
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredWaybillNumber(int waybillNumber, bool isValidExpected)
	{
		var subject = new BMM_BeginningSegmentForMultilevelRailcarLoadDetailsTransaction();
		//Required fields
		subject.StandardCarrierAlphaCode = "cB";
		subject.StandardPointLocationCode = "fWY58O";
		subject.Quantity = 4;
		//Test Parameters
		if (waybillNumber > 0) 
			subject.WaybillNumber = waybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

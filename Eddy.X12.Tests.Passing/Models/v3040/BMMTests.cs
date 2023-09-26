using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class BMMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BMM*4W*o5fGKC*9*6*3fVIrd*n*K*z*6*ss";

		var expected = new BMM_BeginningSegmentForMultilevelRailcarLoadDetailsTransaction()
		{
			StandardCarrierAlphaCode = "4W",
			StandardPointLocationCode = "o5fGKC",
			Quantity = 9,
			WaybillNumber = 6,
			StandardPointLocationCode2 = "3fVIrd",
			ShipmentIdentificationNumber = "n",
			VehicleStatus = "K",
			AccountNumber = "z",
			ReferenceNumber = "6",
			TransactionSetPurposeCode = "ss",
		};

		var actual = Map.MapObject<BMM_BeginningSegmentForMultilevelRailcarLoadDetailsTransaction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4W", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BMM_BeginningSegmentForMultilevelRailcarLoadDetailsTransaction();
		//Required fields
		subject.StandardPointLocationCode = "o5fGKC";
		subject.Quantity = 9;
		subject.WaybillNumber = 6;
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o5fGKC", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new BMM_BeginningSegmentForMultilevelRailcarLoadDetailsTransaction();
		//Required fields
		subject.StandardCarrierAlphaCode = "4W";
		subject.Quantity = 9;
		subject.WaybillNumber = 6;
		//Test Parameters
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new BMM_BeginningSegmentForMultilevelRailcarLoadDetailsTransaction();
		//Required fields
		subject.StandardCarrierAlphaCode = "4W";
		subject.StandardPointLocationCode = "o5fGKC";
		subject.WaybillNumber = 6;
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredWaybillNumber(int waybillNumber, bool isValidExpected)
	{
		var subject = new BMM_BeginningSegmentForMultilevelRailcarLoadDetailsTransaction();
		//Required fields
		subject.StandardCarrierAlphaCode = "4W";
		subject.StandardPointLocationCode = "o5fGKC";
		subject.Quantity = 9;
		//Test Parameters
		if (waybillNumber > 0) 
			subject.WaybillNumber = waybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

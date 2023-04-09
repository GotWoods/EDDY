using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class BMMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BMM*6K*fNg9jh*6*6*VSyjzl*w*E*o*m*xI";

		var expected = new BMM_BeginningSegmentForMultilevelRailcarLoadDetailsTransaction()
		{
			StandardCarrierAlphaCode = "6K",
			StandardPointLocationCode = "fNg9jh",
			Quantity = 6,
			WaybillNumber = 6,
			StandardPointLocationCode2 = "VSyjzl",
			ShipmentIdentificationNumber = "w",
			VehicleStatus = "E",
			AccountNumber = "o",
			ReferenceIdentification = "m",
			TransactionSetPurposeCode = "xI",
		};

		var actual = Map.MapObject<BMM_BeginningSegmentForMultilevelRailcarLoadDetailsTransaction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		try
		{
			Assert.Equivalent(expected, actual);
		}
		catch
		{
			Assert.Fail(actual.ValidationResult.ToString());
		}
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6K", true)]
	public void Validatation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BMM_BeginningSegmentForMultilevelRailcarLoadDetailsTransaction();
		subject.StandardPointLocationCode = "fNg9jh";
		subject.Quantity = 6;
		subject.WaybillNumber = 6;
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fNg9jh", true)]
	public void Validatation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new BMM_BeginningSegmentForMultilevelRailcarLoadDetailsTransaction();
		subject.StandardCarrierAlphaCode = "6K";
		subject.Quantity = 6;
		subject.WaybillNumber = 6;
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validatation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new BMM_BeginningSegmentForMultilevelRailcarLoadDetailsTransaction();
		subject.StandardCarrierAlphaCode = "6K";
		subject.StandardPointLocationCode = "fNg9jh";
		subject.WaybillNumber = 6;
		if (quantity > 0)
		subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validatation_RequiredWaybillNumber(int waybillNumber, bool isValidExpected)
	{
		var subject = new BMM_BeginningSegmentForMultilevelRailcarLoadDetailsTransaction();
		subject.StandardCarrierAlphaCode = "6K";
		subject.StandardPointLocationCode = "fNg9jh";
		subject.Quantity = 6;
		if (waybillNumber > 0)
		subject.WaybillNumber = waybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

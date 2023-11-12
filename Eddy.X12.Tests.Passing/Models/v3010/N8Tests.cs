using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class N8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N8*9*seny45*o*D*g*9*hsw3cU*Eg*IB*vA*q";

		var expected = new N8_WaybillReference()
		{
			WaybillNumber = 9,
			WaybillDate = "seny45",
			CrossReferenceTypeCode = "o",
			EquipmentInitial = "D",
			EquipmentNumber = "g",
			WaybillNumber2 = 9,
			WaybillDate2 = "hsw3cU",
			DestinationStation = "Eg",
			StateOrProvinceCode = "IB",
			StandardCarrierAlphaCode = "vA",
			FreightStationAccountingCode = "q",
		};

		var actual = Map.MapObject<N8_WaybillReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredWaybillNumber(int waybillNumber, bool isValidExpected)
	{
		var subject = new N8_WaybillReference();
		subject.WaybillDate = "seny45";
		if (waybillNumber > 0)
			subject.WaybillNumber = waybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("seny45", true)]
	public void Validation_RequiredWaybillDate(string waybillDate, bool isValidExpected)
	{
		var subject = new N8_WaybillReference();
		subject.WaybillNumber = 9;
		subject.WaybillDate = waybillDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

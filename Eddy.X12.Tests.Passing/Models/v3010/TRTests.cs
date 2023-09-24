using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class TRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TR*2*4*AU*6*Kg*u7znc*6n*8*qs*wXyTe*Rl*Pk*1x*7h*8747*KmM*5";

		var expected = new TR_TariffRate()
		{
			LineNumber = 2,
			FreeFormDescription = "4",
			QuantityQualifier = "AU",
			Quantity = 6,
			UnitOfMeasurementCode = "Kg",
			PackagingCode = "u7znc",
			QuantityQualifier2 = "6n",
			Quantity2 = 8,
			UnitOfMeasurementCode2 = "qs",
			PackagingCode2 = "wXyTe",
			TypeOfServiceCode = "Rl",
			StandardCarrierAlphaCode = "Pk",
			RateValueQualifier = "1x",
			EquipmentDescriptionCode = "7h",
			EquipmentLength = 8747,
			CurrencyCode = "KmM",
			FreightRate = 5,
		};

		var actual = Map.MapObject<TR_TariffRate>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredLineNumber(int lineNumber, bool isValidExpected)
	{
		var subject = new TR_TariffRate();
		if (lineNumber > 0)
			subject.LineNumber = lineNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

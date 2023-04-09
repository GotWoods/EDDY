using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class BNXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BNX*d*G*M*84686";

		var expected = new BNX_RailShipmentInformation()
		{
			ShipmentWeightCode = "d",
			ReferencedPatternIdentifier = "G",
			BillingCode = "M",
			RepetitivePatternNumber = 84686,
		};

		var actual = Map.MapObject<BNX_RailShipmentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		try
		{
			Assert.Equivalent(expected, actual);
		}
		catch
		{
			Assert.Fail(actual.ValidationResult.ToString());
		}
	}

}

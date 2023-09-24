using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class TITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TI*jM*Jy*7*u*31PSgv*Lg*QhLr";

		var expected = new TI_TransportInformation()
		{
			StandardCarrierAlphaCode = "jM",
			StandardCarrierAlphaCode2 = "Jy",
			EquipmentInitial = "7",
			EquipmentNumber = "u",
			Date = "31PSgv",
			SealStatusCode = "Lg",
			CarTypeCode = "QhLr",
		};

		var actual = Map.MapObject<TI_TransportInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}

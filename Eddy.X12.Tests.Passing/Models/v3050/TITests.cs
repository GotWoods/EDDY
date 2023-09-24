using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class TITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TI*ka*lt*z*T*EXl7CN*QI*T";

		var expected = new TI_TransportInformation()
		{
			StandardCarrierAlphaCode = "ka",
			StandardCarrierAlphaCode2 = "lt",
			EquipmentInitial = "z",
			EquipmentNumber = "T",
			Date = "EXl7CN",
			SealStatusCode = "QI",
			CarTypeCode = "T",
		};

		var actual = Map.MapObject<TI_TransportInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}

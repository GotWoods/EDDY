using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class TITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TI*jR*QC*a*B*fjeZLU2P*cv*x";

		var expected = new TI_TransportInformation()
		{
			StandardCarrierAlphaCode = "jR",
			StandardCarrierAlphaCode2 = "QC",
			EquipmentInitial = "a",
			EquipmentNumber = "B",
			Date = "fjeZLU2P",
			SealStatusCode = "cv",
			CarTypeCode = "x",
		};

		var actual = Map.MapObject<TI_TransportInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}

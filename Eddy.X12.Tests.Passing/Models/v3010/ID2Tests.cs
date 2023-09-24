using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class ID2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ID2*Q*h*dt*o*Q*E*Hd*4";

		var expected = new ID2_ItemImageDetail()
		{
			CashRegisterItemDescription = "Q",
			CashRegisterItemDescription2 = "h",
			SpaceManagementReferenceCode = "dt",
			ReferenceNumber = "o",
			Name = "Q",
			Name2 = "E",
			SpaceManagementReferenceCode2 = "Hd",
			ReferenceNumber2 = "4",
		};

		var actual = Map.MapObject<ID2_ItemImageDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}

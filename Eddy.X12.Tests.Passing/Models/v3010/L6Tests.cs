using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class L6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L6*1NV*jOobPE";

		var expected = new L6_CarriersLineItemReferenceNumber()
		{
			CarriersLineItemReferenceNumber = "1NV",
			PickUpDate = "jOobPE",
		};

		var actual = Map.MapObject<L6_CarriersLineItemReferenceNumber>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}

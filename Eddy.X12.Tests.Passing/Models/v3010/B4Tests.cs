using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class B4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B4*Rvt*4*7*PWyo7f*Unpe*Nlg*3*n*N";

		var expected = new B4_BeginningSegmentForInquiryOrReply()
		{
			TransactionSetIdentifierCode = "Rvt",
			InquiryRequestNumber = 4,
			StatusCode = "7",
			StatusDate = "PWyo7f",
			StatusTime = "Unpe",
			StatusLocation = "Nlg",
			EquipmentInitial = "3",
			EquipmentNumber = "n",
			EquipmentStatusCode = "N",
		};

		var actual = Map.MapObject<B4_BeginningSegmentForInquiryOrReply>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}

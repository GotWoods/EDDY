using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class B4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B4*ScL*4*9*TpCSiA*mIKy*ReC*6*p*X";

		var expected = new B4_BeginningSegmentForInquiryOrReply()
		{
			TransactionSetIdentifierCode = "ScL",
			InquiryRequestNumber = 4,
			StatusCode = "9",
			StatusDate = "TpCSiA",
			StatusTime = "mIKy",
			StatusLocation = "ReC",
			EquipmentInitial = "6",
			EquipmentNumber = "p",
			EquipmentStatusCode = "X",
		};

		var actual = Map.MapObject<B4_BeginningSegmentForInquiryOrReply>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}

using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class PIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PID*8*Eb*lJ*K*d*sj";

		var expected = new PID_ProductItemDescription()
		{
			ItemDescriptionType = "8",
			ProductProcessCharacteristicCode = "Eb",
			AssociationQualifierCode = "lJ",
			ProductDescriptionCode = "K",
			Description = "d",
			SurfaceLayerPositionCode = "sj",
		};

		var actual = Map.MapObject<PID_ProductItemDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredItemDescriptionType(string itemDescriptionType, bool isValidExpected)
	{
		var subject = new PID_ProductItemDescription();
		//Required fields
		//Test Parameters
		subject.ItemDescriptionType = itemDescriptionType;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

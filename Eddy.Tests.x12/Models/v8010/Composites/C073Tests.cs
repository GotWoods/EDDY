using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v8010;
using Eddy.x12.Models.v8010.Composites;

namespace Eddy.x12.Tests.Models.v8010.Composites;

public class C073Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "t*WA*8*6*8W*4*8*1D*4*f*fa*3*p*nv*3*J*ot*1*M*mu*3*9*Li*2*h*Ri*7*I*bK*4";

		var expected = new C073_CompositeGrapeVarietalSequence()
		{
			AssignedIdentification = "t",
			GrapeVarietalCode = "WA",
			MeasurementValue = 8,
			AssignedIdentification2 = "6",
			GrapeVarietalCode2 = "8W",
			MeasurementValue2 = 4,
			AssignedIdentification3 = "8",
			GrapeVarietalCode3 = "1D",
			MeasurementValue3 = 4,
			AssignedIdentification4 = "f",
			GrapeVarietalCode4 = "fa",
			MeasurementValue4 = 3,
			AssignedIdentification5 = "p",
			GrapeVarietalCode5 = "nv",
			MeasurementValue5 = 3,
			AssignedIdentification6 = "J",
			GrapeVarietalCode6 = "ot",
			MeasurementValue6 = 1,
			AssignedIdentification7 = "M",
			GrapeVarietalCode7 = "mu",
			MeasurementValue7 = 3,
			AssignedIdentification8 = "9",
			GrapeVarietalCode8 = "Li",
			MeasurementValue8 = 2,
			AssignedIdentification9 = "h",
			GrapeVarietalCode9 = "Ri",
			MeasurementValue9 = 7,
			AssignedIdentification10 = "I",
			GrapeVarietalCode10 = "bK",
			MeasurementValue10 = 4,
		};

		var actual = Map.MapObject<C073_CompositeGrapeVarietalSequence>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredAssignedIdentification(string assignedIdentification, bool isValidExpected)
	{
		var subject = new C073_CompositeGrapeVarietalSequence();
		//Required fields
		//Test Parameters
		subject.AssignedIdentification = assignedIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

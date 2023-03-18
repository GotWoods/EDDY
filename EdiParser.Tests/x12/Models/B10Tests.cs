using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models
{
    public class B10Tests
    {
        [Fact]
        public void ParseX12B10Line_ShouldReturnCorrectObject()
        {
            var expected = new B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage
            {
                ReferenceIdentification = "4735103",
                ShipmentIdentificationNumber = "5365205",
                StandardCarrierAlphaCode = "SCAC",
            };

            var actual = Map.MapObject<B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage>("B10*4735103*5365205*SCAC", MapOptionsForTesting.x12DefaultEndsWithNewline);

            Assert.Equivalent(expected, actual);
        }

        [Fact]
        public void Validation_OneReferenceIdentificationIsRequired()
        {
            var subject = new B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage();
            subject.StandardCarrierAlphaCode = "SCAC";
            var result = subject.Validate();

            //nothing set should fail as a reference is required
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            Assert.Equal(ErrorCodes.AorBRequired, result.Errors[0].ErrorCode);

            subject.ReferenceIdentification = "REF";
            result = subject.Validate();
            Assert.True(result.IsValid, result.ToString());

            subject.ReferenceIdentification = "";
            subject.ReferenceIdentification2 = "REF";
            subject.ReferenceIdentificationQualifier = "QU";
            result = subject.Validate();
            Assert.True(result.IsValid, result.ToString());
        }

        [Fact]
        public void Validation_ReferenceIdentificationExcludesReferenceIdentificationQualifier()
        {
            var subject = new B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage();
            subject.StandardCarrierAlphaCode = "SCAC";
            subject.ReferenceIdentification = "ABC";
            var result = subject.Validate();

            Assert.True(result.IsValid);


            subject.ReferenceIdentificationQualifier = "123";
            result = subject.Validate();
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            Assert.Equal(ErrorCodes.OnlyOneOf, result.Errors[0].ErrorCode);
        }


        [Fact]
        public void Validation_ReferenceIdentification2_Requires_Qualifier()
        {
            var subject = new B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage();
            subject.StandardCarrierAlphaCode = "SCAC";
            subject.ReferenceIdentification2 = "ABC";

            var result = subject.Validate();
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            Assert.Equal(ErrorCodes.ARequiresB, result.Errors[0].ErrorCode);

            subject.ReferenceIdentificationQualifier = "ABC";
            result = subject.Validate();
            Assert.True(result.IsValid);
        }

        [Fact]
        public void Validation_Time_Requires_Date()
        {
            var subject = new B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage();
            subject.StandardCarrierAlphaCode = "SCAC";
            subject.ReferenceIdentification = "ABC";
            subject.Time = "1258";

            var result = subject.Validate();
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            Assert.Equal(ErrorCodes.ARequiresB, result.Errors[0].ErrorCode);

            subject.Date = "20230101";
            result = subject.Validate();
            Assert.True(result.IsValid);

        }
    }
}

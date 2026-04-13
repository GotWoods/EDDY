using Eddy.Core.Extension;
using Eddy.x12.DomainModels.Transportation.v4010;
using Eddy.x12.Models.v4010;
using Eddy.x12.DomainModels.Transportation.v4010._214;

namespace Eddy.Tests
{
    public class EdiValueExtractorTests
    {
        [Fact]
        public void GetValueByPosition_B10Segment_ReturnsCorrectValues()
        {
            // Arrange
            var ediData = new Edi214_TransportationCarrierShipmentStatusMessage
            {
                BeginningSegmentForTransportationCarrierShipmentStatusMessage = new B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage
                {
                    ReferenceIdentification = "CONFIG_TEST_REF",      // Position 1
                    ShipmentIdentificationNumber = "CONFIG_TEST_SHIP", // Position 2  
                    StandardCarrierAlphaCode = "CTST"                  // Position 3
                }
            };

            // Act & Assert
            var position1 = ediData.GetValueByPosition("BeginningSegmentForTransportationCarrierShipmentStatusMessage", "B10", 1);
            var position2 = ediData.GetValueByPosition("BeginningSegmentForTransportationCarrierShipmentStatusMessage", "B10", 2);
            var position3 = ediData.GetValueByPosition("BeginningSegmentForTransportationCarrierShipmentStatusMessage", "B10", 3);

            Assert.Equal("CONFIG_TEST_REF", position1);
            Assert.Equal("CONFIG_TEST_SHIP", position2);
            Assert.Equal("CTST", position3);
        }

        [Fact]
        public void GetValueByPosition_L11Segment_ReturnsCorrectValues()
        {
            // Arrange
            var ediData = new Edi214_TransportationCarrierShipmentStatusMessage
            {
                L0200 = new List<L0200>
                {
                    new L0200
                    {
                        BusinessInstructionsAndReferenceNumber = new List<L11_BusinessInstructionsAndReferenceNumber>
                        {
                            new L11_BusinessInstructionsAndReferenceNumber
                            {
                                ReferenceIdentification = "TEST_REF",          // Position 1
                                ReferenceIdentificationQualifier = "TEST_QUAL", // Position 2
                                Description = "TEST_DESC"                       // Position 3
                            }
                        }
                    }
                }
            };

            // Act & Assert
            var position1 = ediData.GetValueByPosition("L0200", "L11", 1);
            var position2 = ediData.GetValueByPosition("L0200", "L11", 2);
            var position3 = ediData.GetValueByPosition("L0200", "L11", 3);

            Assert.Equal("TEST_REF", position1);
            Assert.Equal("TEST_QUAL", position2);
            Assert.Equal("TEST_DESC", position3);
        }

        [Fact]
        public void GetValueByName_ReturnsCorrectValues()
        {
            // Arrange
            var ediData = new Edi214_TransportationCarrierShipmentStatusMessage
            {
                BeginningSegmentForTransportationCarrierShipmentStatusMessage = new B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage
                {
                    ReferenceIdentification = "CONFIG_TEST_REF",
                    ShipmentIdentificationNumber = "CONFIG_TEST_SHIP"
                }
            };

            // Act & Assert
            var refId = ediData.GetValueByName("BeginningSegmentForTransportationCarrierShipmentStatusMessage", "B10", "ReferenceIdentification");
            var shipId = ediData.GetValueByName("BeginningSegmentForTransportationCarrierShipmentStatusMessage", "B10", "ShipmentIdentificationNumber");

            Assert.Equal("CONFIG_TEST_REF", refId);
            Assert.Equal("CONFIG_TEST_SHIP", shipId);
        }

        [Fact]
        public void GetAllPositions_ReturnsAllValues()
        {
            // Arrange
            var ediData = new Edi214_TransportationCarrierShipmentStatusMessage
            {
                BeginningSegmentForTransportationCarrierShipmentStatusMessage = new B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage
                {
                    ReferenceIdentification = "CONFIG_TEST_REF",
                    ShipmentIdentificationNumber = "CONFIG_TEST_SHIP",
                    StandardCarrierAlphaCode = "CTST"
                }
            };

            // Act
            var allPositions = ediData.GetAllPositions("BeginningSegmentForTransportationCarrierShipmentStatusMessage", "B10");

            // Assert
            Assert.Equal("CONFIG_TEST_REF", allPositions[1]);
            Assert.Equal("CONFIG_TEST_SHIP", allPositions[2]);
            Assert.Equal("CTST", allPositions[3]);
            Assert.Equal(3, allPositions.Count);
        }

        [Fact]
        public void GetValueByPosition_MultipleInstances_ReturnsCorrectValues()
        {
            // Arrange
            var ediData = new Edi214_TransportationCarrierShipmentStatusMessage
            {
                L0200 = new List<L0200>
                {
                    new L0200
                    {
                        BusinessInstructionsAndReferenceNumber = new List<L11_BusinessInstructionsAndReferenceNumber>
                        {
                            new L11_BusinessInstructionsAndReferenceNumber
                            {
                                ReferenceIdentification = "FIRST_REF"
                            }
                        }
                    },
                    new L0200
                    {
                        BusinessInstructionsAndReferenceNumber = new List<L11_BusinessInstructionsAndReferenceNumber>
                        {
                            new L11_BusinessInstructionsAndReferenceNumber
                            {
                                ReferenceIdentification = "SECOND_REF"
                            }
                        }
                    }
                }
            };

            // Act & Assert
            var firstInstance = ediData.GetValueByPosition("L0200", "L11", 1, 0);
            var secondInstance = ediData.GetValueByPosition("L0200", "L11", 1, 1);

            Assert.Equal("FIRST_REF", firstInstance);
            Assert.Equal("SECOND_REF", secondInstance);
        }
    }
}

using EdiParser.x12.Models;

namespace EdiParser.x12.DomainModels;

public class Edi990_ResponseToLoadTender
{
    public void LoadFrom(x12Document document)
    {
        var section = document.Sections[0]; //it is possible a document contains multiple instructions
        for (var rowIndex = 0; rowIndex < section.Segments.Count; rowIndex++)
        {
            var currentSegment = section.Segments[rowIndex];

            switch (currentSegment)
            {
                case B1_BeginningSegmentForBookingOrPickupDelivery b1:
                    break;
                case L11_BusinessInstructionsAndReferenceNumber l11:
                    break;
            }
        }
    }
}
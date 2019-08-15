using System;
using System.Collections.Generic;
using System.Text;

namespace ValueTypes.Enums
{
    public enum Status
    {
        OrderPlaced = 0,
        OrderWaitingMaterial = 1,
        OrderInProcess = 2,
        OrderCompletedDeliveryPending = 3,
        OrderDelivered = 4
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SmartLens.UITransmissionTestClient.Client
{
    interface IPaintingProcess
    {
        Image Screenshot(int x, int y);
        byte[] ImageToByte(Image imageIn);
    }
}

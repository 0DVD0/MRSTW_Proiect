using QRCoder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace eUseControl.Helper.AssistingLogic
{
     public class CheckoutHelper
     {
          public byte[] GenerateQrCode(string qrText)
          {
               using (var qrGenerator = new QRCodeGenerator())
               using (var qrData = qrGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q))
               using (var qrCode = new QRCode(qrData))
               using (var bitmap = qrCode.GetGraphic(20))
               using (var stream = new MemoryStream())
               {
                    bitmap.Save(stream, ImageFormat.Png);
                    return stream.ToArray();
               }
          }

     }
}

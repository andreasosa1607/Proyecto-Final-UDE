using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AV.BO;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace AV_API


{
    [Microsoft.AspNetCore.Components.Route("api_1_0/[controller]")]
    [ApiController]
    public class CodigoQRController
    {
        static void CodigosQR(string[] args)
        { 
        Document doc = new Document(PageSize.A4);
        PdfWriter.GetInstance(doc, new FileStream(@"C:\Users\Andrea\OneDrive\Escritorio\Proyecto Final\Proyecto-Final-UDE\Codigos QR\prueba.pdf", FileMode.Create));
            doc.Open();
            BarcodeQRCode barcodeQRCode = new BarcodeQRCode("reserva",1000,1000,null);
            Image codeQRImage = barcodeQRCode.GetImage();
            codeQRImage.ScaleAbsolute(200, 200);
            doc.Add(codeQRImage);
            doc.Close();

        }

    }
}

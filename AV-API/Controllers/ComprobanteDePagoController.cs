using AV.DA;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using AV.BO;
using AV.BL;
using AV_DTO;
using System.IO;
using System.Net;

namespace AV_API.Controllers
{
    [Route("api_1_0/[controller]")]
    [ApiController]
    public class ComprobanteDePagoController : ControllerBase
    {
        AVDBContext _context;

        public ComprobanteDePagoController (AVDBContext context)
        {
            _context = context;
        }





        [HttpPost]
        [Route("Subir")]
        public ComprobanteDePagoDTO Subir(ComprobanteDePagoDTO request) {



            try {


                ComprobanteDePago comprobanteDePago = MapeoDTO.ComprobanteDePago(request);
                _context.ComprobantesDePagos.Add(comprobanteDePago);

                    //Ver NOMBRE que NO SE REPITA!
                _context.SaveChangesAsync();
                GuardarArchivoFTP(comprobanteDePago.IdDocumento + "_" + comprobanteDePago.Nombre, Convert.FromBase64String(request.Archivo.Split(',')[1]));

                request.IdDocumento = comprobanteDePago.IdDocumento;
                request.Archivo = "";

                //return CreatedAtAction("GetComprobanteDePago", new { id = request.IdDocumento }, request);
             
               
            }


            catch (Exception error) {

                //return StatusCode(StatusCodes.Status200OK, new { mensaje = error.Message });

               


            }
            return request;





        }

        public static void GuardarArchivoFTP(string fileName, byte[] file)
        {
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(@"ftp://win5207.site4now.net/" + fileName);
            request.Method = WebRequestMethods.Ftp.UploadFile;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential("proyectoude", "pr0yect0ude2022");

            Stream requestStream = request.GetRequestStream();
            //requestStream.Write(file);


            requestStream.Write(file, 0, file.Length);
            requestStream.Close();

        }






    }
}

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
using Microsoft.EntityFrameworkCore;

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

                _context.SaveChangesAsync();
                GuardarArchivoFTP(comprobanteDePago.IdDocumento + "_" + comprobanteDePago.Nombre, Convert.FromBase64String(request.Archivo.Split(',')[1]));
                
                request.IdDocumento = comprobanteDePago.IdDocumento;
                request.Archivo = "";

            }


            catch (Exception error) {


            }
            return request;
        }

        public static void GuardarArchivoFTP(string fileName, byte[] file)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(@"ftp://win5207.site4now.net/" + fileName);
            request.Method = WebRequestMethods.Ftp.UploadFile;

            request.Credentials = new NetworkCredential("proyectoude", "pr0yect0ude2022");

            Stream requestStream = request.GetRequestStream();

            requestStream.Write(file, 0, file.Length);
            requestStream.Close();
          
        }


        public static bool MostrarArchivoDelServidor(Uri serverUri)
        {
            FtpWebRequest UriSchemeFtp = (FtpWebRequest)WebRequest.Create(@"ftp://win5207.site4now.net/" + serverUri);
            if (serverUri.Scheme != Uri.UriSchemeFtp)
            {
                return false;
            }
            WebClient request = new WebClient();

            //Se supone que el sitio FTP utiliza el inicio de sesión anónimo.
                request.Credentials = new NetworkCredential("proyectoude", "pr0yect0ude2022");

            try
            {
                byte[] newFileData = request.DownloadData(serverUri.ToString());
                string fileString = System.Text.Encoding.UTF8.GetString(newFileData);
                Console.WriteLine(fileString);
            }
            catch (WebException e)
            {
                Console.WriteLine(e.ToString());
            }
            return true;
        }



    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace App_Ventas
{
    public class Util
    {
        public static bool validarEmail(string email)
        {
            string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                { return true; }
                else
                { return false; }
            }
            else
            { return false; }
        }
        public static string SwitchFecha(string fecha)
        {
            if (!fecha.Contains("-")) 
                return fecha;

            string[] partes = new string[2];
            partes = fecha.Split('-');
            return partes[2] + "-" + partes[1] + "-" + partes[0];
        }
        public static bool IsNumeric32(object value)
        {
            try
            {
                double i = Convert.ToInt32(value.ToString());
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public static bool IsDecimal(object value)
        {
            try
            {
                decimal i = Convert.ToDecimal(value.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool IsDateDDMMYYYY(string value)
        {
            try
            {
                //DateTime.Parse(value, System.Globalization.CultureInfo.InvariantCulture);
                DateTime.Parse(value, new CultureInfo("es-PE"));
                return (true);
            }
            catch
            {
                return (false);
            }
        }
        public static bool IsDate(string value)
        {
            try
            {
                DateTime.Parse(value, System.Globalization.CultureInfo.InvariantCulture);
                return (true);
            }
            catch
            {
                return (false);
            }
        }
        public static bool EliminarFila(DataTable dt,string campoid,string id)
        {
            bool eliminado = false;
            for (int i = 0; i<dt.Rows.Count; i++)
            {
                DataRow f = dt.Rows[i];

                if (f[campoid].ToString()== id)
                {
                    f.Delete();
                    eliminado = true;
                    break;
                }
            }
            return eliminado;
        }

        public static string EncriptarMD5(string contrasenia)
        {
            // encriptar contraseña en MD5
            StringBuilder pass = new StringBuilder();
            System.Security.Cryptography.MD5CryptoServiceProvider Md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            foreach (byte i in Md5.ComputeHash(Encoding.UTF8.GetBytes(contrasenia)))
            {
                pass.Append(i.ToString("x2").ToLower());
            }

            return pass.ToString();
        }
        //public static bool GenerarPDF(int idinsertado)
        //{
        //    DataTable odata = new DataTable();
        //    DataRow ofila;
        //    Contrato ocontrato = new Contrato();

        //    string[] mesLargo = { "", "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
        //    string[] numerocardinal = { "", "Primer", "Segundo", "Tercer", "Cuarto", "Quinto", "Sexto" };

        //    // leo los datos para el documento
        //    //myDataSet = mydocumento.datosdeDocEmitido(Convert.ToInt32(idInsertado));
        //    odata = ocontrato.InfoDeContrato(idinsertado);
        //    if (odata.Rows.Count == 0)
        //        return false;

        //    ofila = odata.Rows[0];

        //    DateTime fechacontrato = Convert.ToDateTime(ofila["fechacontrato"]);
        //    string tipodocumento = ofila["tipodocumento"].ToString();
        //    string numerodocumento = ofila["numerodocumento"].ToString();
        //    string nombrecliente = ofila["cliente"].ToString();
        //    string nombreencargado = ofila["encargado"].ToString();
        //    string nombrefallecido = ofila["fallecido"].ToString();

        //    string dnicliente = ofila["dnicliente"].ToString();
        //    string direccioncliente = ofila["direccioncliente"].ToString();
        //    string celularcliente = ofila["celularcliente"].ToString();
        //    string direccionsepelio = ofila["direccionsepelio"].ToString();

        //    // creamos el pdf. configuramos para que el tamaño de hoja sea 70mm
        //    Rectangle pageSize = new Rectangle(PageSize.A4);
        //    //Document documentodecontrato= new Document(pageSize, 85, 95, 80, 80);
        //    Document documentodecontrato = new Document(pageSize, 85, 95, 40, 40);

        //    PdfWriter writercontrato;
            
        //    // ponemos información basica en documento virtual si o si
        //    documentodecontrato.AddAuthor("DonaghyDeveloper");
        //    documentodecontrato.AddCreator("DonaghyDeveloper");
        //    documentodecontrato.AddCreationDate();
        //    documentodecontrato.AddTitle("Contrato");
        //    documentodecontrato.AddSubject("Contrato");
        //    documentodecontrato.AddKeywords("Podesta, Contrato");
        //    //
        //    //Crear pdf
        //    FileStream myPDF = new FileStream(HttpContext.Current.Server.MapPath("~/docs/contrato/" + idinsertado.ToString() + ".pdf"), FileMode.Create);
        //    writercontrato = PdfWriter.GetInstance(documentodecontrato, myPDF);
        //    writercontrato.ViewerPreferences = PdfWriter.PageLayoutSinglePage;
        //    writercontrato.SetEncryption(PdfWriter.STRENGTH128BITS, "", ConfigurationManager.AppSettings["PassPDF"], PdfWriter.AllowPrinting);

        //    documentodecontrato.Open();
        //    //
        //    // defino fonts en general
        //    Font    myfont,
        //            myfontcursiva, 
        //            myfonttable, 
        //            myfonttablehead, 
        //            myfontBig, 
        //            myTitle;

        //    myfont = new iTextSharp.text.Font(FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL));
        //    myfontcursiva = new iTextSharp.text.Font(FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.ITALIC));
        //    myfonttable = new iTextSharp.text.Font(FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL));
        //    myfonttablehead = new iTextSharp.text.Font(FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD));
        //    myfontBig = new iTextSharp.text.Font(FontFactory.GetFont(FontFactory.HELVETICA, 24, Font.NORMAL));
        //    myTitle = new iTextSharp.text.Font(FontFactory.GetFont(FontFactory.HELVETICA, 20, Font.BOLD | Font.UNDERLINE));
            
        //    // ADICIONO CONTENIDO                    
        //    Paragraph miparrafo, saltoparrafo;
        //    saltoparrafo = new Paragraph("\n", myfont);

        //    // TITULO
        //    string direccionfuneraria = "Avenida Bolognesi N° 361(Esq. Av. Billinghurst S/N Costado SERPOST)";
        //    string contactofuneraria = "Telefax: (052)246402 Cel: 952637237 Tacna-Perú";

        //    miparrafo = new Paragraph(Espacios(15)+direccionfuneraria+"\n"+contactofuneraria, myfontcursiva);
        //    miparrafo.Alignment = Element.ALIGN_CENTER;
        //    documentodecontrato.Add(miparrafo);

        //    miparrafo = new Paragraph("Contrato N° "+idinsertado.ToString().PadLeft(4,'0') + "\n\n", myTitle);
        //    miparrafo.Alignment = Element.ALIGN_CENTER;
        //    documentodecontrato.Add(miparrafo);

        //    #region Contenido del Contrato
        //    //
        //    #region General
        //    PdfPTable tablacontenido = new PdfPTable(4);
        //    tablacontenido.WidthPercentage = 100f;

        //    float[] widths = new float[] { 30, 40, 15, 20 };
        //    tablacontenido.SetWidths(widths);

        //    PdfPCell celda=new PdfPCell();
        //    celda.HorizontalAlignment = Element.ALIGN_LEFT;
        //    celda.PaddingTop = 5;
        //    celda.PaddingBottom = 5;

        //    celda.Phrase = new Phrase("Señor(a):", myfonttablehead);
        //    tablacontenido.AddCell(celda);

        //    celda.Phrase = new Phrase(nombrecliente, myfont);
        //    celda.Colspan = 3;
        //    tablacontenido.AddCell(celda);

        //    celda.Phrase = new Phrase("DNI:", myfonttablehead);
        //    celda.Colspan = 1;
        //    tablacontenido.AddCell(celda);

        //    celda.Phrase = new Phrase(dnicliente.PadLeft(8,'0'), myfonttablehead);
        //    tablacontenido.AddCell(celda);

        //    celda.Phrase = new Phrase("Celular:", myfonttablehead);
        //    tablacontenido.AddCell(celda);

        //    celda.Phrase = new Phrase(celularcliente, myfont);
        //    tablacontenido.AddCell(celda);

        //    celda.Phrase = new Phrase("Dirección:", myfonttablehead);
        //    tablacontenido.AddCell(celda);

        //    celda.Phrase = new Phrase(direccioncliente, myfont);
        //    celda.Colspan = 3;
        //    tablacontenido.AddCell(celda);

        //    celda.Phrase = new Phrase("Dirección Sepelio:", myfonttablehead);
        //    celda.Colspan = 1;
        //    tablacontenido.AddCell(celda);

        //    celda.Phrase = new Phrase(direccionsepelio, myfont);
        //    celda.Colspan = 3;
        //    tablacontenido.AddCell(celda);

        //    documentodecontrato.Add(tablacontenido);
        //    #endregion

        //    #region Productos de Contrato
        //    miparrafo = new Paragraph("Productos Funerarios" + "\n\n", myfonttablehead);
        //    miparrafo.Alignment = Element.ALIGN_LEFT;
        //    documentodecontrato.Add(miparrafo);

        //    PdfPTable tablaproductos = new PdfPTable(3);
        //    tablaproductos.WidthPercentage = 100f;

        //    widths = new float[] { 20, 60, 20 };
        //    tablaproductos.SetWidths(widths);

        //    celda = new PdfPCell(new Phrase("Código", myfonttablehead));
        //    celda.HorizontalAlignment = Element.ALIGN_CENTER;
        //    tablaproductos.AddCell(celda);

        //    celda = new PdfPCell(new Phrase("Producto", myfonttablehead));
        //    celda.HorizontalAlignment = Element.ALIGN_CENTER;
        //    tablaproductos.AddCell(celda);

        //    celda = new PdfPCell(new Phrase("Precio", myfonttablehead));
        //    celda.HorizontalAlignment = Element.ALIGN_CENTER;
        //    tablaproductos.AddCell(celda);

        //    odata = ocontrato.ItemsDeContrato(idinsertado);
        //    decimal sumaproductos = 0;
        //    for (int i = 0; i < odata.Rows.Count; i++)
        //    {
        //        DataRow row = odata.Rows[i];

        //        celda = new PdfPCell(new Phrase(row["iditemadquisicion"].ToString(), myfont));
        //        celda.HorizontalAlignment = Element.ALIGN_CENTER;
        //        tablaproductos.AddCell(celda);

        //        celda = new PdfPCell(new Phrase(row["producto"].ToString(), myfont));
        //        celda.HorizontalAlignment = Element.ALIGN_CENTER;
        //        tablaproductos.AddCell(celda);

        //        celda = new PdfPCell(new Phrase(string.Format("{0:0.00}",row["precioventa"]), myfont));
        //        celda.HorizontalAlignment = Element.ALIGN_CENTER;
        //        tablaproductos.AddCell(celda);
                
        //        // agregar a sumatoria
        //        sumaproductos += Convert.ToDecimal(row["precioventa"]);
        //    }

        //    celda = new PdfPCell(new Phrase("TOTAL S/" + Espacios(12), myfonttablehead));
        //    celda.HorizontalAlignment = Element.ALIGN_RIGHT;
        //    celda.Colspan = 2;
        //    tablaproductos.AddCell(celda);

        //    celda = new PdfPCell(new Phrase(sumaproductos.ToString(), myfonttablehead));
        //    celda.HorizontalAlignment = Element.ALIGN_CENTER;
        //    tablaproductos.AddCell(celda);

        //    documentodecontrato.Add(tablaproductos);

        //    #endregion

        //    #region Servicios de Contrato
        //    miparrafo = new Paragraph("Servicios Funerarios" + "\n\n", myfonttablehead);
        //    //miparrafo.Leading = myLeading;
        //    miparrafo.Alignment = Element.ALIGN_LEFT;
        //    documentodecontrato.Add(miparrafo);

        //    PdfPTable tablaservicios = new PdfPTable(3);
        //    tablaservicios.WidthPercentage = 100f;

        //    widths = new float[] { 40, 40, 20 };
        //    tablaservicios.SetWidths(widths);

        //    celda = new PdfPCell(new Phrase("Descripcion", myfonttablehead));
        //    celda.HorizontalAlignment = Element.ALIGN_CENTER;
        //    tablaservicios.AddCell(celda);

        //    celda = new PdfPCell(new Phrase("Tipo", myfonttablehead));
        //    celda.HorizontalAlignment = Element.ALIGN_CENTER;
        //    tablaservicios.AddCell(celda);

        //    celda = new PdfPCell(new Phrase("Precio", myfonttablehead));
        //    celda.HorizontalAlignment = Element.ALIGN_CENTER;
        //    tablaservicios.AddCell(celda);

        //    odata = ocontrato.ServiciosDeContrato(idinsertado);
        //    decimal sumaservicios = 0;
        //    for (int i = 0; i < odata.Rows.Count; i++)
        //    {
        //        DataRow row = odata.Rows[i];

        //        celda = new PdfPCell(new Phrase(row["descripcion"].ToString(), myfont));
        //        celda.HorizontalAlignment = Element.ALIGN_CENTER;
        //        tablaservicios.AddCell(celda);

        //        celda = new PdfPCell(new Phrase(row["tipo"].ToString(), myfont));
        //        celda.HorizontalAlignment = Element.ALIGN_CENTER;
        //        tablaservicios.AddCell(celda);

        //        celda = new PdfPCell(new Phrase(string.Format("{0:0.00}",row["precio"]), myfont));
        //        celda.HorizontalAlignment = Element.ALIGN_CENTER;
        //        tablaservicios.AddCell(celda);
        //        sumaservicios += Convert.ToDecimal(row["precio"]);
        //    }

        //    // SUMA DE SERVICIOS TOTAL
        //    celda = new PdfPCell(new Phrase("TOTAL S/" + Espacios(12), myfonttablehead));
        //    celda.HorizontalAlignment = Element.ALIGN_RIGHT;
        //    celda.Colspan = 2;
        //    tablaservicios.AddCell(celda);

        //    celda = new PdfPCell(new Phrase(sumaservicios.ToString(), myfonttablehead));
        //    celda.HorizontalAlignment = Element.ALIGN_CENTER;
        //    tablaservicios.AddCell(celda);

        //    documentodecontrato.Add(tablaservicios);
        //    #endregion

        //    #region Financiamientos de Contrato
        //    // FINANCIAMIENTOS
        //    miparrafo = new Paragraph("Financiamientos\n\n", myfonttablehead);
        //    miparrafo.Alignment = Element.ALIGN_LEFT;
        //    documentodecontrato.Add(miparrafo);

        //    PdfPTable tablafinanciamiento = new PdfPTable(4);
        //    tablafinanciamiento.WidthPercentage = 100f;

        //    widths = new float[] { 40, 20, 20, 20 };
        //    tablafinanciamiento.SetWidths(widths);

        //    celda = new PdfPCell(new Phrase("Fuente", myfonttablehead)); // descripcion
        //    celda.HorizontalAlignment = Element.ALIGN_CENTER;
        //    tablafinanciamiento.AddCell(celda);
            
        //    celda = new PdfPCell(new Phrase("F. Presentacion", myfonttablehead));
        //    celda.HorizontalAlignment = Element.ALIGN_CENTER;
        //    tablafinanciamiento.AddCell(celda);

        //    celda = new PdfPCell(new Phrase("F. Pago", myfonttablehead));
        //    celda.HorizontalAlignment = Element.ALIGN_CENTER;
        //    tablafinanciamiento.AddCell(celda);

        //    celda = new PdfPCell(new Phrase("Monto", myfonttablehead));
        //    celda.HorizontalAlignment = Element.ALIGN_CENTER;
        //    tablafinanciamiento.AddCell(celda);

        //    odata = ocontrato.FinanciamientosDeContrato(idinsertado);
        //    decimal sumafinanciamiento = 0;
        //    for (int i = 0; i < odata.Rows.Count; i++)
        //    {
        //        DataRow row = odata.Rows[i];

        //        celda = new PdfPCell(new Phrase(row["descripcion"].ToString(), myfont));
        //        celda.HorizontalAlignment = Element.ALIGN_CENTER;
        //        tablafinanciamiento.AddCell(celda);

        //        celda = new PdfPCell(new Phrase(row["fechapresentacion"].ToString(), myfont));
        //        celda.HorizontalAlignment = Element.ALIGN_CENTER;
        //        tablafinanciamiento.AddCell(celda);

        //        celda = new PdfPCell(new Phrase(row["fechapago"].ToString(), myfont));
        //        celda.HorizontalAlignment = Element.ALIGN_CENTER;
        //        tablafinanciamiento.AddCell(celda);

        //        celda = new PdfPCell(new Phrase(row["importe"].ToString(), myfont));
        //        celda.HorizontalAlignment = Element.ALIGN_CENTER;
        //        tablafinanciamiento.AddCell(celda);

        //        sumafinanciamiento += Convert.ToDecimal(row["importe"]);
        //    }

        //    // SUMAS FINANCIAMIENTO
        //    celda = new PdfPCell(new Phrase("TOTAL S/"+Espacios(12), myfonttablehead));
        //    celda.HorizontalAlignment = Element.ALIGN_RIGHT;
        //    celda.Colspan = 3;
        //    tablafinanciamiento.AddCell(celda);

        //    celda = new PdfPCell(new Phrase(string.Format("{0:0.00}",sumafinanciamiento), myfonttablehead));
        //    celda.HorizontalAlignment = Element.ALIGN_CENTER;
        //    tablafinanciamiento.AddCell(celda);

        //    documentodecontrato.Add(tablafinanciamiento);
        //    #endregion

        //    //documentodecontrato.Add(saltoparrafo);

        //    #region TOTALES
        //    miparrafo = new Paragraph("Resumen\n\n", myfonttablehead);
        //    miparrafo.Alignment = Element.ALIGN_LEFT;
        //    documentodecontrato.Add(miparrafo);

        //    PdfPTable tablatotales = new PdfPTable(3);
        //    tablatotales.WidthPercentage = 100f;

        //    widths = new float[] { 33, 33, 34 };
        //    tablatotales.SetWidths(widths);

        //    celda = new PdfPCell(new Phrase("Total", myfonttablehead)); // descripcion
        //    celda.HorizontalAlignment = Element.ALIGN_CENTER;
        //    tablatotales.AddCell(celda);

        //    celda = new PdfPCell(new Phrase("A Cuenta", myfonttablehead));
        //    celda.HorizontalAlignment = Element.ALIGN_CENTER;
        //    tablatotales.AddCell(celda);

        //    celda = new PdfPCell(new Phrase("Saldo Pendiente", myfonttablehead));
        //    celda.HorizontalAlignment = Element.ALIGN_CENTER;
        //    tablatotales.AddCell(celda);

        //    celda = new PdfPCell(new Phrase(string.Format("{0:S/ 0.00}",sumaproductos+sumaservicios), myfonttablehead)); // descripcion
        //    celda.HorizontalAlignment = Element.ALIGN_CENTER;
        //    tablatotales.AddCell(celda);

        //    celda = new PdfPCell(new Phrase(string.Format("{0:S/ 0.00}", sumafinanciamiento), myfonttablehead));
        //    celda.HorizontalAlignment = Element.ALIGN_CENTER;
        //    tablatotales.AddCell(celda);

        //    celda = new PdfPCell(new Phrase(string.Format("{0:S/ 0.00}", sumaproductos + sumaservicios-sumafinanciamiento), myfonttablehead));
        //    celda.HorizontalAlignment = Element.ALIGN_CENTER;
        //    tablatotales.AddCell(celda);

        //    documentodecontrato.Add(tablatotales);
        //    #endregion

        //    #endregion

        //    // FIRMAS
        //    documentodecontrato.Add(saltoparrafo);
        //    documentodecontrato.Add(saltoparrafo);
        //    documentodecontrato.Add(saltoparrafo);

        //    miparrafo = new Paragraph(".........................................."+ Espacios(30)+ "..........................................", myfont);
        //    documentodecontrato.Add(miparrafo);

        //    miparrafo = new Paragraph(Espacios(15)+"CLIENTE" + Espacios(57) + "GERENTE", myfont);
        //    documentodecontrato.Add(miparrafo);

        //    documentodecontrato.Add(saltoparrafo);
        //    // Fecha de constancia 
        //    DateTime fechaEmision = fechacontrato;
        //    miparrafo = new Paragraph("\nTacna, " + fechaEmision.Day.ToString().PadLeft(2, '0') + " de " + mesLargo[fechaEmision.Month] + " del " + fechaEmision.Year.ToString(), myfont);
        //    miparrafo.Alignment = Element.ALIGN_RIGHT;
        //    //miparrafo.Leading = myLeading;
        //    documentodecontrato.Add(miparrafo);

        //    // AGREGAR DIRECCION PARA VER DOCUMENTO EN LINEA Y FIRMA SI ES VIRTUAL

        //    /* Mensaje en imagen */
        //    //System.Drawing.Bitmap bitmap_mensaje = global.convertirTextoImagen("Puede ver la copia en la pagina web, si no es idéntica, el documento es falso: \n" + "http://activa.neumann.edu.pe/verdocumento.aspx?d=" + idInsertado, 320, 40);
        //    //iTextSharp.text.Image imgMensajeLegalidad = iTextSharp.text.Image.GetInstance((System.Drawing.Image)bitmap_mensaje, System.Drawing.Imaging.ImageFormat.Jpeg);

        //    // LOGO IZQUIERDO SUPERIOR
        //    iTextSharp.text.Image imglogo = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("~/img/logo_new.jpg"));
        //    imglogo.ScaleAbsolute(150, 50);
        //    imglogo.SetAbsolutePosition(10, 770);
        //    //imglogo.Alignment = Element.ALIGN_TOP;
        //    documentodecontrato.Add(imglogo);

        //    /* Codigo QR */
        //    ZXing.BarcodeWriter encoder = new ZXing.BarcodeWriter();
        //    encoder.Format = ZXing.BarcodeFormat.QR_CODE;
        //    encoder.Options.Width = 80;
        //    encoder.Options.Height = 80;
        //    encoder.Options.Margin = 0;

        //    System.Drawing.Bitmap bitmap_qr = encoder.Write("http://podesta365.com/frmvercontrato.aspx?c=" + idinsertado.ToString());
        //    iTextSharp.text.Image imgSelloQR = iTextSharp.text.Image.GetInstance((System.Drawing.Image)bitmap_qr, System.Drawing.Imaging.ImageFormat.Jpeg);

        //    /* AGREGAR Mensaje y codigo QR*/
        //    //imgMensajeLegalidad.SetAbsolutePosition(235, 30);
        //    //imgMensajeLegalidad.Alignment = iTextSharp.text.Image.UNDERLYING;
        //    imgSelloQR.Border = 0;
        //    imgSelloQR.SetAbsolutePosition(10, 10);
        //    imgSelloQR.Alignment = iTextSharp.text.Image.UNDERLYING;
        //    documentodecontrato.Add(imgSelloQR);

        //    System.Drawing.Bitmap bitmap_mensaje = convertirTextoImagen("Puede ver el contrato en: http://podesta365.com/frmvercontrato.aspx?c=" + idinsertado.ToString(), 320, 40);
        //    iTextSharp.text.Image imgMensajeLegalidad = iTextSharp.text.Image.GetInstance((System.Drawing.Image)bitmap_mensaje, System.Drawing.Imaging.ImageFormat.Jpeg);
        //    imgMensajeLegalidad.SetAbsolutePosition(100, 0);
        //    documentodecontrato.Add(imgMensajeLegalidad);
        //    //
        //    documentodecontrato.Close();
            
        //    return true;
        //}
        public static System.Drawing.Bitmap convertirTextoImagen(string texto, int ancho, int alto)
        {
            //creamos el objeto imagen Bitmap 
            System.Drawing.Bitmap objLienzo = new System.Drawing.Bitmap(ancho, alto);
            System.Drawing.Graphics objGraficar = System.Drawing.Graphics.FromImage(objLienzo);
            System.Drawing.Color objColor = System.Drawing.Color.White;
            System.Drawing.Font objFont = new System.Drawing.Font(System.Drawing.FontFamily.GenericSansSerif, 7);
            System.Drawing.PointF objCoordenadas = new System.Drawing.PointF(1, 1);
            System.Drawing.SolidBrush objPincelFondo = new System.Drawing.SolidBrush(objColor);
            System.Drawing.SolidBrush objPincelTexto = new System.Drawing.SolidBrush(System.Drawing.Color.Black);

            objGraficar.FillRectangle(objPincelFondo, 0, 0, 320, 40);
            objGraficar.DrawString(texto, objFont, objPincelTexto, objCoordenadas);

            return objLienzo;
        }
        static string Espacios(int num)
        {
            return new string(' ', num);
        }
    }
}
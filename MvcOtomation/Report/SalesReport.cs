using MvcOtomation.Models.Classes;
using System.IO;
using IronPdf;
using System.Web.Mvc;
using System;
using System.Text;

public class SalesReport : Controller
{

    public void Olustur(SalesTransaction sales)
    {
        var Renderer = new HtmlToPdf();
        
        StringBuilder htmlContent = new StringBuilder();
        htmlContent.AppendLine("<!DOCTYPE html><html><head><meta charset="+"utf - 8"+"/><style>.invoice-box{max-width: 800px;margin: auto;padding: 30px;border: 1px solid #eee;box-shadow: 0 0 10px rgba(0+ 0+ 0+ 0.15);font-size: 16px;line-height: 24px;font-family: 'Helvetica Neue'+ 'Helvetica'+ Helvetica+ Arial+ sans-serif;color: #555;}.invoice-box table{width: 100%;line-height: inherit;text-align: left;}.invoice-box table td{padding: 5px;vertical-align: top;}.invoice-box table tr td:nth-child(2){text-align: right;}.invoice-box table tr.top table td{padding-bottom: 20px;}.invoice-box table tr.top table td.title{font-size: 45px;line-height: 45px;color: #333;}.invoice-box table tr.information table td{padding-bottom: 40px;}.invoice-box table tr.heading td{background: #eee;border-bottom: 1px solid #ddd;font-weight: bold;}.invoice-box table tr.details td{padding-bottom: 20px;}.invoice-box table tr.item td{border-bottom: 1px solid #eee;}.invoice-box table tr.item.last td{border-bottom: none;}.invoice-box table tr.total td:nth-child(2){border-top: 2px solid #eee;font-weight: bold;}@media only screen and (max-width: 600px){.invoice-box table tr.top table td{width: 100%;display: block;text-align: center;}.invoice-box table tr.information table td{width: 100%;display: block;text-align: center;}}/** RTL **/.invoice-box.rtl{direction: rtl;font-family: Tahoma+ 'Helvetica Neue'+ 'Helvetica'+ Helvetica+ Arial+ sans-serif;}.invoice-box.rtl table{text-align: right;}.invoice-box.rtl table tr td:nth-child(2){text-align: left;}</style></head><body><div class="+"invoice - box"+"><table cellpadding="+"0"+" cellspacing="+"0"+"><tr class="+"top"+"><td colspan="+"2"+"><table><tr><td class="+"title"+"><p style="+"font - size:70px"+">&#128188;Özbek LTD</p></td>");
        htmlContent.AppendLine("<td>Sales #: "+ sales.Id + "<br/>Created: "+sales.Time+"<br/>Due: February 1, 2015</td>");
        htmlContent.AppendLine("</tr></table></td></tr><tr class="+"information"+"><td colspan="+"2"+"><table><tr><td>Ankara TeknoPark<br/>12345 Sunny Road<br/>Sunnyville, CA 12345</td><td>" + sales.Employee.Name + "<br/>" + sales.Employee.Name + "<br/></td></tr></table></td></tr><tr class="+"heading"+"><td>Product</td><td></td></tr><tr class="+"details"+"><td>Product Id</td><td>" + sales.Product.Id + "</td></tr><tr class="+"details"+"><td>Product Name</td><td>" + sales.Product.Name + "</td></tr><tr class="+"details"+"><td>Product Brand</td><td>" + sales.Product.Brand + "</td></tr><tr class="+"heading"+"><td>Item</td><td>Price</td></tr><tr class="+"item"+"><td>" + sales.Product.Name + "</td><td>" + sales.UnitPrice + "</td></tr><tr class="+"total"+"><td></td><td>Total: " + sales.Amount + "</td></tr></table></div></body></html>");
        


        string htmlString = htmlContent.ToString();
        MemoryStream rend = Renderer.RenderHtmlAsPdf(htmlString).Stream;

        HttpContext.Response.AddHeader("Content-Type", "application/pdf");

        HttpContext.Response.AddHeader("Content-Disposition", String.Format("{0}; filename=Print.pdf; size={1}",
          "attachment", rend.Length.ToString()));

        HttpContext.Response.BinaryWrite(rend.ToArray());

        HttpContext.Response.End();

    }

}





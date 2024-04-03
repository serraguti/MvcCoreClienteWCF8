using Microsoft.CodeAnalysis.CSharp.Syntax;
using MvcCoreClienteWCF8.Helpers;
using MvcCoreClienteWCF8.Models;
using System.Xml.Linq;

namespace MvcCoreClienteWCF8.Repositories
{
    public class RepositoryClientesXML
    {
        private HelperPathProvider helper;

        public RepositoryClientesXML(HelperPathProvider helper)
        {
            this.helper = helper;
        }

        public List<Cliente> GetClientes()
        {
            string path = this.helper.MapPath
                ("ClientesID.xml", Folders.Documents);
            //LA CLASE XDocument NOS PERMITE UTILIZAR LINQ TO XML
            XDocument document = XDocument.Load(path);
            //from datos in document.Descendants("TAG")
            //select datos;
            var consulta = from datos in document.Descendants("CLIENTE")
                           select datos;
            //EXTRAEMOS LOS ELEMENTOS XElement de la consulta
            List<Cliente> clientesList = new List<Cliente>();
            foreach (XElement tag in consulta)
            {
                Cliente cliente = new Cliente();
                //PODEMOS RECUPERAR TANTO ATRIBUTOS COMO DATOS DE ETIQUETA
                //tag.Attributes("ATTRIBUTE").Value
                //tag.Element("ELEMENT").Value
                cliente.IdCliente = int.Parse(tag.Element("IDCLIENTE").Value);
                cliente.Nombre = tag.Element("NOMBRE").Value;
                cliente.Direccion = tag.Element("DIRECCION").Value;
                cliente.Email = tag.Element("EMAIL").Value;
                cliente.ImagenCliente = tag.Element("IMAGENCLIENTE").Value;
                clientesList.Add(cliente);
            }
            return clientesList;
        }

        public Cliente FindCliente(int idCliente)
        {
            string path = this.helper.MapPath("ClientesID.xml"
                , Folders.Documents);
            XDocument document = XDocument.Load(path);
            //VAMOS A REALIZAR LA CONSULTA GENERANDO DIRECTAMENTE
            //LAS CLASES QUE NECESITAMOS MAPEAR (Cliente)
            var consulta = from datos in document.Descendants("CLIENTE")
                           where datos.Element("IDCLIENTE").Value ==
                           idCliente.ToString()
                           select new Cliente() { 
IdCliente = int.Parse(datos.Element("IDCLIENTE").Value),
Nombre = datos.Element("NOMBRE").Value,
Direccion = datos.Element("DIRECCION").Value,
Email = datos.Element("EMAIL").Value,
ImagenCliente = datos.Element("IMAGENCLIENTE").Value
                           };
            return consulta.FirstOrDefault();
        }
    }
}

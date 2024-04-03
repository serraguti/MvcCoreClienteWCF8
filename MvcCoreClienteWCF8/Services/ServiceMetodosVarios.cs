using ServiceReferenceMetodosVarios;

namespace MvcCoreClienteWCF8.Services
{
    public class ServiceMetodosVarios
    {
        MetodosVariosContractClient client;

        public ServiceMetodosVarios(MetodosVariosContractClient client)
        {
            this.client = client;
        }

        public async Task<int[]> GetTablaMultiplicarAsync(int numero)
        {
            int[] datos =
            await this.client.GetTablaMultiplicarAsync(numero);
            return datos;
        }
    }
}

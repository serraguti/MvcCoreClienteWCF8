using ServiceReferenceEscenas;

namespace MvcCoreClienteWCF8.Services
{
    public class ServiceEscenas
    {
        EscenasContractClient client;

        public ServiceEscenas(EscenasContractClient client)
        {
            this.client = client;
        }

        public async Task<Escena[]> GetEscenasAsync()
        {
            //Escena[] escenas = await this.client.GetEscenasAsync();
            Escena[] escenas =
                await this.client.GetEscenasAsync();
            return escenas;
        }

        public async Task<Escena[]> GetEscenasPelis(int idpeli)
        {
            Escena[] escenas =
                await this.client.GetEscenasPeliculaAsync(idpeli);
            return escenas;
        }
    }
}

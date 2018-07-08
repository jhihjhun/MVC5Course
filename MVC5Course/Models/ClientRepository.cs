using System;
using System.Linq;
using System.Collections.Generic;
using MVC5Course.ViewModels.Client;

namespace MVC5Course.Models
{
    public class ClientRepository : EFRepository<Client>, IClientRepository
    {
        public override IQueryable<Client> All()
        {
            return base.All();
        }

        public Client Find(int id)
        {
            return this.All().FirstOrDefault(p => p.ClientId == id);
        }

        public override void Delete(Client entity)
        {
            entity.IsDeleted = true;
        }
    }

    public  interface IClientRepository : IRepository<Client>
	{

	}
}
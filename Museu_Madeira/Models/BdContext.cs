using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using  System.Data.Entity;

namespace Museu_Madeira.Models
{
	public class BdContext : DbContext
	{
		public DbSet <Utilizador> ContaUtilizador{ get; set; }


	}
}
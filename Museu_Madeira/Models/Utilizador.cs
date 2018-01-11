using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Museu_Madeira.Models
{
	public class Utilizador
	{

		[Key]
		public int UtilizadorId { get; set; }


		[Required(ErrorMessage = "O nome é obrigatório")]
		public string Nome { get; set; }

		[RegularExpression(@"^[0-9]{9}$", ErrorMessage = "Numero de telefone invalido")]
		public int Telefone { get; set; }


		[RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email invalido")]
		public string Email { get; set; }

		[Required(ErrorMessage = "O username é obrigatório")]
		public  string Username { get; set; }

		[Required(ErrorMessage = "A password é obrigatória")]
		[DataType(DataType.Password)]
		public string Password { get; set; }


		[Compare("Password", ErrorMessage = "Confirme a sua password")]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; }




	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Nyous_API.Utils
{
    public static class Crypto
    {
		public static string Criptografar(string Txt, string Salt)
		{
			using (SHA256 sha256Hash = SHA256.Create())
			{
				//ComputeHash -> retorna uma array de bytes
				//A senha está concatenada com o Salt -> Salt+Txt
				byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(Salt+Txt));

				//Converterter array de bytes para string  
				StringBuilder builder = new StringBuilder();
				for (int i = 0; i < bytes.Length; i++)
				{
					builder.Append(bytes[i].ToString("x2"));
				}
				return builder.ToString();
			}
		}
	}
}

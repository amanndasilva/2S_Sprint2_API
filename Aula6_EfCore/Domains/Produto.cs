using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Aula6_EfCore.Domains
{
    /// <summary>
    /// Define a classe Produto
    /// </summary>
    public class Produto : BaseDomain
    {
        public string Nome { get; set; }
        public float Preco { get; set; }

        [NotMapped] //Não mapeia a propriedade no banco de dados
        [JsonIgnore] //Ignora propriedade no retorno no Json
        public IFormFile Imagem { get; set; }

        //Url da imagem do produto salva no servidor
        public string UrlImagem { get; set; }

        //Relacionamento com a tabela PedidoItem 1 -- N
        public List<PedidoItem> PedidosItens { get; set; }
    }
}

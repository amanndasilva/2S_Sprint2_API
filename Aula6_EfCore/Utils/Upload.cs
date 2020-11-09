using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Aula6_EfCore.Utils
{
    public static class Upload
    {
        public static string Local(IFormFile file)
        {
            //Gera o nome do arquivo único
            //Pega a extensão do arquivo
            //Concateno o nome do arquivo com a sua extensão
            //EX: gvfgsdt6f56hyg7f6.png
            var nomeArquivo = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);

            //GetCurrentDirectory -> pega o caminho do diretório atual
            var caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), @"wwwRoot\upload\imagens", nomeArquivo);

            //Cria um obj do tipo FileStream passando o caminho do arquivo
            //Passa para criar este arquivo
            using var streamImagem = new FileStream(caminhoArquivo, FileMode.Create);

            //Executa o comando de criação do arquivo no local informado
            file.CopyTo(streamImagem);

            //Aws, Azure, Cloud, Storage
            //var urlImagem = Chamada ao método.Salvar(nomearquivo)

            return "http://localhost:62314/upload/imagens/" + nomeArquivo;
        }
    }
}

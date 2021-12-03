using ApiCatalogoJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        public static Dictionary<Guid, Jogo> jogos = new Dictionary<Guid, Jogo>()
        {
            {Guid.Parse("ljililjiljkljik"), new Jogo{Id = Guid.Parse("dfgsdfgsdfgsfg"), Nome = "GTA I", Produtora = "Rockstar", Preco = 20} },
            {Guid.Parse("jkltghnmghjjjhg"), new Jogo{Id = Guid.Parse("ajfgjghkgukguf"), Nome = "GTA II", Produtora = "Rockstar", Preco = 22} },
            {Guid.Parse("qdwdadwdawaddsg"), new Jogo{Id = Guid.Parse("sdgshaadhadfgg"), Nome = "GTA III", Produtora = "Rockstar", Preco = 25} },
            {Guid.Parse("dbcfcgsrefvxcvf"), new Jogo{Id = Guid.Parse("lyumghjyjghjjg"), Nome = "GTA IV", Produtora = "Rockstar", Preco = 50} },
            {Guid.Parse("lglkghnnvmimrmv"), new Jogo{Id = Guid.Parse("klsdafoasifasd"), Nome = "GTA V", Produtora = "Rockstar", Preco = 90} },
        };

        public Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(jogos.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }

        public Task<Jogo> Obter(Guid id)
        {
            if (!jogos.ContainsKey(id))
                return null;

            return Task.FromResult(jogos[id]);
        }

        public Task<List<Jogo>> Obter(string nome, string produtora)
        {
            return Task.FromResult(jogos.Values.Where(jogo => jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora)).ToList());
        }

        public Task<List<Jogo>> ObterSemLambda(string nome, string produtora)
        {
            var retorno = new List<Jogo>();

            foreach (var jogo in jogos.Values)
            {
                if (jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora))
                    retorno.Add(jogo);
            }

            return Task.FromResult(retorno);
        }

        public Task Inserir(Jogo jogo)
        {
            jogos.Add(jogo.Id, jogo);
            return Task.CompletedTask;
        }

        public Task Atualizar (Jogo jogo)
        {
            jogos[jogo.Id] = jogo;
            return Task.CompletedTask;
        }

        public Task Remover(Guid id)
        {
            jogos.Remove(id);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            //Fechar conexão com o banco de dados
        }
    }
}

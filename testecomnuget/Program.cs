using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testecomnuget
{

    [Serializable]
    public class testeObjeto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public testeItem item { get; set; }
        public List<Parametros> itTestes { get; set; }
    }

    [Serializable]
    public class testeItem
    {
        public int Id { get; set; }
        public string NomeItem { get; set; }
        public subItem Subitem { get; set; }
    }

    [Serializable]
    public class subItem
    {
        public int Id { get; set; }
        public string NomeSubItem { get; set; }
    }

    [Serializable]
    public class Parametros
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public List<ParametrosTipo> Tipos { get; set; }
    }

    [Serializable]
    public class ParametrosTipo
    {
        public int Id { get; set; }
        public string DescricaoTipo { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var tOrigem = new testeObjeto();
            tOrigem.Id = 1;
            tOrigem.Nome = "Vinicius";
            tOrigem.Endereco = "rua teste, 200";
            tOrigem.itTestes = new List<Parametros>() { new Parametros() { Id = 1, Descricao = "teste1" ,
                Tipos = new List<ParametrosTipo>(){ new ParametrosTipo(){Id = 1, DescricaoTipo = "novo"} }
            }, new Parametros() { Id = 2, Descricao = "teste2" } };
            tOrigem.item = new testeItem() { Id = 1, NomeItem = "teste item 3", Subitem = new subItem() { Id = 1, NomeSubItem = "teste sub1" } };

            var tNova = new testeObjeto();
            tNova.Id = 1;
            tNova.Nome = "Vinicius";
            tNova.Endereco = "rua teste, 2001";
            tNova.itTestes = new List<Parametros>() { new Parametros() { Id = 1, Descricao = "teste11" ,
                Tipos = new List<ParametrosTipo>(){ new ParametrosTipo(){Id = 1, DescricaoTipo = "novo"}}
            }, new Parametros() { Id = 2, Descricao = "teste2" } };
            tNova.item = new testeItem() { Id = 1, NomeItem = "teste item 31", Subitem = new subItem() { Id = 1, NomeSubItem = "teste sub11" } };

            Console.WriteLine(new ObjectCompare.Equals().EqualsObject<testeObjeto>(tOrigem, tNova));

            Console.WriteLine();

            var ret = new ObjectCompare.Equals().EqualsObject<testeObjeto>(tOrigem, tNova, true);

            foreach (DictionaryEntry iret in (IDictionary)ret)
            {
                Console.WriteLine(
                    string.Concat("Objeto -> ", iret.Key.ToString(), " Valor -> ", iret.Value.ToString()
                    )
                );
            }


            Console.ReadKey();
        }
    }
}


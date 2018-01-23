namespace TesteCarga.Migrations
{
    using Context;
    using Model;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Reflection;

    internal sealed class Configuration : DbMigrationsConfiguration<Context.TesteDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        public readonly string Root = AppDomain.CurrentDomain.BaseDirectory;
        protected override void Seed(TesteDataContext context)
        {
            CarregarUsuarios(context);
            context.SaveChanges();
        }


        private void CarregarUsuarios(TesteDataContext context)
        {
            //if (System.Diagnostics.Debugger.IsAttached == false)
            //{
            //    System.Diagnostics.Debugger.Launch();
            //}

            try
            {
                var path = Path.Combine(Root, Constante.DiretorioArquivo, Constante.NomeDoArquivo);
                var usuarios = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(path));
                context.Users.AddRange(usuarios);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }


    public static class Constante
    {
        public static readonly string NomeDoArquivo = "users.json";
        public static readonly string DiretorioArquivo = "Carga";
    }
}


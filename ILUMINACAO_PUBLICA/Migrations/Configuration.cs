using System.Web.Security;
using ILUMINACAO_PUBLICA.Models;
using WebMatrix.WebData;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace ILUMINACAO_PUBLICA.Migrations
{
    

    internal sealed class Configuration : DbMigrationsConfiguration<ILUMINACAO_PUBLICA.Models.ILUMINACAO_PUBLICAContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ILUMINACAO_PUBLICAContext context)
        {
            #region usuarios de teste
            SeedMembership();
            #endregion

            #region dados teste
           
            var santaRita = new Prefeitura{ Nome = "Santa Rita" };

            context.Prefeituras.AddOrUpdate(i => new { i.Nome }, santaRita);
            context.SaveChanges();

            var ocorrencia1 = new Ocorrencia { Nome = "Ocorrencia 1 ", PrefeituraId = santaRita.PrefeituraID};
            var ocorrencia2 = new Ocorrencia { Nome = "Ocorrencia 2" , PrefeituraId = santaRita.PrefeituraID};
          

            context.Ocorrencias.AddOrUpdate(i => new { i.Nome }, ocorrencia1, ocorrencia2);
            context.SaveChanges();

            var admin = new UserProfile { UserName = "admin", PrefeituraID = santaRita.PrefeituraID};
            var master = new UserProfile { UserName = "master", PrefeituraID = santaRita.PrefeituraID };
            var convidado = new UserProfile { UserName = "convidado", PrefeituraID = santaRita.PrefeituraID };
            var cliente = new UserProfile { UserName = "cliente", PrefeituraID = santaRita.PrefeituraID };
            context.UserProfiles.AddOrUpdate(i => new { i.UserName }, admin, master, convidado, cliente);
            context.SaveChanges();
            #endregion

        }


        private void SeedMembership()
        {

            /////////////////////////////PERFIS///////////////////////////////////////////////////////////////
            //•	Admin: uso pela DAIMON/MINIMO. Acesso (visualização e edição) a todas as funcionalidades do sistema para todas as distribuidoras.
            //•	Master: uso pela distribuidora. Acesso (visualização e edição) somente às funcionalidades do sistema da respectiva distribuidora.
            //•	Acompanhamento: Somente visualização (sem edição) das funcionalidades do sistema da respectiva distribuidora.
            //•	Convidado: somente visualização (sem edição) às informações do cenário autorizadas pelo usuário máster ou ADMIN.



            WebSecurity.InitializeDatabaseConnection("ILUMINACAO_PUBLICAContext", "UserProfile", "UserId", "UserName", autoCreateTables: true);
            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;

            if (!roles.RoleExists("Admin"))
            {
                roles.CreateRole("Admin");  // cria role Admin
            }
            if (!roles.RoleExists("Master"))
            {
                roles.CreateRole("Master");  // cria role Admin
            }

            if (!roles.RoleExists("Acompanhamento"))
            {
                roles.CreateRole("Acompanhamento");  // cria role Admin
            }
            if (!roles.RoleExists("Cliente"))
            {
                roles.CreateRole("Cliente");  // cria role Admin
            }

            if (membership.GetUser("admin", false) == null)
            {
                membership.CreateUserAndAccount("admin", "123123");  // cria usuario e senha

            }

            if (membership.GetUser("master", false) == null)
            {
                membership.CreateUserAndAccount("master", "123123"); // cria usuario e senha
            }

            if (membership.GetUser("acompanhamento", false) == null)
            {
                membership.CreateUserAndAccount("acompanhamento", "123123");  // cria usuario e senha

            }

            if (membership.GetUser("cliente", false) == null)
            {
                membership.CreateUserAndAccount("cliente", "123123"); // cria usuario e senha
            }

            if (!roles.GetRolesForUser("admin").Contains("Admin")) // ve se o usuario admin tem role Admin 
            {
                roles.AddUsersToRoles(new[] { "admin" }, new[] { "Admin" }); // se nao tem ou se ele nao existe, cria e da o role de Admin pra ele
            }

            if (!roles.GetRolesForUser("master").Contains("Master")) // ve se o usuario admin tem role Usuario 
            {
                roles.AddUsersToRoles(new[] { "master" }, new[] { "Master" }); // se nao tem ou se ele nao existe, cria e da o role de Admin pra ele
            }

            if (!roles.GetRolesForUser("acompanhamento").Contains("Acompanhamento")) // ve se o usuario admin tem role Admin 
            {
                roles.AddUsersToRoles(new[] { "acompanhamento" }, new[] { "Acompanhamento" }); // se nao tem ou se ele nao existe, cria e da o role de Admin pra ele
            }

            if (!roles.GetRolesForUser("cliente").Contains("Cliente")) // ve se o usuario admin tem role Usuario 
            {
                roles.AddUsersToRoles(new[] { "cliente" }, new[] { "Cliente" }); // se nao tem ou se ele nao existe, cria e da o role de Admin pra ele
            }

        }
    }
}

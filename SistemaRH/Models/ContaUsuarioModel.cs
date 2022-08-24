using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Authentication;
using Database.Entity;
using SistemaRH.Database.Data;

namespace WebApp.Models
{
    public class ContaUsuarioModel
    {
        //private async Task<AppUser> AuthenticateUser(string login, string password)
        //{
        //    if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
        //    {
        //        return null;
        //    }

        //    // For demonstration purposes, authenticate a user
        //    // with a static login name and password.
        //    // Assume that checking the database takes 500ms

        //    await Task.Delay(500);

        //    if (login.ToUpper() != "ADMINISTRATOR" || password != "P@ssw0rd")
        //    {
        //        return null;
        //    }

        //    return new AppUser() { LoginName = "Administrator" };
        //}

        public Usuario GetUsuarioByNomeDeUsuario(string nomeDeUsuario)
        {
            Usuario usuario = new Usuario();

            using (var context = new SistemaDbContext())
            {
                usuario = context.Usuario.Where(u => u.NomeDeUsuario == nomeDeUsuario).FirstOrDefault();
                context.DisposeAsync();
            }

            return usuario;
        }
    }
}

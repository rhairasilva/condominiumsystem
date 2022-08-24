using Database.Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebApp.Helpers;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ContaUsuarioController : Controller
    {
        static MensagemDeErro mensagemDeErro = new() { Mensagem = "Sem erro"};

        public IActionResult LoginUsuario()
        {
            return View(model: mensagemDeErro);
        }

        public IActionResult Configuracoes()
        {
            return View();
        }

        public async Task<IActionResult> FazerLoginUsuario(string nomeDeUsuario, string senha)
        {
            var usuario = AutenticarUsuario(nomeDeUsuario, senha);
            
            if (usuario == null)
            {
                return RedirectToAction(actionName: "LoginUsuario", controllerName: "ContaUsuario");
            }

            string role = "Comum";

            if (usuario.Admin)
            {
                role = "Administrador";
            }

            var claims = new List<Claim>
            {
                 new Claim(type: ClaimTypes.Name, value: usuario.NomeDeUsuario),
                 new Claim(type: ClaimTypes.Role, value: role)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }
        
        public async Task<IActionResult> FazerLogoutUsuario()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        private Usuario AutenticarUsuario(string nomeDeUsuario, string senha)
        {
            string stringHashSenha = GetHashString(senha).ToLower();

            if (string.IsNullOrEmpty(nomeDeUsuario) || string.IsNullOrEmpty(senha))
            {
                mensagemDeErro.Mensagem = "Nome de usuário e senha devem ser preenchidos!";
                return null;
            }

            ContaUsuarioModel contaUsuarioModel = new ContaUsuarioModel();

            Usuario usuario = contaUsuarioModel.GetUsuarioByNomeDeUsuario(nomeDeUsuario);

            if (usuario == null)
            {
                mensagemDeErro.Mensagem = "Usuário inexistente!";
                return null;
            }
            else if (usuario.Senha.ToLower() != stringHashSenha)
            {
                mensagemDeErro.Mensagem = "Senha incorreta. Caso tenha esquecido a senha, solicite uma nova senha a um administrador!";
                return null;
            }

            return usuario;
        }

        private byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
    }
}

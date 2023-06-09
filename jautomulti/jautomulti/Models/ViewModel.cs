﻿namespace jautomulti.Models
{
    public class CarrosViewModel
    {
        public int Id { get; set; }

        public string Matricula { get; set; }

        public string Tipo { get; set; }

        public string Cor { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public string Fotografia { get; set; }
        public string Proprietario { get; set; }

       
    }

    public class FotografiasViewModel
    {
        public int Id { get; set; }

        public string NomeFicheiro { get; set; }

    }

    public class ProprietariosViewModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Sexo { get; set; }


        public string Telemovel { get; set; }


        public string Email { get; set; }

        public string NIF { get; set; }

        ICollection<CarrosViewModel> Carros { get; set; }
    }

    public class RegisterViewModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }

}

﻿using FluentAssertions;
using EvidentInstruction.Helpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace EvidentInstruction.Database.Models
{
    public class DbConnectionParams
    {
        private string _password = string.Empty;

        [Required(ErrorMessage = "Source is required")]
        public string Source { get; set; } = null;
        [Required(ErrorMessage = "Database is required")]
        public string Database { get; set; } = null;
        [Required(ErrorMessage = "Login is required")]
        public string Login { get; set; } = null;
        [Required(ErrorMessage = "Password is required")]
        public string Password
        {
            get
            {
                var validPassword = string.Empty;
                var act = new Action(() => validPassword = Encryptor.Decrypt(_password));
                act.Should().NotThrow<FormatException>("Неверный пароль.");
                return validPassword;
            }
            set => _password = value;
        }
        public int? Timeout { get; set; } = 60;
    }
}
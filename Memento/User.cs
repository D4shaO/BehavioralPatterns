﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    enum UserRole { Admin, User, Guest}

    internal class User
    {
        private string _login;
        private string _password;  
        private UserRole _role;
        private Caretaker _caretacker = new Caretaker();

        public string Login { get => _login; }
        public string Password
        {
            get => _password;
            set
            {
                if (value.Length > 5) _password = value;
                else throw new ArgumentException("длина пароля не соответствует");
            }
        }
        public UserRole Role { get => _role; set => _role = value; }

        public User(string login, string password)
        {
            _login = login;
            Password = password;
            Role = UserRole.Guest;
        }

        public void ChangeRole(UserRole role)
        {
            Role = role;
        }

        public void SaveState()
        {
            _caretacker.Memento = new Memento(this._password, this._role);
        }
        public void LoadState()
        {
            _password = _caretacker.Memento.GetSavedState(out _role);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ART
{
    [Serializable]
    internal class User //Blok zodpovědný za informace o uživateli (Блок, отвечающий за информацию о пользователе)
    {

        public string Name { get; set; } // Имя пользователя
        public string Password { get; set; } // Пароль пользователя
        
        public EAccess Access { get; set; } // Уровень доступа пользователя

        public int Balans { get; set; } // Баланс пользователя
        public List<Ticket> Ticket { get; set; } // Список билетов пользователя

        public User() { } // Пустой конструктор
        public User(string name,string password,EAccess access,int balanse) // Конструктор с параметрами
        {
            Name = name; // Имя пользователя
            Password = password; // Пароль пользователя
            Access = access; // Уровень доступа пользователя
            Ticket = new List<Ticket>(); // Создание нового списка билетов
            Balans = balanse; // Баланс пользователя
        }
        
    }
}
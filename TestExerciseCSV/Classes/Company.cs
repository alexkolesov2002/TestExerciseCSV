using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestExerciseCSV
{
    /// <summary>
    /// Класс с информацией о компании
    /// </summary>
    public class Company
    {
        public string CompanyName { get; set; } //Название компании
        public string ?CompanyEmail { get; set; } //Емейлы компании 
        public string ?CompanyPhone { get; set; } //Телефоны компании
        public string ?BufferString { get; set; } //Буферная строка для обработки файла


        public List<string> CompanyPhoneList { get; set; } = new List<string>(); //Лист уникальных телефонов компании
        public List<string> CompanyEmailList { get; set; } = new List<string>();  //Лист уникальных Емейлов  компании
        /// <summary>
        /// Переопределенный метод Equals, необходимый для ассоциаци элемментов листа с одинаковыми названиями компаний
        /// </summary>
        /// <param name="obj">Объект сравнения</param>
        /// <returns>Булево значение, итог сравнения строк (названия компании)</returns>
        public override bool Equals(object? obj)
        {
            if (obj is Company company) // Проверка типа
            {
                CompanyEmailList.AddRange(company.CompanyEmailList); //Слияние листов, название компаний которых одинаковы
                CompanyPhoneList.AddRange(company.CompanyPhoneList);
                return CompanyName == company.CompanyName; // Сравнение названий компании
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Переопределенный метод GetHashCode, необходимый для ассоциаци элемментов листа с одинаковыми названиями компаний
        /// </summary>
        /// <returns>Возвращает Хеш код имя компании</returns>
        public override int GetHashCode() => CompanyName.GetHashCode();
    }
}


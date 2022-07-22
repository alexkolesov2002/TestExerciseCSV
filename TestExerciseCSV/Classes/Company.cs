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
        public string CompanyName { get; set; } //Имя компании

        public string CompanyEmail { get; set; } //Емейл компании
        public string CompanyPhone { get; set; } //Телефон компании
        public string BufferString { get; set; } //Буферная строка для обработки

        public override bool Equals(object? obj)
        {
            if (obj is Company company)
            {
                if (CompanyEmail != company.CompanyEmail && CompanyPhone != company.CompanyPhone)
                {
                    CompanyEmail += company.CompanyEmail;
                    CompanyPhone += company.CompanyPhone;
                }

                return CompanyName == company.CompanyName;
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode() => CompanyName.GetHashCode();
    }
}


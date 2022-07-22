using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestExerciseCSV
{

    /// <summary>
    /// Класс, предназначенный для работы с CSV файлом (try catch нет специально, что бы были видны ошибки более детально
    /// </summary>
    public class ProcessingCSV
    {
        private List<Company> _informationFromFile = new List<Company>(); //Главный изменяемый лист

        public ProcessingCSV()
        {
            
            ReadInformarmation();
            ProcessingInformarmation();
            WriteInformation();
        }

        /// <summary>
        /// Метод чтения CSV файла
        /// </summary>
        /// <returns>Возращает лист, который содержит название компании и буферную строку с данными о компании</returns>
        public List<Company> ReadInformarmation()
        {
            using (StreamReader fileReader = new StreamReader("Information.csv"))
            {
                //цикл пока не достигли конца файла
                while (fileReader.EndOfStream != true)
                {
                    //помещаем строку из файла в строковый массив по разделителю, принятому в csv
                    string[] bufferString = fileReader.ReadLine().Split(';');
                    //помещаем в элемент списка новую структуру типа Company
                    _informationFromFile.Add(new Company() { CompanyName = bufferString[0], BufferString = bufferString[1] });
                }
            }


            return _informationFromFile;
        }

        /// <summary>
        /// Метод обработки информации, необходимый после прочтения файла
        /// </summary>
        /// <returns> Возвращает лист, который содержит название компании, телефоны (строка) и емейлы компании (строка)</returns>
        public List<Company> ProcessingInformarmation()
        {

            foreach (Company company in _informationFromFile) // цикл, по элементам листа главного листа
            {
                string[] MasBuferString = company.BufferString.Split(','); // помещаем в строковый массив элементы строки, с разделителем - запятой 
                foreach (string item in MasBuferString) // цикл по элементам полученного массива
                {
                    string str = item.Replace(",", ""); //очистка элемента массива (строки) от лишних символов
                    str = str.Replace(",,", "");
                    if (str.Contains("+7 9") || str.Contains("+79")) //Если строка является начинается на  +79 (исходя из ТЗ), она заносится в дополнительный лист класса  Company
                    {

                        company.CompanyPhoneList.Add(str);
                    }
                    else if (str.Contains("@")) //Иначе если строка является начинается на  +79 (исходя из ТЗ), она заносится в дополнительный лист класса  Company
                    {

                        company.CompanyEmailList.Add(str);
                    }
                    else
                    {

                    }
                }

            }
            var _informationFromFileBuffer = _informationFromFile; //Копирование основного листа, для создание нового листа, с уникальными компаниями
            var _informationFromFileUnion = _informationFromFile.Union(_informationFromFileBuffer); //Объединение последовательнгостей с добавлением повторяющихся элементов, только один раз
            List<Company> _informationFromFileResult = new List<Company>(); 


            foreach (Company company in _informationFromFileUnion) //Заполнение новой последовательности, данными из объединенного листа
            {
                _informationFromFileResult.Add(company);
            }




            foreach (Company company in _informationFromFileResult) // Цикл по элементам коллекции объединенного листа
            {
                company.CompanyPhoneList = company.CompanyPhoneList.Distinct().ToList(); //Для каждого элемента коллекции удаление повторяющихся элементов из дополнительных листов класса Company

                company.CompanyEmailList = company.CompanyEmailList.Distinct().ToList();
                foreach (var item in company.CompanyPhoneList) // Заполнение строки с телефонами, для каждого элемента коллекции, данными из дополнительных коллекций
                {
                    company.CompanyPhone += item + ", ";
                }
                foreach (var item in company.CompanyEmailList) // Заполнение строки с Емейлами, для каждого элемента коллекции, данными из дополнительных коллекций
                {
                    company.CompanyEmail += item + ", ";
                }
                if (company.CompanyPhone != null) // Если строка не пуста, удалить последние 2 символа
                {
                    company.CompanyPhone = company.CompanyPhone.Remove(company.CompanyPhone.Length - 2); 
                }
                else // Иначе - установить другое значение строки
                {
                    company.CompanyPhone = "У компании отсутствует мобильный телефон";
                }
                if (company.CompanyEmail != null)
                {
                    company.CompanyEmail = company.CompanyEmail.Remove(company.CompanyEmail.Length - 2);
                }
                else
                {
                    company.CompanyEmail = "У компании отсутствует Емейл";
                }
            }
            _informationFromFile = _informationFromFileResult; //Запись в главный лист, измененного листа
            return _informationFromFile;
        }
        /// <summary>
        /// Метод записи итоговой информации в CSV файл
        /// </summary>
        public void WriteInformation()
        {
            using (StreamWriter fileWriter = new StreamWriter(@"ResultInformation.csv", false, Encoding.UTF8))
            {
                fileWriter.WriteLine("Название компании;Телефоны;Адреса электронной почты"); //Создание шапки таблицы
                foreach (Company company in _informationFromFile) // цикл по основным элементам главного листа
                {
                    fileWriter.WriteLine(company.CompanyName + ";" + company.CompanyPhone + ";" + company.CompanyEmail); // запись данных в 3 столбца
                }

            }
        }


    }
}






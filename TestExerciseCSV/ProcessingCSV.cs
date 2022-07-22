using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestExerciseCSV
{
    public class ProcessingCSV
    {
        private List<Company> _informationFromFile = new List<Company>();
        public ProcessingCSV()
        {
            GetInformarmation();
            ProcessingInformarmation();
        }


        public List<Company> GetInformarmation()
        {
            using (StreamReader sr = new StreamReader("Information.csv"))
            {
                //цикл пока не достигли конца файла
                while (sr.EndOfStream != true)
                {
                    //помещаем строку из файла в строковый массив по разделителю, принятому в csv
                    string[] BufferString = sr.ReadLine().Split(';');
                    //помещаем в элемент списка новую структуру типа Company

                    _informationFromFile.Add(new Company() { CompanyName = BufferString[0], BufferString = BufferString[1] });
                }
            }


            return _informationFromFile;
        }


        public List<Company> ProcessingInformarmation()
        {

            foreach (Company company in _informationFromFile)
            {
                string[] MasBuferString = company.BufferString.Split(',');
                foreach (string item in MasBuferString)
                {
                    string str = item.Replace(",", "");
                    str = str.Replace(",,", "");
                    if (str.Contains("+7 9") || str.Contains("+79"))
                    {
                        company.CompanyPhone += str + ";";
                    }
                    else if (str.Contains("@"))
                    {
                        company.CompanyEmail += str + ";";
                    }
                    else
                    {

                    }
                }




            }
            List<Company> _informationFromFileBuffer = _informationFromFile;

            var _informationFromFileNew = _informationFromFile.Union(_informationFromFileBuffer);

            foreach (Company company in _informationFromFileNew)
            {
                if (company.CompanyPhone != null)
                {

                    string[] MasBuferStringPhones = company.CompanyPhone.Split(';');
                    var result = MasBuferStringPhones.Distinct();
                    company.CompanyPhone = "";
                    company.CompanyPhone = "";
                    foreach (string item in result)
                    {
                        company.CompanyPhone += item;
                    }
                    
                    //company.CompanyPhone = "";
                    //foreach (string item in MasBuferStringPhones.Distinct())
                    //{
                    //    company.CompanyPhone += item + ",";
                    //}
                }

                if (company.CompanyEmail != null)
                {


                    //string[] MasBuferStringMail = company.CompanyEmail.Split(';');
                    //company.CompanyEmail = "";
                    //foreach (string item in MasBuferStringMail.Distinct())
                    //{
                    //    company.CompanyEmail += item + ",";
                    //}
                }

               



            }

            List<Company> s = (List<Company>)_informationFromFileNew;

            return null;
        }




    }
}






using TestExerciseCSV;

internal class Programm
{/// <summary>
/// Входная точка программы
/// </summary>
    static void Main()
    {
        
        Console.WriteLine("Привет мир. Я - тестовое задание на обработку CSV файла, мой автор Колесов А.Д.");
        Console.WriteLine("Для того что бы продолжить, нажмите любую клавишу");
        Console.ReadKey();

        ProcessingCSV CompanyCSV = new ProcessingCSV();
        //CompanyCSV.GetInformarmation();
    }
}


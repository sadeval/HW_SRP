// Класс FIO для хранения информации о ФИО студента
public class FIO
{
    public string? FirstName { get; set; }
    public string? Surname { get; set; }
    public string? Lastname { get; set; }
}

// Класс Address для хранения информации об адресе
public class Address
{
    public string? Country { get; set; }
    public string? Region { get; set; }
    public string? City { get; set; }
    public string? Street { get; set; }
    public int HouseNumber { get; set; }
    public string? Korpus { get; set; }
    public short PostalCode { get; set; }
}

// Класс DateOfBirth для хранения информации о дате рождения и расчета знака зодиака
public class DateOfBirth
{
    public DateTime BirthDate { get; set; }

    private static readonly Dictionary<(int, int), string> ZodiacSigns = new Dictionary<(int, int), string>
    {
        { (1, 19), "Козерог" },
        { (1, 31), "Водолей" },
        { (2, 18), "Водолей" },
        { (2, 29), "Рыбы" },
        { (3, 20), "Рыбы" },
        { (3, 31), "Овен" },
        { (4, 19), "Овен" },
        { (4, 30), "Телец" },
        { (5, 20), "Телец" },
        { (5, 31), "Близнецы" },
        { (6, 20), "Близнецы" },
        { (6, 30), "Рак" },
        { (7, 22), "Рак" },
        { (7, 31), "Лев" },
        { (8, 22), "Лев" },
        { (8, 31), "Дева" },
        { (9, 22), "Дева" },
        { (9, 30), "Весы" },
        { (10, 22), "Весы" },
        { (10, 31), "Скорпион" },
        { (11, 21), "Скорпион" },
        { (11, 30), "Стрелец" },
        { (12, 21), "Стрелец" },
        { (12, 31), "Козерог" }
    };

    public string GetZodiacSign()
    {
        int day = BirthDate.Day;
        int month = BirthDate.Month;
        string zodiacSign = string.Empty;

        foreach (var zodiac in ZodiacSigns)
        {
            var (zodiacMonth, zodiacDay) = zodiac.Key;
            if (month == zodiacMonth && day <= zodiacDay)
            {
                zodiacSign = zodiac.Value;
                break;
            }
        }

        if (month == 12 && day > 21)
        {
            zodiacSign = "Козерог";
        }

        if (string.IsNullOrEmpty(zodiacSign))
        {
            zodiacSign = "Unknown";
        }

        return zodiacSign;
    }
}

// Класс StartStudy для хранения информации о дате начала учебы
public class StartStudy
{
    public int StartDay { get; set; }
    public int StartMonth { get; set; }
    public int StartYear { get; set; }
}

// Класс AcademicInfo для хранения информации об учебной деятельности студента
public class AcademicInfo
{
    public StartStudy StartStudy { get; set; }
    public int Kurs { get; set; }
    public string? GroupName { get; set; }
    public string? Specialization { get; set; }

    public AcademicInfo()
    {
        StartStudy = new StartStudy();
    }
}

// Класс Attendance для хранения информации о посещаемости
public class Attendance
{
    public int LessonsVisited { get; set; }
    public int LessonsLate { get; set; }
}

// Класс Teachers для хранения имен преподавателей
public class Teachers
{
    public List<string> TeacherNames { get; set; }

    public Teachers()
    {
        TeacherNames = new List<string>();
    }
}

// Класс Subjects для хранения названия предметов
public class Subjects
{
    public List<string> SubjectNames { get; set; }

    public Subjects()
    {
        SubjectNames = new List<string>();
    }
}

// Класс Ratings для хранения оценок студента и расчета среднего арифметического
public class Ratings
{
    public int[]? DzRates { get; set; }
    public int[]? PracticeRates { get; set; }
    public int[]? ExamRates { get; set; }
    public int[]? ZachetRates { get; set; }

    private float CalculateAverage(int[] rates)
    {
        if (rates == null || rates.Length == 0)
            return 0;

        return (float)rates.Average();
    }

    public float DzAverageRate => CalculateAverage(DzRates);
    public float PracticeAverageRate => CalculateAverage(PracticeRates);
    public float ExamAverageRate => CalculateAverage(ExamRates);
    public float ZachetAverageRate => CalculateAverage(ZachetRates);
    public float TotalAverageRate
    {
        get
        {
            var allRates = new List<int>();
            if (DzRates != null) allRates.AddRange(DzRates);
            if (PracticeRates != null) allRates.AddRange(PracticeRates);
            if (ExamRates != null) allRates.AddRange(ExamRates);
            if (ZachetRates != null) allRates.AddRange(ZachetRates);

            return CalculateAverage(allRates.ToArray());
        }
    }
}

// Основной класс Student
public class Student
{
    public FIO Name { get; set; }
    public Address HomeAddress { get; set; }
    public Address UniversityAddress { get; set; }
    public DateOfBirth DateOfBirth { get; set; }
    public AcademicInfo AcademicInformation { get; set; }
    public Attendance StudentAttendance { get; set; }
    public Teachers TeacherInformation { get; set; }
    public Subjects SubjectInformation { get; set; }
    public Ratings StudentRatings { get; set; }

    public Student()
    {
        Name = new FIO();
        HomeAddress = new Address();
        UniversityAddress = new Address();
        DateOfBirth = new DateOfBirth();
        AcademicInformation = new AcademicInfo();
        StudentAttendance = new Attendance();
        TeacherInformation = new Teachers();
        SubjectInformation = new Subjects();
        StudentRatings = new Ratings();
    }
}


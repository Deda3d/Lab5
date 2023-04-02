using System.Text;

abstract class EducationalInstitution
{
    public int NumberOfStudents { get; set; }
    public int NumberOfTeachers { get; set; }
    public string NameOfEducationalInstitution { get; set; }
    public EducationalInstitution(int numberOfStudents, int numberofteachers, string nameOfEducationalInstitution)
    {
        NumberOfStudents = numberOfStudents;
        NumberOfTeachers = numberofteachers;
        NameOfEducationalInstitution = nameOfEducationalInstitution;
    }
    public EducationalInstitution(int numberOfStudents, string nameOfEducationalInstitution)
    {
        NumberOfStudents = numberOfStudents;
        NameOfEducationalInstitution = nameOfEducationalInstitution;
    }
    public EducationalInstitution(string nameOfEducationalInstitution)
    {
        NameOfEducationalInstitution = nameOfEducationalInstitution;
    }
}
interface IPrint
{
    public void PrintInfo();
}
class School : EducationalInstitution, IPrint
{
    int Classes { get; set; }
    public School(int numberOfStudents, string nameOfEducationalInstitution) : base(numberOfStudents, nameOfEducationalInstitution)
    {
        Classes = numberOfStudents / 30;
        NumberOfTeachers = numberOfStudents / 20;
    }
    public void PrintInfo()
    {
        Console.WriteLine($"Назва школи: {NameOfEducationalInstitution}");
        Console.WriteLine($"Кількість учнів: {NumberOfStudents}");
        Console.WriteLine($"Кількість вчителів: {NumberOfTeachers}");
        Console.WriteLine($"Кількість класів: {Classes}");
    }
}
class University : EducationalInstitution, IPrint
{
    public University(string nameOfEducationalInstitution) : base(nameOfEducationalInstitution){}
    public List<Faculty> faculties = new List<Faculty>();
    int numteach = 0;
    public static void AddFaculty(Faculty faculty, List<University.Faculty> faculties)
    {
        faculties.Add(faculty);
    }
    public class Faculty
    {
        public string FacultyName;
        public int FacultyDateOfCreation;
        public Faculty(string facultyName, int dateOfCreation)
        {
            FacultyName = facultyName;
            FacultyDateOfCreation = dateOfCreation;
        }
        public override string ToString()
        {
            return $"Назва факультету: {FacultyName}\nРік створення: {FacultyDateOfCreation}";
        }
        public List<Department> departmens = new List<Department>();
        public static void AddDepartment(Department department, List<Faculty.Department> departments)
        {
            departments.Add(department);
        }
        public class Department
        {
            string DepartmentName;
            public Department(string departmentName)
            {
                DepartmentName = departmentName;
            }
            public override string ToString()
            {
                return $"Назва кафедри: {DepartmentName}";
            }
        }
    }
    public int NumberOfFaculties()
    {
        return faculties.Count;
    }
    public void PrintInfo()
    {
        Console.WriteLine($"Назва університету: {NameOfEducationalInstitution}");
        Console.WriteLine($"Кількість факультетів: {faculties.Count}");
        Console.WriteLine();
        for(int i = 0; i < faculties.Count;i++)
        {
            Console.WriteLine($"Назва факультету: {faculties[i].FacultyName}");
            Console.WriteLine($"Рік заснування: {faculties[i].FacultyDateOfCreation}");
            Console.WriteLine($"Кафедри:");
            foreach(var dep in faculties[i].departmens)
            {
                Console.WriteLine("   " + dep);
                numteach += 10;
            }
            Console.WriteLine();
        }
        Console.WriteLine($"Кількість викладачів: {numteach}");
        Console.WriteLine();
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        School school = new School(300, "Школа номер 16");

        University university = new University("Київський політехнічний інститут імені Ігоря Сікорського");

        University.Faculty faculty1 = new University.Faculty("ФІОТ", 1962);
        University.AddFaculty(faculty1, university.faculties);

        University.Faculty.AddDepartment(new University.Faculty.Department("Інтегровані інформаційні системи (ІІС)"), faculty1.departmens);
        University.Faculty.AddDepartment(new University.Faculty.Department("Інформаційне забезпечення робототехнічних систем (ІЗРС)"), faculty1.departmens);
        University.Faculty.AddDepartment(new University.Faculty.Department("Інформаційні управляючі системи та технології (ІУСТ)"), faculty1.departmens);

        University.Faculty faculty2 = new University.Faculty("ФПМ", 1990);
        University.AddFaculty(faculty2, university.faculties);

        University.Faculty.AddDepartment(new University.Faculty.Department("Наука про дані та математичне моделювання"), faculty2.departmens);
        University.Faculty.AddDepartment(new University.Faculty.Department("Прикладна математика"), faculty2.departmens);
        University.Faculty.AddDepartment(new University.Faculty.Department("Інженерія програмного забезпечення"), faculty2.departmens);
        university.PrintInfo();
        school.PrintInfo();
    }
}

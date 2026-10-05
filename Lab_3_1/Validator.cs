using System.Text.RegularExpressions;
namespace MainApp.Services;

public static class Validator
{
    public static bool IsValidName(string name) {
    string pattern = @"^[a-zA-Zа-яА-ЯіІїЇєЄ']{2,}$";
    return !string.IsNullOrWhiteSpace(name) && Regex.IsMatch(name, pattern);
    }
    public static bool IsValidStudentId(string studentId) {
     string pattern = @"^[A-ZА-Я]{2}\d{6,8}$";
    return !string.IsNullOrWhiteSpace(studentId) && Regex.IsMatch(studentId, pattern);
    }
    public static bool IsValidBirthDate(string birthDate) {
    string pattern = @"^(0[1-9]|[12]\d|3[01])-(0[1-9]|1[0-2])-\d{4}$";
    return !string.IsNullOrWhiteSpace(birthDate) && Regex.IsMatch(birthDate, pattern);
    }
    public static bool IsValidCourse(string course) {
    string pattern = @"^[1-6]$";
    return !string.IsNullOrWhiteSpace(course) && Regex.IsMatch(course, pattern);
    }
}
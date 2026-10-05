using System.Text;
using MainApp.Models;
namespace MainApp.Services;

public static class DataSerializer
{
    public static string Serialize(Student[] students)
    {
        if(students == null || students.Length == 0)
        {
            return string.Empty;
        }
        StringBuilder sb = new StringBuilder();
        for(int i = 0; i < students.Length; i++)
        {
            Student s = students[i];
            if(s == null) continue;
            sb.AppendLine($"Student {s.FirstName}{s.LastName}");
            sb.AppendLine("{");
            sb.AppendLine($"  \"firstname\": \"{s.FirstName}\",");
            sb.AppendLine($"  \"lastname\": \"{s.LastName}\",");
            sb.AppendLine($"  \"studentId\": \"{s.StudentId}\",");
            sb.AppendLine($"  \"course\": \"{s.Course}\",");
            sb.AppendLine($"  \"birthDate\": \"{s.BirthDate}\"");
            sb.AppendLine("};");
        }
        return sb.ToString();
        
    }
    public static Student[] Deserialize(string rawText)
    {
        if (string.IsNullOrWhiteSpace(rawText))
        {
            return new Student[0];
        }

        string[] blocks = rawText.Split(new string[] { "};" }, StringSplitOptions.RemoveEmptyEntries);
        Student[] students = new Student[blocks.Length];
        int count = 0;

        for (int i = 0; i < blocks.Length; i++)
        {
            string block = blocks[i];

            string fn = GetValue(block, "firstname");
            string ln = GetValue(block, "lastname");
            string id = GetValue(block, "studentId");
            int course = int.TryParse(GetValue(block, "course"), out int c) ? c : 1;
            string bd = GetValue(block, "birthDate");

            if (!string.IsNullOrWhiteSpace(fn) && !string.IsNullOrWhiteSpace(ln))
            {
                students[count++] = new Student(fn, ln, course, id, bd);
            }
        }

        Array.Resize(ref students, count);
        return students;
    }

    private static string GetValue(string block, string key)
    {
        string pattern = $"\"{key}\"\\s*:\\s*\"([^\"]+)\"";
        var match = System.Text.RegularExpressions.Regex.Match(block, pattern);
        return match.Success ? match.Groups[1].Value : string.Empty;
    }
}
using System.ComponentModel.DataAnnotations;

namespace doKolosa2.Models;

public class StudentGroup
{
    [Key]
    public int IdStudentGroup { get; set; }
    
    public string Name { get; set; }
    
    public ICollection<Student> Students { get; set; }
}
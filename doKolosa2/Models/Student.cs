using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace doKolosa2.Models;

public class Student
{
    [Key]
    public int IdStudent { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    
    public int IdStudentGroup { get; set; }
    
    [ForeignKey("IdStudentGroup")]      //mowie ze klucz obcy to: ...
    public StudentGroup StudentGroup { get; set; }
}
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models;

public class Player : Entity
{
    [Required]
    [MaxLength(32, ErrorMessage = "The max length is 32")]
    [DisplayName("Name")]
    public string Name { get; set; }
    
    [Range(0, 1000, ErrorMessage = "Should be number in range from 0 to 1000")]
    [DisplayName("Hit points")]
    public int HitPoints { get; set; }
    
    [Range(-5, 5, ErrorMessage = "Should be number in range from -5 to 5")]
    [DisplayName("Attack modifier")]
    public int AttackModifier { get; set; }
    
    [Range(0, 5, ErrorMessage = "Should be number in range from 0 to 5")]
    [DisplayName("Attack modifier")]
    public int AttackPerRound { get; set; }
    
    [Required]
    [RegularExpression(@"\d+d\d+", ErrorMessage = "Format should be like 2d6")]
    [DisplayName("Damage")]
    public string Damage { get; set; }
    
    [Range(-5, 5, ErrorMessage = "Should be number in range from -5 to 5")]
    [DisplayName("Damage modifier")]
    public int DamageModifier { get; set; }
    
    [Range(0, 1000, ErrorMessage = "Should be number in range from 0 to 1000")]
    [DisplayName("Armor class")]
    public int ArmorClass { get; set; }
}
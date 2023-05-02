using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Baby_goods.DAL.PostgreSQL.Entities
{
    public class CategoryEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [AllowNull]
        public Guid? ParentId { get; set; }

        public virtual ICollection<CategoryEntity> Categories { get; set; }
    }
}

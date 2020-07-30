using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirebaseClassLibrary.Entities
{
    public interface DbItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        long? Id { get; set; }
    }
}

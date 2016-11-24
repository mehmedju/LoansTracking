using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoansTracking.DB.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [Column(TypeName = "text")]
        public string Text { get; set; }

        public virtual Person Person { get; set; }
    }
}

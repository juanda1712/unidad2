using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Unidad3.Models
{
    public class UserModel
    {
        [PrimaryKey, AutoIncrement]
        public int UserID { get; set; }

        [MaxLength (10)]
        public string Usuario { get; set; }

        [MaxLength(40)]
        public string Nombre { get; set; }

        [MaxLength(8)]
        public string Pw { get; set; }

    }
}

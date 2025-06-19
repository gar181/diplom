using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomProject.Classes
{
    class ConnectionClass
    {
        public NpgsqlConnection con = new NpgsqlConnection("Server=localhost; Database=abushkevich_diplom; User Id=postgres; Password=1");
    }
}

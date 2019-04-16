using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace ProjectDotNet
{
    class ProjectConnection
    {

        public static SqlConnection getConnection()
        {
            return new SqlConnection(@"Data Source=.;Initial Catalog=QLSVien;User ID=sa");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Generator_Business_Layer.DataAccessGenerators
{
    internal interface iDataAccessGenerator
    {
        string GenerateCreateMethod();
        string GenerateReadMethod();
        string GenerateUpdateMethod();
        string GenerateDeleteMethod();
        DataTable GenerateReadAllRecordsMethod();

    }
}

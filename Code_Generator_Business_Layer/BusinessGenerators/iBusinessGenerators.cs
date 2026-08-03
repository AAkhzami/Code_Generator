using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Generator_Business_Layer.BusinessGenerators
{
    internal interface iBusinessGenerators
    {
        string GenerateProperties();
        string GenerateCreateMethod();
        string GenerateReadMethod();
        string GenerateUpdateMethod();
        string GenerateDeleteMethod();
        string GenerateReadAllMethod();
        string GeneratePublicConstructor();
        string GeneratePrivateConstructor();
        string GenerateSaveMethod();
        string GenerateBusinessLayerClass();
    }
}

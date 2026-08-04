using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Generator_Business_Layer.DataAccessGenerators
{
    /// <summary>
    /// Defines the contract for data access layer code generators to produce static methods for executing direct database operations.
    /// </summary>
    internal interface iDataAccessGenerator
    {
        /// <summary>
        /// Generates the static data access method for executing SQL INSERT commands and returning the newly created record ID.
        /// </summary>
        /// <returns>A string containing the code for the Create method.</returns>
        string GenerateCreateMethod();

        /// <summary>
        /// Generates the static data access method for executing SQL SELECT commands by primary key using output parameters or data readers.
        /// </summary>
        /// <returns>A string containing the code for the Read/Find method.</returns>
        string GenerateReadMethod();

        /// <summary>
        /// Generates the static data access method for executing SQL UPDATE commands to modify existing database records.
        /// </summary>
        /// <returns>A string containing the code for the Update method.</returns>
        string GenerateUpdateMethod();

        /// <summary>
        /// Generates the static data access method for executing SQL DELETE commands by primary key.
        /// </summary>
        /// <returns>A string containing the code for the Delete method.</returns>
        string GenerateDeleteMethod();

        /// <summary>
        /// Generates the static data access method for retrieving all table records into a DataTable.
        /// </summary>
        /// <returns>A string containing the code for the ReadAllRecords method.</returns>
        string GenerateReadAllRecordsMethod();

        /// <summary>
        /// Generates the complete Data Access Layer class,  class definition, and all static methods.
        /// </summary>
        /// <returns>A string containing the entire generated Data Access class file content.</returns>
        string GenerateDataAccessLayerClass();
    }
}
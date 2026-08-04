using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Generator_Business_Layer.BusinessGenerators
{
    /// <summary>
    /// Defines the contract for business layer code generators to produce code components, including properties, constructors, and CRUD operations.
    /// </summary>
    public interface iBusinessGenerators
    {
        /// <summary>
        /// Generates public auto-properties corresponding to the table columns in the database.
        /// </summary>
        /// <returns>A string containing the generated property declarations.</returns>
        string GenerateProperties();

        /// <summary>
        /// Generates the business logic method responsible for inserting a new record into the database.
        /// </summary>
        /// <returns>A string containing the code for the Create method.</returns>
        string GenerateCreateMethod();

        /// <summary>
        /// Generates the business logic method responsible for retrieving a single record by its primary key.
        /// </summary>
        /// <returns>A string containing the code for the Read/Find method.</returns>
        string GenerateReadMethod();

        /// <summary>
        /// Generates the business logic method responsible for updating an existing record in the database.
        /// </summary>
        /// <returns>A string containing the code for the Update method.</returns>
        string GenerateUpdateMethod();

        /// <summary>
        /// Generates the business logic method responsible for deleting a record by its primary key.
        /// </summary>
        /// <returns>A string containing the code for the Delete method.</returns>
        string GenerateDeleteMethod();

        /// <summary>
        /// Generates the business logic method responsible for retrieving all records from the database table.
        /// </summary>
        /// <returns>A string containing the code for the ReadAll method.</returns>
        string GenerateReadAllMethod();

        /// <summary>
        /// Generates the public parameterless constructor used for instantiating new objects prior to insertion (AddNew mode).
        /// </summary>
        /// <returns>A string containing the code for the public constructor.</returns>
        string GeneratePublicConstructor();

        /// <summary>
        /// Generates the parameterized constructor used internally to map retrieved database values directly into object fields (Update mode).
        /// </summary>
        /// <returns>A string containing the code for the parameterized constructor.</returns>
        string GeneratePrivateConstructor();

        /// <summary>
        /// Generates the main Save method that routes execution to either Create or Update based on the object's current state.
        /// </summary>
        /// <returns>A string containing the code for the Save method.</returns>
        string GenerateSaveMethod();

        /// <summary>
        /// Generates the complete Business Layer class, class definition, properties, and all methods.
        /// </summary>
        /// <returns>A string containing the entire generated class file content.</returns>
        string GenerateBusinessLayerClass();
    }
}

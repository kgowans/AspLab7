using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.SqlClient;
using StudentRegistrationEFDataModel;

/// <summary>
/// Summary description for DataAccessBase
/// </summary>
public class DataAccessBase
{
    private string connectionString;
    protected SqlConnection connection;
    public DataAccessBase()
    {
        connectionString = WebConfigurationManager.ConnectionStrings["StudentRegistration"].ConnectionString;


        if (connectionString != null )
        {
            connection = new SqlConnection(connectionString);
        }
    }

}
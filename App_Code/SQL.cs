﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SQL
/// </summary>
/// 
namespace SDLX.SQL {
    public class SQL
    {        
        public SqlConnection sqlConnection=null;
        private bool newTransaction;
        public SQL(bool newTransaction = true)
        {
            this.newTransaction = newTransaction;
            if (newTransaction)
            {
                sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["RecuperacionCreditos"].ConnectionString);
                sqlConnection.Open();
            }            
        }
        
        public void Close (bool close = true)
        {
            if (close)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            
        }
    }
}

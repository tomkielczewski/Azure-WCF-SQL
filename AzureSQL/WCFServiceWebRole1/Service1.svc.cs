﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFServiceWebRole1
{
    // UWAGA: możesz użyć polecenia „Zmień nazwę” w menu „Refaktoryzuj”, aby zmienić nazwę klasy „Service1” w kodzie, usłudze i pliku konfiguracji.
    // UWAGA: aby uruchomić klienta testowego WCF w celu przetestowania tej usługi, wybierz plik Service1.svc lub Service1.svc.cs w eksploratorze rozwiązań i rozpocznij debugowanie.
    public class Service1 : IService1
    {
   using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFServiceWebRole1
    {
        // UWAGA: możesz użyć polecenia „Zmień nazwę” w menu „Refaktoryzuj”, aby zmienić nazwę klasy „Service1” w kodzie, usłudze i pliku konfiguracji.
        // UWAGA: aby uruchomić klienta testowego WCF w celu przetestowania tej usługi, wybierz plik Service1.svc lub Service1.svc.cs w eksploratorze rozwiązań i rozpocznij debugowanie.
        public class Service1 : IService1
        {
            public SqlConnection Connect()
            {
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Database=AzureSQL;Trusted_Connection=yes;";

                connection.Open();
                return connection;
            }

            public bool Create(string login, string password)
            {
                SqlConnection connection = Connect();
                SqlCommand command = connection.CreateCommand();

                command.CommandText = "IF (OBJECT_ID('dbo.Users') IS NOT NULL) " +
                                            "BEGIN " +
                                                "INSERT INTO Users (Login, Password) " +
                                                "VALUES ('" + login + "', '" + password + "') " +
                                            "END; " +
                                      "ELSE " +
                                            "BEGIN " +
                                                "CREATE TABLE Users(" +
                                                    "Login varchar(50) PRIMARY KEY, " +
                                                    "Password varchar(50), " +
                                                    "SessionID UNIQUEIDENTIFIER" +
                                                    ") " +
                                                "INSERT INTO Users (Login, Password) " +
                                                "VALUES ('" + login + "', '" + password + "') " +
                                            "END;";
                command.ExecuteNonQuery();



                connection.Close();
                return true;
            }
            


        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}

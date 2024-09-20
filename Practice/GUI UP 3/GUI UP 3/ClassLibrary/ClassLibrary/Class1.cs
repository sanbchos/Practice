using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class CalculateAverageRepairTime
    {
        private readonly DataBase database;

        public CalculateAverageRepairTime(DataBase database)
        {
            this.database = database;
        }

        public double CalculateAverageRepairTimeByModelID(int modelID)
        {
            double averageRepairTime = 0.0;

            string query = @"
            SELECT AVG(DATEDIFF(day, r.startDate, r.completionDate)) AS AvgRepairTime
            FROM Requests r
            JOIN DeviceModels dm ON r.modelID = dm.modelID
            WHERE r.completionDate IS NOT NULL AND dm.modelID = @modelID";

            try
            {
                using (SqlCommand command = new SqlCommand(query, database.GetConnection()))
                {
                    command.Parameters.AddWithValue("@modelID", modelID);

                    database.openConnection();
                    object result = command.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        averageRepairTime = Convert.ToDouble(result);
                    }
                }
            }
            finally
            {
                database.closeConnection();
            }

            return averageRepairTime;
        }
    }

    public class DataBase
    {
        SqlConnection SQLConnection = new SqlConnection(@"Data Source =IDVORTSOV; Initial Catalog = Dvortsov_319_10; Integrated Security = True");

        public void openConnection()
        {
            if (SQLConnection.State == System.Data.ConnectionState.Closed)
            {
                SQLConnection.Open();
            }
        }

        public void closeConnection()
        {
            if (SQLConnection.State == System.Data.ConnectionState.Open)
            {
                SQLConnection.Close();
            }
        }

        public SqlConnection GetConnection()
        {
            return SQLConnection;
        }
    }
}

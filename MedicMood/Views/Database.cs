using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace MedicMood.Views
{
    public class Database
    {
        SqliteConnection database;

        public Database(string dbPath)
        {
            database = new SqliteConnection($"Data Source={dbPath}");
            database.Open();

            // 创建闹钟表
            string createTableCmd = @"CREATE TABLE IF NOT EXISTS Alarm (
                                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                        Label TEXT,
                                        Time DATETIME,
                                        IsActive INTEGER)";
            ExecuteNonQuery(createTableCmd);
        }

        public List<Alarm> GetAlarms()
        {
            List<Alarm> alarms = new List<Alarm>();

            string query = "SELECT * FROM Alarm";
            using (var command = new SqliteCommand(query, database))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Alarm alarm = new Alarm
                        {
                            Id = reader.GetInt32(0),
                            Label = reader.GetString(1),
                            Time = reader.GetDateTime(2),
                            IsActive = Convert.ToBoolean(reader.GetInt32(3))
                        };
                        alarms.Add(alarm);
                    }
                }
            }

            return alarms;
        }

        public void AddAlarm(Alarm alarm)
        {
            string insertCmd = $"INSERT INTO Alarm (Label, Time, IsActive) VALUES ('{alarm.Label}', '{alarm.Time.ToString("yyyy-MM-dd HH:mm:ss")}', {(alarm.IsActive ? 1 : 0)})";
            ExecuteNonQuery(insertCmd);
        }

        public void UpdateAlarm(Alarm alarm)
        {
            string updateCmd = $"UPDATE Alarm SET Label = '{alarm.Label}', Time = '{alarm.Time.ToString("yyyy-MM-dd HH:mm:ss")}', IsActive = {(alarm.IsActive ? 1 : 0)} WHERE Id = {alarm.Id}";
            ExecuteNonQuery(updateCmd);
        }

        public void DeleteAlarm(int id)
        {
            string deleteCmd = $"DELETE FROM Alarm WHERE Id = {id}";
            ExecuteNonQuery(deleteCmd);
        }

        private void ExecuteNonQuery(string commandText)
        {
            using (var command = new SqliteCommand(commandText, database))
            {
                command.ExecuteNonQuery();
            }
        }
    }

    // 闹钟实体类
    public class Alarm
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public DateTime Time { get; set; }
        public bool IsActive { get; set; }
    }
}
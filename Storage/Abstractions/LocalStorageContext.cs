using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Storage.Abstractions
{
    public class LocalStorageContext : DbContext
    {
        ////private IEventLogger _Logger;
        private readonly LocalStorageSettings _Settings;
        public DbSet<Planogram> Planograms { get; set; }
        public DbSet<OrderLog> OrderLog { get; set; }
        public DbSet<CashPaymentDetail> CashPaymentDetails { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbFilepath"></param>
        public LocalStorageContext(LocalStorageSettings settings)////, IEventLogger logger = null)
        {
            _Settings = settings;
            ////_Logger = logger;
            if (_Settings == null)
            {
                string error = "Cache settings must be specified";
                ////_Logger?.LogEvent(LogEventType.Error, LogEventMerit.Critical, $"Event cache error: {error}");
                throw new ArgumentException(error);
            }

            if (!File.Exists(_Settings.DbFilepath))
                RestoreDatabase();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!File.Exists(_Settings.DbFilepath))
            {
                string error = "Database file missing!";
               ////_Logger?.LogEvent(LogEventType.Error, LogEventMerit.Critical, $"{error}: {_Settings.DbFilepath}");
                throw new FileNotFoundException(error, _Settings.DbFilepath);
            }

            optionsBuilder.UseSqlite($"Data Source={_Settings.DbFilepath};");
        }

        /// <summary>
        /// Check the maximum database size achieved
        /// </summary>
        /// <returns></returns>
        public bool MaxDBSizeExceeded()
        {
            if (_Settings.MaxDatabaseSizeMB == 0)
                return false;

            try
            {
                if (File.Exists(_Settings.DbFilepath))
                {
                    FileInfo fInfo = new FileInfo(_Settings.DbFilepath);
                    if (fInfo.Length / 1000000.0 > _Settings.MaxDatabaseSizeMB)
                        return true;
                }
            }
            catch (Exception ex)
            {
               //// _Logger?.LogEvent(LogEventType.Error, LogEventMerit.Important, $"An exception occured while check local database: {ex.Message}");
            }

            return false;
        }

        /// <summary>
        /// Restoring database if database file does not exists on disk
        /// </summary>
        private void RestoreDatabase()
        {
            if (!string.IsNullOrWhiteSpace(_Settings?.CreateDbScriptPath)
                && File.Exists(_Settings.CreateDbScriptPath)
                && new FileInfo(_Settings.CreateDbScriptPath).Length > 0)
            {
                SqliteConnection sqlite_conn = new SqliteConnection($"DataSource={_Settings.DbFilepath}");
                sqlite_conn.Open();

                string sqlQuery = File.ReadAllText(_Settings.CreateDbScriptPath);
                try
                {
                    base.Database.ExecuteSqlCommand(sqlQuery);
                }
                catch (Exception ex)
                {
                   //// _Logger?.LogEvent(LogEventType.Error, LogEventMerit.Important, $"An exception occured while restoring database: {ex.Message}");
                }
            }
        }
    }
}

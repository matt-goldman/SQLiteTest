using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SQLiteTest.Models;
using Xamarin.Forms;

namespace SQLiteTest
{
    public class Database : DbContext
    {
        public Database()
        {
            try
            {
                Database.EnsureCreatedAsync();
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
        }

        public DbSet<TextRecordModel> TextRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            String databasePath = "";
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    SQLitePCL.Batteries_V2.Init();
                    databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", "TestDB.db");
                    break;
                case Device.Android:
                    databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "TestDB.db");
                    break;
                default:
                    throw new NotImplementedException("Platform not supported");
            }

            optionsBuilder.UseSqlite($"Filename={databasePath}");

        }        

        public async Task<bool> SaveTextRecordAsync(TextRecordModel record)
        {
            try
            {
                await TextRecords.AddAsync(record);
                await SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<TextRecordModel>> GetTextRecordsAsync()
        {
            return await TextRecords.ToListAsync();
        }
    }
}

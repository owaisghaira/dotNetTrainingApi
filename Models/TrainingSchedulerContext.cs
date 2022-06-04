using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace TrainingScheduler.Models
{
    public class TrainingSchedulerContext : DbContext
    {
        public DbSet<Event> Event { get; set; }
        public DbSet<EventType> EventType { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<MessageType> MessageType { get; set; }
        public DbSet<Response> Response { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<SailPlan> SailPlan { get; set; }
        public DbSet<SailPlanLocation> SailPlanLocation { get; set; }
        public DbSet<Script> Script { get; set; }
        public DbSet<ScriptGroup> ScriptGroup { get; set; }
        public DbSet<ScriptEvent> ScriptEvent { get; set; }
        public DbSet<Station> Station { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<UserGroup> UserGroup { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<UserStation> UserStation { get; set; }
        public DbSet<WeatherAmountType> WeatherAmountType { get; set; }
        public DbSet<WeatherInfo> WeatherInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to mysql with connection string from app settings
            //var connectionString = "server=localhost;port=3306;database=training_app;user=training_app;password=password123";

            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            options.UseMySQL(connectionString);
        }

    }
}

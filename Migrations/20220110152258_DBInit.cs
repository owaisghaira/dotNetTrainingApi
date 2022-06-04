using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace TrainingScheduler.Migrations
{
    public partial class DBInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "event",
                columns: table => new
                {
                    EventID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FileData = table.Column<string>(type: "text", nullable: true),
                    EventType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event", x => x.EventID);
                });

            migrationBuilder.CreateTable(
                name: "event_type",
                columns: table => new
                {
                    EventTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event_type", x => x.EventTypeID);
                });

            migrationBuilder.CreateTable(
                name: "message",
                columns: table => new
                {
                    MessageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    MessageText = table.Column<string>(type: "text", nullable: true),
                    MessageTypeID = table.Column<int>(type: "int", nullable: false),
                    From = table.Column<int>(type: "int", nullable: false),
                    To = table.Column<int>(type: "int", nullable: false),
                    MessageTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Sent = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Read = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_message", x => x.MessageID);
                });

            migrationBuilder.CreateTable(
                name: "message_type",
                columns: table => new
                {
                    MessageTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_message_type", x => x.MessageTypeID);
                });

            migrationBuilder.CreateTable(
                name: "response",
                columns: table => new
                {
                    AnswerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    EventID = table.Column<int>(type: "int", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    Answer = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_response", x => x.AnswerID);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "sail_plan",
                columns: table => new
                {
                    SailPlanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Arrived = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ExpectedArrivalTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    VesselName = table.Column<string>(type: "text", nullable: true),
                    OwnerName = table.Column<string>(type: "text", nullable: true),
                    TelephoneAddress = table.Column<string>(type: "text", nullable: true),
                    MMSINumber = table.Column<string>(type: "text", nullable: true),
                    IsMotor = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SizeAndType = table.Column<string>(type: "text", nullable: true),
                    ColorOfCabin = table.Column<string>(type: "text", nullable: true),
                    ColorOfHulk = table.Column<string>(type: "text", nullable: true),
                    ColorOfDeck = table.Column<string>(type: "text", nullable: true),
                    OtherCharactistics = table.Column<string>(type: "text", nullable: true),
                    NumberOfLifeRafts = table.Column<int>(type: "int", nullable: false),
                    DescriptionAndColor = table.Column<string>(type: "text", nullable: true),
                    InboardOrOutboard = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    HorsePower = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    VHFRadioMonitorsCH = table.Column<string>(type: "text", nullable: true),
                    MFRadioMonitorsFrequency = table.Column<string>(type: "text", nullable: true),
                    CBRadioMonitorsCH = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sail_plan", x => x.SailPlanID);
                });

            migrationBuilder.CreateTable(
                name: "sail_plan_location",
                columns: table => new
                {
                    SailPlanLocationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    SailPlanID = table.Column<int>(type: "int", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<string>(type: "text", nullable: true),
                    Longitude = table.Column<string>(type: "text", nullable: true),
                    ExpectedArrival = table.Column<DateTime>(type: "datetime", nullable: false),
                    ExpectedDeparture = table.Column<DateTime>(type: "datetime", nullable: false),
                    Arrived = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sail_plan_location", x => x.SailPlanLocationID);
                });

            migrationBuilder.CreateTable(
                name: "script",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_script", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "script_event",
                columns: table => new
                {
                    ScriptEventID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ScriptID = table.Column<int>(type: "int", nullable: false),
                    EventID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_script_event", x => x.ScriptEventID);
                });

            migrationBuilder.CreateTable(
                name: "station",
                columns: table => new
                {
                    StationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_station", x => x.StationID);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "user_station",
                columns: table => new
                {
                    UserStationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    StationID = table.Column<int>(type: "int", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_station", x => x.UserStationID);
                });

            migrationBuilder.CreateTable(
                name: "weather_amount_type",
                columns: table => new
                {
                    WeatherAmountTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_weather_amount_type", x => x.WeatherAmountTypeID);
                });

            migrationBuilder.CreateTable(
                name: "weather_info",
                columns: table => new
                {
                    WeatherInfoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Time = table.Column<TimeSpan>(type: "time", nullable: false),
                    RecordDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    WindSpeed = table.Column<string>(type: "text", nullable: true),
                    WindDirection = table.Column<string>(type: "text", nullable: true),
                    Humidity = table.Column<string>(type: "text", nullable: true),
                    Temprature = table.Column<string>(type: "text", nullable: true),
                    Visibility = table.Column<string>(type: "text", nullable: true),
                    WindGusts = table.Column<string>(type: "text", nullable: true),
                    CloudCover = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    Latitude = table.Column<string>(type: "text", nullable: true),
                    Longitude = table.Column<string>(type: "text", nullable: true),
                    HighTemprature = table.Column<string>(type: "text", nullable: true),
                    LowTemprature = table.Column<string>(type: "text", nullable: true),
                    Pressure = table.Column<string>(type: "text", nullable: true),
                    Desctiption = table.Column<string>(type: "text", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    FeelsLike = table.Column<string>(type: "text", nullable: true),
                    AmountType = table.Column<int>(type: "int", nullable: false),
                    UVIndex = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_weather_info", x => x.WeatherInfoID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "event");

            migrationBuilder.DropTable(
                name: "event_type");

            migrationBuilder.DropTable(
                name: "message");

            migrationBuilder.DropTable(
                name: "message_type");

            migrationBuilder.DropTable(
                name: "response");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "sail_plan");

            migrationBuilder.DropTable(
                name: "sail_plan_location");

            migrationBuilder.DropTable(
                name: "script");

            migrationBuilder.DropTable(
                name: "script_event");

            migrationBuilder.DropTable(
                name: "station");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "user_station");

            migrationBuilder.DropTable(
                name: "weather_amount_type");

            migrationBuilder.DropTable(
                name: "weather_info");
        }
    }
}

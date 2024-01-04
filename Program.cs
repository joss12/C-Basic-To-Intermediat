using System;
using System.Data;
using System.Diagnostics;
using System.Text.Json;
using System.Text.RegularExpressions;
using AutoMapper;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MyApp.Data;
using MyApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


namespace MyApp
{

    internal class Program
    {

        static void Main(string[] args)
        {

            IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appSettings.json")
            .Build();

            DataContextDapper dapper = new DataContextDapper(config);


            // string sql = @"INSERT INTO TutorialAppSchema.Computer(
            //     Motherboard,
            //     HasWifi,
            //     hasLTE,
            //     ReleaseDate,
            //     Price,
            //     VideoCard
            // ) VALUES ('" + myComputer.Motherboard
            // + "', '" + myComputer.HasWifi
            // + "', '" + myComputer.HasLTE
            // + "', '" + myComputer.ReleaseDate
            // + "', '" + myComputer.Price
            // + "', '" + myComputer.VideoCard
            // + "')";

            // File.WriteAllText("log.txt", "\n" + sql + "\n");
            // using StreamWriter openFile = new("log.txt", append: true);
            // openFile.WriteLine("\n" + sql + "\n");
            // openFile.Close();

            // string computersJson = File.ReadAllText("computers.json");
            string computersJson = File.ReadAllText("computersSnake.json");
            Mapper mapper = new(new MapperConfiguration((cfg)=>{
                cfg.CreateMap<ComputerSnake, Computer>()
                .ForMember(destination => destination.ComputerId, options =>
                 options.MapFrom(source => source.computer_id))
                .ForMember(destination => destination.CPUCores, options =>
                 options.MapFrom(source => source.cpu_cores))
                .ForMember(destination => destination.HasLTE, options =>
                 options.MapFrom(source => source.has_lte))
                .ForMember(destination => destination.HasWifi, options =>
                 options.MapFrom(source => source.has_wifi))
                .ForMember(destination => destination.Motherboard, options =>
                 options.MapFrom(source => source.motherboard))
                .ForMember(destination => destination.VideoCard, options =>
                 options.MapFrom(source => source.video_card))
                .ForMember(destination => destination.Price, options =>
                 options.MapFrom(source => source.price));
            }));

            IEnumerable<ComputerSnake>? computersSystem = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<ComputerSnake>>(computersJson);
            if(computersSystem != null){
                IEnumerable<Computer> computerResult = mapper.Map<IEnumerable<Computer>>(computersSystem);
                Console.WriteLine("JSON Property Count:" + computerResult.Count());

                // foreach(Computer computer in computerResult){
                //     Console.WriteLine(computer.Motherboard);
                // }
            }

            IEnumerable<Computer>? computersSystemJsonPropertyMethod = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(computersJson);

            if(computersSystemJsonPropertyMethod != null){
                Console.WriteLine("JSON Property Count: " + computersSystemJsonPropertyMethod.Count());
                
                // foreach(Computer computer in computersSystemJsonPropertyMethod){
                //     Console.WriteLine(computer.Motherboard);
                // }
            }



            // // Console.WriteLine(computersJson);
        //     JsonSerializerOptions options = new(){
        //         PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        //     };
            
        //     IEnumerable<Computer>? computersNewtonsoft = JsonConvert.DeserializeObject<IEnumerable<Computer>>(computersJson);
        //     IEnumerable<Computer>? computersSystem = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(computersJson, options);

        //     if(computersNewtonsoft != null){
        //         foreach(Computer computer in computersNewtonsoft){
        //             string sql = @"INSERT INTO TutorialAppSchema.Computer(
        //                 Motherboard,
        //                 HasWifi,
        //                 hasLTE,
        //                 ReleaseDate,
        //                 Price,
        //                 VideoCard
        //             ) VALUES ('" +  EscapeSingleQuote(computer.Motherboard)
        //             + "', '" + computer.HasWifi
        //             + "', '" + computer.HasLTE
        //             + "', '" + computer.ReleaseDate
        //             + "', '" + computer.Price
        //             + "', '" +  EscapeSingleQuote(computer.VideoCard)
        //             + "')";
        //             dapper.ExecuteSql(sql);
        //         }
        //     }

        //     JsonSerializerSettings settings = new()
        //     {
        //         ContractResolver = new CamelCasePropertyNamesContractResolver()
        //     };

        //     string computersCopyNewtonsoft = JsonConvert.SerializeObject(computersNewtonsoft, settings);

        //     File.WriteAllText("computersCopyNewtonsoft.txt", computersCopyNewtonsoft);

        //     string computersCopySystem = System.Text.Json.JsonSerializer.Serialize(computersNewtonsoft, options);

        //     File.WriteAllText("computersCopySystem.txt", computersCopySystem);
        }

        // static string EscapeSingleQuote(string input){
        //     string output = input.Replace("'", "''");

        //     return output;
        // }
    }
}





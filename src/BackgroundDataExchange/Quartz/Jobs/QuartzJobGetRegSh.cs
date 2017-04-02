using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quartz;

namespace BackgroundDataExchange.Quartz.Jobs
{
    public class QuartzJobGetRegSh : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            //Получение данных установленных в dataMap для данного ключа job
            //JobDataMap dataMap = context.JobDetail.JobDataMap;
            //var apkDk = dataMap["ApkDkWebClient"] as ApkDkWebClient;
            //var stationsOwner = dataMap["stationsOwner"] as IEnumerable<StationDto>;

            //if(apkDk == null || stationsOwner == null)
            //    return;

            ////foreach (var stOwner in stationsOwner)
            ////{
            ////    apkDk.LoadHttpDataInDb("regular", stOwner);
            ////}


            ////var tasks = stationsOwner.Select(st => apkDk.LoadHttpDataInDb("regular", st)).ToArray();
            ////Task.WaitAll(tasks);

            ////DEBUG
           

            //string pathShed = @"G:\XML файлы\Нормативное\doc_19155_Курская.xml";
            //string pathStat = @"G:\XML файлы\ESRList.xml";
            //var stat = stationsOwner.FirstOrDefault(st => st.Name == "Курский");
            //await apkDk.LoadXmlDataInDb(pathShed, pathStat,"regular", stat);


            //pathShed = @"G:\XML файлы\Нормативное\doc_19612_Рижская.xml";
            //stat = stationsOwner.FirstOrDefault(st => st.Name == "Рижский");
            //await apkDk.LoadXmlDataInDb(pathShed, pathStat, "regular", stat);


            //pathShed = @"G:\XML файлы\Нормативное\doc_19351_Павелецкая.xml";
            //stat = stationsOwner.FirstOrDefault(st => st.Name == "Павелецкий");
            //await apkDk.LoadXmlDataInDb(pathShed, pathStat, "regular", stat);


            //pathShed = @"G:\XML файлы\Нормативное\doc_19600_Савельевский.xml";
            //stat = stationsOwner.FirstOrDefault(st => st.Name == "Савеловский");
            //await apkDk.LoadXmlDataInDb(pathShed, pathStat, "regular", stat);




            //new StationDto { Name = "Курский", EcpCode = 19155 },
            //new StationDto { Name = "Павелецкий", EcpCode = 19351 },
            //new StationDto { Name = "Казанский", EcpCode = 19390 },
            //new StationDto { Name = "Ярославский", EcpCode = 19550 },
            //new StationDto { Name = "Савеловский", EcpCode = 19600 },
            //new StationDto { Name = "Рижский", EcpCode = 19612 },
            //new StationDto { Name = "Киевский", EcpCode = 19810 },
            //new StationDto { Name = "Смоленский", EcpCode = 19823 }
        }
    }
}
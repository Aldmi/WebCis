using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackgroundDataExchange.Quartz.Jobs;
using Domain.Entities;
using Quartz;
using Quartz.Impl;

namespace BackgroundDataExchange.Quartz.Shedules
{
    public class QuartzApkDkReglamentRegSh
    {
        //public static async Task Start(ApkDkWebClient apkDkWebClient, IEnumerable<Station> stationsOwner )
        //{
        //    //Планировщик
        //    var scheduler =await StdSchedulerFactory.GetDefaultScheduler();

        //    //Заполнение словаря пользовательских данных
        //    JobDataMap dataMap = new JobDataMap
        //    {
        //        ["ApkDkWebClient"] = apkDkWebClient,
        //        ["stationsOwner"] = stationsOwner
        //    };

        //    //Создание объекта работы и установка данных для метода Execute
        //    IJobDetail job = JobBuilder.Create<QuartzJobGetRegSh>()
        //        .WithIdentity("getRegShJob", "group1")                 //идентификатор работы (по нему можно найти работу)
        //        .SetJobData(dataMap)
        //        .Build();


        //    //Создание первого условия сработки
        //    ITrigger triggerReg1 = TriggerBuilder.Create()             // создаем триггер
        //        .WithIdentity("triggerReg1", "group1")                 // идентифицируем триггер с именем и группой
        //        .StartAt(DateTimeOffset.Now.AddSeconds(5))             //старт тригера и первый вызов через 5 сек
        //        .WithSimpleSchedule(x => x                             // далее 5 вызовов с интервалом 5 сек
        //            .WithIntervalInSeconds(20)                         // 
        //            .WithRepeatCount(500))
        //       .ForJob(job)
        //       .Build(); // создаем триггер 


        //    //Создание второго условия сработки
        //    ITrigger triggerReg2 = TriggerBuilder.Create()
        //        .WithIdentity("triggerReg2", "group1")
        //        .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(13, 19))          //1 раз в сутки в 13:19
        //        .ForJob(job)
        //        .Build();

        //    //Связывание объекта работы с тригером внутри планировщика
        //    await scheduler.ScheduleJob(job, triggerReg1);
        //    await scheduler.ScheduleJob(triggerReg2);

        //    //запуск планировщика
        //    await scheduler.Start();
        //}


        public static async Task Stop()
        {
            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            JobKey job = new JobKey("getRegShJob", "group1");
            await scheduler.DeleteJob(job);
        }


        public static async Task Shutdown()
        {
            IScheduler scheduler =  await StdSchedulerFactory.GetDefaultScheduler();
            await scheduler.Shutdown(true);
        }
    }
}
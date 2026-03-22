using BLL.Entities;
using BLL.EntityList;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BLL.EntityManager
{
    public static class JobManager
    {
        static DBManager Manager = new DBManager();

        public static JobList GetAllJobs()
        {
            return (DataTableToJobList(Manager.ExecuteDataTable("GetAllJobs")));
        }

        internal static JobList DataTableToJobList(DataTable dataTable)
        {
            JobList jobs = new JobList();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                jobs.Add(DataRowToJob(dataRow));
            }
            return jobs;
        }

        internal static Job DataRowToJob(DataRow dataRow)
        {

            short job_id = dataRow.Field<short>("Job_id");
            string job_desc = dataRow.Field<string>("Job_desc");
            byte min_lvl = dataRow.Field<byte>("Min_lvl");
            byte max_lvl = dataRow.Field<byte>("Max_lvl");

            Job job = new Job
            {
                Job_id = job_id,
                Job_desc = job_desc,
                Min_lvl = min_lvl,
                Max_lvl = max_lvl
            };
            return job;
        }
    }
}

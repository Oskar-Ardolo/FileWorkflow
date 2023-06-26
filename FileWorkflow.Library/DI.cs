using FileWorkflow.Library.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWorkflow.Library
{
    public static class DI
    {
        public static void ConfigureWorkflowService(this IServiceCollection collection)
        {
            collection.AddSingleton<WorkflowService>();
        }
    }
}

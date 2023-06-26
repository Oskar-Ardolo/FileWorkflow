using Microsoft.Extensions.Options;
using FileWorkflow.Library.Service;


namespace FileWorkflow.Console
{
    internal class WorkflowProcessing
    {
        private readonly FileWorkflowApplication _app;
        private readonly WorkflowService _workflowService;

        public WorkflowProcessing(IOptions<FileWorkflowApplication> options, WorkflowService workflowService)
        {
            _app = options.Value;
            _workflowService = workflowService;
        }

        public void Start()
        {
            System.Console.WriteLine("slt");
        }
    }
}

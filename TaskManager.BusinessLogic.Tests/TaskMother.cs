using TaskManager.Core;

namespace TaskManager.BusinessLogic.Tests
{
    public static class TaskMother
    {
        public static Task GetNonEmptyTask()
        {
            var task = new Task();
            task.Steps.Add(StepMother.GetNonEmptyStep());
            return task;
        }
    }
}
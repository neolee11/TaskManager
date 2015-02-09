using System;
using TaskManager.Core;

namespace TaskManager.BusinessLogic.Tests
{
    public static class StepMother
    {
        public static Step GetNonEmptyStep()
        {
            var ranId = new Random().Next(100000);

            return new Step()
            {
                Id = ranId,
                Description = "A random step " + ranId.ToString(),
                DueDate = new DateTime(2015, 1, 23),
                Status = StepStatus.Open
            };
        }
    }
}
using System;
using System.Linq;
using NUnit.Framework;
using TaskManager.Core;

namespace TaskManager.BusinessLogic.Tests
{
    [TestFixture]
    public class TaskManagerTests
    {
        private TaskManager sut;

        #region Fixture Setup
        [TestFixtureSetUp]
        public void BeforeAnyTestStarted()
        {
            
        }

        [TestFixtureTearDown]
        public void AfterAllTestsFinished()
        {
            
        }
        #endregion

        #region Test Setup
        //Run before each test
        [SetUp]
        public void TestSetup()
        {
             sut = new TaskManager();
        }

        #endregion

        #region NUnit Useful Attributes

        //[TestCaseSource]
        //[Category]
        //[Repeat]
        //[MaxTime]
        //[TestCase(10, 5)]
        //[TestCase(20, 3)]
        //public void Something(int a, int b)
        //{
        //}
        #endregion

        #region AppendStep

        [Test]
        public void AppendStep_GivenAEmptyTask_ShouldAppendStepToTheEndOfTask()
        {
            sut.AppendStep(new Step());
            Assert.That(sut.TotalSteps, Is.EqualTo(1));
        }

        [Test]
        public void AppendStep_GivenANonEmptyTask_ShouldAppendStepToTheEndOfTask()
        {
            sut.Task = TaskMother.GetNonEmptyTask();
            var step = StepMother.GetNonEmptyStep();
            sut.AppendStep(step);
            Assert.That(step.Id, Is.EqualTo(sut[sut.TotalSteps - 1].Id));

        }
        #endregion

        #region AddStep
        
        [Test]
        public void AddStep_GivenAStepWithoutPosition_ShouldAddToTheEndOfTask()
        {
            sut.Task = TaskMother.GetNonEmptyTask();
            var step = StepMother.GetNonEmptyStep();
            sut.AddStep(step);
            Assert.That(step.Id, Is.EqualTo(sut[sut.TotalSteps - 1].Id));
        }

        [Test]
        public void AddStep_GivenAStepWithPosition_ShouldAddTheStepInThatPositionInTaskSteps()
        {
            var step1 = StepMother.GetNonEmptyStep();
            sut.AppendStep(step1);
            var step2 = StepMother.GetNonEmptyStep();
            sut.AppendStep(step2);

            var newStep = StepMother.GetNonEmptyStep();
            var position = 2;
            sut.AddStep(newStep, position);
            Assert.That(newStep.Id, Is.EqualTo(sut[position - 1].Id));
        }
        #endregion

        #region ToggleStepStatus

        [Test]
        public void ToggleStepStatus_GivenAOpenStep_ShouldChangeStepToClose()
        {
            var step = StepMother.GetNonEmptyStep();
            step.Status = StepStatus.Open;
            sut.AppendStep(step);

            sut.ToggleStepStatus(step.Id);
            Assert.That(step.Status, Is.EqualTo(StepStatus.Close));
        }

        [Test]
        public void ToggleStepStatus_GivenACloseStep_ShouldChangeStepToOpen()
        {
            var step = StepMother.GetNonEmptyStep();
            step.Status = StepStatus.Close;
            sut.AppendStep(step);

            sut.ToggleStepStatus(step.Id);
            Assert.That(step.Status, Is.EqualTo(StepStatus.Open));
        }

        [Test]
        public void ToggleStepStatus_GivenAUnknowStep_ShouldThrowException()
        {
            var step = StepMother.GetNonEmptyStep();
            sut.AppendStep(step);

            Assert.That(() => sut.ToggleStepStatus(step.Id + 1), Throws.Exception.With.Message.EqualTo(String.Format("No step with Id {0} found.", step.Id + 1)));
        }
        #endregion

        #region DeleteStep

        #endregion

        #region Save

        #endregion

        #region Load

        #endregion

        #region Update

        #endregion
    }
}

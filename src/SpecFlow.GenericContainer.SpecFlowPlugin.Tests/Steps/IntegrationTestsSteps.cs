using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SpecFlow.GenericContainer.SpecFlowPlugin.Tests.Steps
{
    [Binding]
    public class IntegrationTestsSteps
    {
        private readonly ICalculator _calculator;

        public IntegrationTestsSteps(ScenarioContext context, ICalculator calculator)
        {
            _calculator = calculator;
        }

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            _calculator.Enter(p0);
        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            _calculator.Add();
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            Assert.That(_calculator.Result, Is.EqualTo(p0));
        }
    }
}

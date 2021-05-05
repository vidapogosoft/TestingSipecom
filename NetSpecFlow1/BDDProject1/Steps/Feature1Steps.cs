using System;
using TechTalk.SpecFlow;

namespace BDDProject1.Steps
{
    [Binding]
    public class Feature1Steps
    {
        [Given(@"primer numero es (.*)")]
        public void GivenPrimerNumeroEs(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"segundo numero es (.*)")]
        public void GivenSegundoNumeroEs(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"tercer numero es (.*)")]
        public void GivenTercerNumeroEs(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"se procede con al suma")]
        public void WhenSeProcedeConAlSuma()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"el resulatado es (.*)")]
        public void ThenElResulatadoEs(int p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}

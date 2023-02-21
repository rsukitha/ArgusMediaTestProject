using NUnit.Framework;
using RestaurantCheckOutSystem;
using TestCheckOutSystem.Drivers;

namespace TestCheckOutSystem.StepDefinitions
{

    [Binding]
    public sealed class RestaurantCheckOutStepDefinitions
    {
        private double _total;
        private readonly OrderDetailsDriver driver = new OrderDetailsDriver(new CheckOut());
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;

        public RestaurantCheckOutStepDefinitions(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            // Inject FeatureContext and ScenarioContext to pass values between different scenario and between scenario steps
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
        }

        [Given(@"the following orders")]
        public void GivenTheFollowingOrders(Table orders)
        {
            driver.addOrder(orders);
            // Add orders to the feature as it can be accessed in other scenario
            _featureContext["orders"] = orders;
        }

        [Given(@"the following orders are added")]
        public void GivenTheFollowingOrdersAreAdded(Table orders)
        {
            driver.addOrder(orders);
        }


        [When(@"the order total is calculated")]
        public void WhenTheOrderTotalIsCalculated()
        {
            try
            {
                _total = driver.getTotal();

            }
            catch (Exception ex)
            {
                // Add the error message to the scenario context so we can catch it in the Then step within same scenario
                _scenarioContext["Exception"] = ex.Message;
            }
        }

        [Given(@"the existing orders")]
        public void GivenTheExistingOrders()
        {
            // Add orders from previous scenario to orders of this scenario
            driver.addOrder((Table)_featureContext["orders"]);
        }


        [Then(@"the order total should be (.*)")]
        public void ThenTheOrderTotalShouldBe(double result)
        {
            _total.Should().Be(result);
        }

        [Then(@"User is presented with an message ""([^""]*)""")]
        public void ThenUserIsPresentedWithAnMessage(string errorMessage)
        {
            Assert.AreEqual(errorMessage, _scenarioContext["Exception"]);
        }


        [Given(@"the following updated order")]
        public void GivenTheFollowingUpdatedOrder(Table orders)
        {
            driver.updateOrder(orders);
        }

        [Then(@"discount applied for all ordered drinks")]
        public void ThenDiscountAppliedForAllOrderedDrinks()
        {
            List<bool> discounted = driver.wasDiscountApplied();
            foreach (bool discountedItem in discounted)
            {
                discountedItem.Should().Be(true);
            }
        }

        [Then(@"discount not applied for any of the ordered drinks")]
        public void ThenDiscountNotAppliedForAnyOfTheOrderedDrinks()
        {
            List<bool> discounted = driver.wasDiscountApplied();
            foreach (bool discountedItem in discounted)
            {
                discountedItem.Should().Be(false);
            }
        }

        [Then(@"discount is applied for drinsk ordered before 1900 and not applied for drinks ordered after 1900")]
        public void ThenDiscountIsAppliedForDrinskOrderedBeforeAndNotAppliedForDrinksOrderedAfter()
        {
            int discountedCount = 0;
            int notDiscountedCount = 0;
            List<bool> discounted = driver.wasDiscountApplied();

            foreach (bool discountedItem in discounted)
            {
                if(discountedItem == false)
                {
                    notDiscountedCount += 1;
                } else
                {
                    discountedCount+= 1;
                }
            }

            discountedCount.Should().NotBe(0);
            notDiscountedCount.Should().NotBe(0);

        }


    }
}
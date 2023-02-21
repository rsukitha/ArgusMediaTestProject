# ArgusMediaTestProject

## Assumptions
For the sake of this test project I have made the following assumptions, these assumptions SHOULD NOT be made for a production system and more testcases to be written to be more thorough with testing.

1. The endpoint doesn't need a user login at this point
2. Since the objective is to test the order total generation, the orders are all placed at once, and when re-ordered the updated order list is sent to the endpoint
3. When an order is placed before 19:00 and let's say they cancel a few items by 20:00. Per the above point, we will be sending an updatedorder of all the items. Since the initial order was given before 19:00, the discount price still applies for drinks that were re-ordered after 20:00. This is becuase we initiate a re-order which is just removing a few items from the order that was already placed before 19:00

## Design Considerations
I do not have a clear idea of how the end point would be implemented and hence I have implemented my own endpoint for test purposes and does not represent a production system in any manner. This is just a little mock for the endpoint

1. I did not write a method to add items one by one to the order. This is because, in an ideal scenario we would have 100s of people in a restaurant and each person could potentially order 5+ items. We are then looking at the endpoint being called 500+ times within a short span.
2. I have made use of feature context in scenario 2 and 3. I thought of an option to move scenario 2 and 3 to their corresponding features and have a `Background` which will contain the common `Given`, but since all these tests were done for the same logic I didn'want to move these to their own features.
3. I have passed in the time as an `ìnt` and not a `DateTime` as the endpoint is a mock one and didn't need parsing logic as that isn't the objective of this project

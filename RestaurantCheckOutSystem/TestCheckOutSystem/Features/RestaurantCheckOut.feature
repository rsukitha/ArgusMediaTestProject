Feature: RestaurantcheckOut
		We will be writing a series of test cases that will 
		test the RestaurantcheckOutSystem and validate the results

@Scenario1
Scenario: 1 A group of 4 people orders 4 starters, 4 mains and 4 drinks before 19:00
	Given the following orders
		| Item       | Count | OrderTime | Type     |
		| springroll | 2     | 16        | starters |
		| samosa	 | 1     | 16        | starters |
		| chips		 | 1     | 16        | starters |
		| pizza      | 2     | 17        | main     |
		| pasta      | 2     | 17        | main     |
		| coke       | 4     | 18        | drinks   |
	When the order total is calculated
	Then the order total should be 56.1
	And discount applied for all ordered drinks

@Scenario1
Scenario: 2 A group of 4 people orders 4 starters, 4 mains and 4 drinks after 19:00
	Given the following orders
		| Item       | Count | OrderTime | Type     |
		| springroll | 2     | 19        | starters |
		| samosa	 | 1     | 19        | starters |
		| chips		 | 1     | 19        | starters |
		| pizza      | 2     | 20        | main     |
		| pasta      | 2     | 20        | main     |
		| coke       | 2     | 20        | drinks   |
		| pepsi      | 2     | 20        | drinks   |
	When the order total is calculated
	Then the order total should be 59.4
	And discount not applied for any of the ordered drinks

@Scenario1
Scenario: 3 A group of 4 people orders 4 starters, 4 mains and 4 drinks at 19:00
	Given the following orders
		| Item       | Count | OrderTime | Type     |
		| springroll | 2     | 19        | starters |
		| samosa	 | 1     | 19        | starters |
		| chips		 | 1     | 19        | starters |
		| pizza      | 2     | 19        | main     |
		| pasta      | 2     | 19        | main     |
		| coke       | 2     | 19        | drinks   |
		| pepsi      | 2     | 19        | drinks   |
	When the order total is calculated
	Then the order total should be 59.4
	And discount not applied for any of the ordered drinks

@Scenario1
Scenario: 4 A group of 4 people orders 4 starters, 4 mains and 4 drinks before and after 19:00
	Given the following orders
		| Item       | Count | OrderTime | Type     |
		| springroll | 2     | 16        | starters |
		| samosa	 | 1     | 16        | starters |
		| chips		 | 1     | 17        | starters |
		| pizza      | 2     | 17        | main     |
		| pasta      | 2     | 17        | main     |
		| coke       | 2     | 17        | drinks   |
		| pepsi      | 2     | 20        | drinks   |
	When the order total is calculated
	Then the order total should be 57.75
	And discount is applied for drinsk ordered before 1900 and not applied for drinks ordered after 1900

@Scenario1
Scenario: 5 A group of 4 people orders 4 starters, 4 mains and 4 drinks with unavailable items - "limca"
	Given the following orders
		| Item       | Count | OrderTime | Type     |
		| springroll | 2     | 19        | starters |
		| samosa	 | 1     | 19        | starters |
		| chips		 | 1     | 19        | starters |
		| pizza      | 2     | 19        | main     |
		| pasta      | 2     | 19        | main     |
		| limca      | 2     | 19        | drinks   |
		| pepsi      | 2     | 19        | drinks   |
	When the order total is calculated
	Then User is presented with an message "The given key 'limca' was not present in the dictionary."

@Scenario2
Scenario: 6.0 A group of 2 people order 1 starter and 2 mains and 2 drinks before 19:00
	Given the following orders
		| Item       | Count | OrderTime | Type     |
		| springroll | 1     | 18        | starters |
		| pizza      | 1     | 18        | main     |
		| pasta      | 1     | 18        | main     |
		| coke       | 1     | 18        | drinks   |
		| pepsi      | 1     | 18        | drinks   |
	When the order total is calculated
	Then the order total should be 23.65
	And discount applied for all ordered drinks

@Scenario2
Scenario: 6.1 They are then joined by 2 more people at 20:00 who order 2 mains and 2 drinks
	Given the existing orders
	And the following orders are added
		| Item       | Count | OrderTime | Type     |
		| pizza      | 1     | 20        | main     |
		| pasta      | 1     | 20        | main     |
		| coke       | 1     | 20        | drinks   |
		| pepsi      | 1     | 20        | drinks   |
	When the order total is calculated
	Then the order total should be 44.55
	And discount is applied for drinsk ordered before 1900 and not applied for drinks ordered after 1900


@Scenario2
Scenario: 6.2 A group of 2 people order 1 starter and 2 mains and 2 drinks before 19:00, 
			they are then joined by 2 more people at 20:00 who order 2 mains and 2 drinks with unavailable items - "limca"
	Given the existing orders
	And the following orders are added
		| Item       | Count | OrderTime | Type     |
		| springroll | 2     | 19        | starters |
		| samosa	 | 1     | 19        | starters |
		| chips		 | 1     | 19        | starters |
		| pizza      | 2     | 19        | main     |
		| pasta      | 2     | 19        | main     |
		| limca      | 2     | 19        | drinks   |
		| pepsi      | 2     | 19        | drinks   |
	When the order total is calculated
	Then User is presented with an message "The given key 'limca' was not present in the dictionary."

@Scenario3
Scenario: 7.0 A group of 4 people order 4 starters, 4 mains and 4 drinks before 19:00
	Given the following orders
		| Item       | Count | OrderTime | Type     |
		| springroll | 2     | 16        | starters |
		| samosa	 | 1     | 16        | starters |
		| chips		 | 1     | 16        | starters |
		| pizza      | 2     | 17        | main     |
		| pasta      | 2     | 17        | main     |
		| coke       | 4     | 18        | drinks   |
	When the order total is calculated
	Then the order total should be 56.1
	And discount applied for all ordered drinks


@Scenario3
Scenario: 7.1 One person cancels their order at 20:00 and the order is now updated to 3 starters, 3 mains and 3 drinks
	Given the existing orders
	And the following updated order
		| Item       | Count | OrderTime | Type     |
		| springroll | 2     | 20        | starters |
		| chips		 | 1     | 20        | starters |
		| pizza      | 2     | 20        | main     |
		| pasta      | 1     | 20        | main     |
		| coke       | 3     | 20        | drinks   |
	When the order total is calculated
	Then the order total should be 42.075
	And discount applied for all ordered drinks

@Scenario3
Scenario: 8.0 A group of 4 people order 4 starters, 4 mains and 4 drinks after 19:00
	Given the following orders
		| Item       | Count | OrderTime | Type     |
		| springroll | 2     | 20        | starters |
		| samosa	 | 1     | 20        | starters |
		| chips		 | 1     | 20        | starters |
		| pizza      | 2     | 20        | main     |
		| pasta      | 2     | 20        | main     |
		| coke       | 4     | 20        | drinks   |
	When the order total is calculated
	Then the order total should be 59.4
	And discount not applied for any of the ordered drinks


@Scenario3
Scenario: 8.1 One person cancels their order and the order is now updated to 3 starters, 3 mains and 3 drinks
	Given the existing orders
	And the following updated order
		| Item       | Count | OrderTime | Type     |
		| springroll | 2     | 21        | starters |
		| chips		 | 1     | 21        | starters |
		| pizza      | 2     | 21        | main     |
		| pasta      | 1     | 21        | main     |
		| coke       | 3     | 21        | drinks   |
	When the order total is calculated
	Then the order total should be 44.55
	And discount not applied for any of the ordered drinks
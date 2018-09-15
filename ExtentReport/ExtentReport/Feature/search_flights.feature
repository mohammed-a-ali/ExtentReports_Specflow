Feature: search_flight
	
Scenario: Search for a flight from cairo to Riyadh
	Given I am on the Homepage
	And I select "One way" trip
	And I selected From "Cairo (CAI)"
	And I selected To "Riyadh (RUH)"
	And I select Depart date "20/09/2018"
	And I select travellers ""
	When I press on "Search Flights" button
	Then I should see "results sorted by"

Feature: search_flight
	I want to search for a flight


Scenario: Search for a flight from cairo to Riyadh
	Given I am on the Homepage
	And I selected "" tab
	And I select "" trip
	And I selected from ""
	And I selected to ""
	And I select travellers ""
	When I press Search Flights ""
	Then all available flights "" will appear

Feature: SaveItem
	In order to persist the item
	As a user
	I want to save the changed item

Scenario: Save new star item
	Given I have a minimal new item
	When I press save
	Then the item is saved
	
Scenario: Save empty star item
	When I add a new star item without putting entering data
	Then the item cannot be saved


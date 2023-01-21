Feature: WebUITestsAddRecords

Scenario Outline: Add New Record to Pay Grades
	Given I navigate to webpage
	When I log in as admin user
	And I navigate to job and Pay Grades tab
	And I add a new entry with <name>
	And I assign <minimum> minimum and <maximum> sallary to it
	Then I see the changes in the Currencies block
	#Given I navigate to job and Pay Grades tab
	#When I delete added data
	#Then I check that the data is removed
	Examples: 
	|   name   |  minimum  | maximum |
	|RandomName|   250000  | 300000  |


Scenario Outline: Cancel the addition of new Record to Pay Grades
	Given I navigate to webpage
	When I log in as admin user
	And I navigate to job and Pay Grades tab
	And I add a new entry with <name>
	And I assign <minimum> minimum and <maximum> maximum sallary to it but click on cancel
	Then I don't see the changes in the Currencies block
	#Given I navigate to job and Pay Grades tab
	#When I delete added data
	#Then I check that the data is removed
	Examples: 
	|   name   |  minimum  | maximum |
	|RandomName|   250000  | 300000  |

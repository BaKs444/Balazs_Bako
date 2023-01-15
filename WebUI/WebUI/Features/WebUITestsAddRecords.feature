Feature: WebUITestsAddRecords

Scenario: Add New Record to Pay Grades
	Given I navigate to webpage
	When I log in as admin user
	And I navigate to job and Pay Grades tab
	And I add a new entry with random name
	And I assign sallary to it
	Then I see the changes in the Currencies block

Scenario: Cancel the addition of new Record to Pay Grades
	Given I navigate to webpage
	When I log in as admin user
	And I navigate to job and Pay Grades tab
	And I add a new entry with random name
	And I assign sallary to it but click on cancel
	Then I don't see the changes in the Currencies block

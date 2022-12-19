Feature: Saucedemo test

This feature use the www.saucedemo.com webpage
to create different scenarios.

	Background:
		Given Open the Google Chrome browser
		And Go to the www.saucedemo.com webpage


	Scenario Outline: Login to the webpage with right credentials
		Given I am on the login page of www.saucedemo.com
		When I enter the <username> username
		And I enter the <password> password
		And Click on the "login" button
		Then Acces gained and the home page is opened
		Examples:
		|         username		  |   password   |
		|      standard_user	  | secret_sauce |
		|       problem_user	  | secret_sauce |
		| performance_glitch_user | secret_sauce |


	Scenario Outline: Login to the web page with wrong credentials
		Given I am on the login page of www.saucedemo.com
		When I enter the <username> username
		And I enter the <password> password
		And Click on the "login" button
		Then Acces denied and and error message appear.
		Examples:
		|       username        |     password       |
		| Everything_is_OK_user |   public_sauce     |
		|    Nothing_is_Right   | My_Supersecret_PWD |

	Scenario: Login to the web page with the locked out credential
		Given I am on the login page of www.saucedemo.com
		When I enter the "locked_out_user" username
		And I enter the secret_sauce password
		And Click on the "login" button
		Then Acces denied and and and error message appear that i am locked out.

	Scenario: Login to the web page with the problem_user credential
		Given I am on the login page of www.saucedemo.com
		When I enter the "problem_user" username
		And I enter the secret_sauce password
		And Click on the "login" button
		Then All of the pictures are a dog with a tennisball
		But The pictures should contains the items, not the picture of the dog

	Scenario: Add item to the cart
		Given I am on the home page
		When I click on "Sauce Lab Backback"
		And I add it to cart
		Then I see the selected item in cart
		But Nothing else should be added to cart

	Scenario: Remove item from cart
		Given I am on the cart page
		And There is a "Sauce Lab Bacpack" in the cart
		When I click on the "Remove" button
		Then The item disapear from cart

	Scenario Outline: Chekcout with an item in cart
		Given There is an item in cart
		When Click on the "Checkout" button on the Cart page
		And Enter <firstname> first name
		And Enter <lastname> last name
		And Enter <zipcode> Zip code
		And click on the "Continue" button 
		And Click on the "Finish" button
		Then A message appears that the process was successful
		Examples:
		| firstname | lastname  | zipcode |
		|  Andreas  |  Potter   |   4234  |
		|    Jack   |   Smith   |   6424  |
		

	Scenario: Oreder items based on costs
		Given I am at the homepage
		And See all the various items
		When Click on the filter bar and chose "Price (low to high)
		Then The items are ordered based on the price
		
	Scenario: Oreder items based on name
		Given I am at the homepage
		And See all the various items
		When Click on the filter bar and chose "Name (Z to A)
		Then The items are ordered based on the alphabet

	Scenario: Logout
		Given I am loged in
		And I am on the home page
		When I click on the "Menu" button
		And Select "Logout"
		Then I am logged out from the page

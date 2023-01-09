Feature: Saucedemo test

This feature uses the www.saucedemo.com webpage
to create different scenarios.

	Background:
		Given Open the Google Chrome browser
		And Go to the www.saucedemo.com webpage


	Scenario Outline: Login to the website
		Given I am on the login page of SauceDemo
		When I enter the <username> username
		And I enter the <password> password
		And Click on the "login" button
		Then Access gained and the home page is opened
		Examples:
		|         username		  |   password   |
		|      standard_user	  | secret_sauce |
		|       problem_user	  | secret_sauce |
		| performance_glitch_user | secret_sauce |


	Scenario Outline: Login to the website with wrong credentials
		Given I am on the login page of www.saucedemo.com
		When I enter the <username> username
		And I enter the <password> password
		And Click on the "login" button
		Then Access denied and error message appear.
		Examples:
		|       username        |     password       |
		| Everything_is_OK_user |   public_sauce     |
		|    Nothing_is_Right   | My_Supersecret_PWD |

	Scenario: Login to the website with the locked out credential
		Given I am on the login page of SauceDemo
		When I enter the "locked_out_user" username
		And I enter the secret_sauce password
		And Click on the "login" button
		Then Access denied and and error message appear that i am locked out.

	Scenario: Login to the website with the problem_user credential
		Given I am on the login page of SauceDemo
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
		But The cart contains only one item

	Scenario: Remove item from cart
		Given I am on the cart page
		And There is a "Sauce Lab Backpack" in the cart
		When I click on the "Remove" button
		Then The item disapears from cart

	Scenario Outline: Chekckout with an item in cart
		Given There is an item in cart
		When I click on the "Checkout" button on the Cart page
		And I enter <firstname> first name
		And I enter <lastname> last name
		And I enter <zipcode> Zip code
		And I click on the "Continue" button 
		And I click on the "Finish" button
		Then A message appears that the process was successful
		Examples:
		| firstname | lastname  | zipcode |
		|  Andreas  |  Potter   |   4234  |
		|    Jack   |   Smith   |   6424  |
		

	Scenario: Order items based on costs
		Given I am at the homepage
		And See all the various items
		When Click on the filter bar and chose "Price (low to high)
		Then The items are ordered based on the price
		
	Scenario: Order items based on name
		Given I am at the homepage
		And See all the various items
		When I click on the filter bar and chose "Name (Z to A)
		Then The items are ordered descendingly

	Scenario: Logout
		Given I am logged in
		And I am on the home page
		When I click on the "Menu" button
		And Select "Logout"
		Then I am logged out from the page

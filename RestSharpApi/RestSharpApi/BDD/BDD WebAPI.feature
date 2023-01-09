Feature: WebAPI

This feature helps write test scenarios 
for the RESTFUL_BOOKER Web API.

Scenario: Create a booking with "Post" method.
	Given Correct data for the booking.
	When Create booking on the webserver with Post request.
	Then Booking created on the webserver,
	And Get the Http Status Code "OK",
	And Get back the booking data.

Scenario: Fail to create a booking with "Post" method.
	Given Incorrect data (not contains a required element).
	When Send the Post request to the webserver.
	Then Booking not created on the webserver,
	And Get the Http status code "Internal Server Error".

Scenario: Get the booking ID with "Get" method.
	Given Booking on the Web server
	When Send the Get request to the webserver,
	And it contains a valid first name attribute.
	Then The response contains the booking ID with given attribute.

Scenario: Get the booking with invalid booking ID.
	Given Bookings on the Web server
	When Send the Get request to the webserver with invalid booking ID.
	Then Get the Http status code "Internal Not Found".

Scenario: Update an existing booking with "Put" method.
	Given Booking with ID on the Web server
	When Send the Put request to the webserver with valid booking ID and data.
	Then Get the Http status code "OK".

Scenario: Update a booking with invalid booking ID.
	Given No booking with the provided ID.
	When Send the Put request to the webserver with invalid booking ID and valid data.
	Then Get the Http status code "Method No Allowed".

Scenario: Delete a booking with valid booking ID.
	Given Create booking on the webserver with Post request.
	And Get the ID of the just created booking.
	When Send the Delete request to the webserver with the ID.
	Then Get the Http status code "Created".

Scenario: Fail to delete a booking with wrong credentials.
	Given Create booking on the webserver with Post request.
	And Get the ID of the just created booking.
	When Send the Delete request to the webserver with the ID but wrong credentials.
	Then Get the Http status code "Forbidden".

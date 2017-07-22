Feature: MiniStatement
	In order to avoid mistakes
	In MinniStatement

@MiniStatement
Scenario: Browse login page
    When the user goes to the login user screen
    Then the login user view should be displayed

@MiniStatement
Scenario: On successful login the user should be redirected to Home Page
    When the user goes to the login user screen
    Then the login user view should be displayed
    Given The user has entered all the information
    When He clicks on login button
    Then He should be redirected to the home page

@MiniStatement
Scenario: On home page user clicks on viewministatement to view his transactions
	When the user goes to the login user screen
    Then the login user view should be displayed
    Given The user has entered all the information
    When He clicks on login button
    Then He should be redirected to the home page
    When He clicks on viewministatement
    Then He should be redirected to the ministatement page